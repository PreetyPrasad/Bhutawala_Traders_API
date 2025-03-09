using System;
using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Bhutawala_Traders_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public AdminController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> InsertAdmin(Admin admin)
        {
            try
            {
                var exist = await _dbContext.Admins.ToListAsync();

                List<string> errors = new List<string>();
                if (exist.Any(o => o.ContactNo == admin.ContactNo))
                {
                    errors.Add("Contact Number is already Exist");
                }
                if (exist.Any(o => o.Email == admin.Email))
                {
                    errors.Add("Email is already Exist");
                }
                if (errors.Count == 0)
                {
                    AutoGenratePasswd autoGenratePasswd = new AutoGenratePasswd();
                    var passwd = autoGenratePasswd.Autopasswd();
                    htmlFormater htmlFormater = new htmlFormater();
                    AESCrypto aESCrypto = new AESCrypto();
                    EmailSender emailSender = new EmailSender();
                    var htmlFormateString = htmlFormater.createAccountFormate(admin.UserName, admin.ContactNo, passwd);
                    admin.Password = aESCrypto.Encrypt(passwd);
                    _dbContext.Admins.Add(admin);
                    await _dbContext.SaveChangesAsync();
                    emailSender.SendEmail(admin.Email, "Create Account", htmlFormateString);
                    return Ok(new { Status = "OK", Result = "Successfully Saved" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = errors });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Status = "Fail", Result = ex.Message });
            }
        }


        [HttpGet]
        [Route("EncPasswd/{Passwd}")]
        public IActionResult encPasswd(string Passwd)
        {
            AESCrypto aESCrypto = new AESCrypto();
            return Ok(new { Password = aESCrypto.Encrypt(Passwd) });
        }


        [HttpPost]
        [Route("updateAdmin")]
        public async Task<IActionResult> UpdateAdmin(Admin admin) 
        {
            try
            {
                var existingAdmin = await _dbContext.Admins
                                                    .Where(o => o.AdminId != admin.AdminId && o.Email == admin.Email)
                                                    .FirstOrDefaultAsync();
                if (existingAdmin == null)
                {
                    _dbContext.Admins.Update(admin);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "OK", Result = "Save" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Email already exists" });
                }
            }
            catch (Exception Exp)
            {
                return Ok(new { Status = "Fail", Result = Exp.Message });
            }
        }

        [HttpPost]
        [Route("Authentication")]
        public async Task<IActionResult> Authentication(Authentication admin)
        {

            try
            {
                AESCrypto aESCrypto = new AESCrypto();
                if (_dbContext.Admins.Any(o => o.UserName == admin.UserName))
                {
                    var encPasswd = aESCrypto.Encrypt(admin.Password);

                    var existingAdmin = await _dbContext.Admins
                                                   .Where(o => o.UserName == admin.UserName && o.Password == encPasswd)
                                                   .Select(o => new
                                                   {
                                                       o.UserName,
                                                       o.AdminId
                                                   }).FirstOrDefaultAsync();


                    if (existingAdmin != null)
                    {
                        return Ok(new { status = "OK", result = existingAdmin });
                    }
                    else
                    {
                        return Ok(new { status = "Fail", result = "Wrong Username or Password" });
                    }
                }
                else
                {
                    return Ok(new { status = "Fail", result = "User not found" });
                }
            }
            catch (Exception Exp)
            {
                return Ok(new { Status = "Fail", Result = Exp.Message });
            }
        }


        [HttpGet]
        [Route("adminDetails/{Id?}")]
        public async Task<IActionResult> ShowAdmin(int? Id)
        {
            if (Id != null)
            {
                var data = await _dbContext.Admins.FindAsync(Id);
                if (data != null)
                {
                    return Ok(new { Status = "OK", Result = data });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Not found" });
                }
            }
            else
            {
                return Ok(new { Status = "Fail", Result = "Parameter is Missing" });
            }
        }


        [HttpGet]
        [Route("allAdmins")]
        public async Task<IActionResult> ShowAllAdmins()
        {
            var data = await _dbContext.Admins.ToListAsync();
            return Ok(new { Status = "OK", Result = data });
        }

        [HttpGet]
        [Route("ForgotPasswd/{UserName}")]
        public async Task<IActionResult> ForgotPasswd(string UserName)
        {
            try
            {
                var exisData = await _dbContext.Admins.Where(o => o.UserName == UserName).FirstOrDefaultAsync();
                if (exisData != null)
                {

                    htmlFormater htmlFormater = new htmlFormater();
                    AESCrypto aESCrypto = new AESCrypto();
                    EmailSender emailSender = new EmailSender();
                    var htmlFormateString = htmlFormater.forgotPasswordFormate(exisData.UserName, exisData.ContactNo, aESCrypto.Decrypt(exisData.Password));
                    emailSender.SendEmail(exisData.Email, "Create Account", htmlFormateString);
                    return Ok(new { Status = "OK", Result = "Sent Successfully" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Not Found" });
                }

            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
            }
        }



        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> changePassword(Admin Model)
        {
            try
            {
                var ExistData = await _dbContext.Admins.FindAsync(Model.AdminId);
                AESCrypto aESCrypto = new AESCrypto();
                var encPasswd = aESCrypto.Encrypt(Model.oldPasswd);


                if (ExistData != null)
                {
                    if (ExistData.Password == encPasswd)
                    {
                        ExistData.Password =aESCrypto.Encrypt(Model.newPasswd);
                        _dbContext.Admins.Update(ExistData);
                        await _dbContext.SaveChangesAsync();
                        return Ok(new { Status = "Ok", Result = "Password Change Successfully" });
                    }
                    else
                    {
                        return Ok(new { Status = "Fail", Result = "Old Password is Incorrect" });

                    }
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Not Found" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });

            }
        }

        [HttpDelete]
        [Route("deleteAdmin/{Id?}")]
        public async Task<IActionResult> RemoveAdmin(int? Id)
        {
            try
            {
                var data = await _dbContext.Admins.FindAsync(Id);
                if (data != null)
                {
                    _dbContext.Admins.Remove(data);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "OK", Result = "Deleted Successfully" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Not Found" });
                }
            }
            catch (Exception Exp)
            {
                return Ok(new { Status = "Fail", Result = Exp.Message });
            }
        }
    }
}
