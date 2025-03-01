using System;
using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Bhutawala_Traders_API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
                var existingAdmin = await _dbContext.Admins
                                                    .Where(o => o.UserName == admin.UserName && o.Password == admin.Password )
                                                    .Select(o=> new
                                                    {
                                                        o.UserName,
                                                       o.AdminId
                                                    }).FirstOrDefaultAsync();
                if (existingAdmin != null)
                {
                    return Ok(new { Status = "OK", Result = existingAdmin });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Wrong Username or Password" });
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

        [HttpPost]
        [Route("ForgotPasswd")]
        public async Task<IActionResult> ForgotPasswd(string UserName)
        {
            try
            {
                var exisData = await _dbContext.StaffMasters.Where(o => o.FullName == UserName).FirstOrDefaultAsync();
                if (exisData != null)
                {

                    htmlFormater htmlFormater = new htmlFormater();
                    AESCrypto aESCrypto = new AESCrypto();
                    EmailSender emailSender = new EmailSender();
                    var htmlFormateString = htmlFormater.forgotPasswordFormate(exisData.FullName, exisData.ContactNo, aESCrypto.Decrypt(exisData.Password));
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
        public async Task<IActionResult> changePassword(StaffMaster Model)
        {
            try
            {
                var ExistData = await _dbContext.StaffMasters.FindAsync(Model.StaffId);
                if (ExistData != null)
                {
                    if (ExistData.Password == Model.OldPassword)
                    {
                        ExistData.Password = Model.NewPassword;
                        _dbContext.StaffMasters.Update(ExistData);
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
