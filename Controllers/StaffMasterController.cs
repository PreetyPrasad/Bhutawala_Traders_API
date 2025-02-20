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
    public class StaffMasterController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public StaffMasterController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> AddStaffMaster(StaffMaster staffMaster)
        {
            try
            {
                var exist=await _dbContext.StaffMasters.ToListAsync();

                List<string> errors = new List<string>();
                if (exist.Any(o => o.ContactNo == staffMaster.ContactNo)) 
                {
                    errors.Add("Contact Number is already Exist");
                }
                if (exist.Any(o => o.Email == staffMaster.Email))
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
                    var htmlFormateString = htmlFormater.createAccountFormate(staffMaster.FullName, staffMaster.ContactNo, passwd);
                    staffMaster.Password = aESCrypto.Encrypt(passwd);
                    _dbContext.StaffMasters.Add(staffMaster);
                    await _dbContext.SaveChangesAsync();
                    emailSender.SendEmail(staffMaster.Email, "Create Account", htmlFormateString);
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

        [HttpPut]
        [Route("Edit")]
        public async Task<IActionResult> EditStaffMaster(StaffMaster staffMaster)
        {
            try
            {
                var existData = await _dbContext.StaffMasters.Where(o => o.StaffId != staffMaster.StaffId).ToListAsync();
                List<string> errors = new List<string>();

                if (existData.Any(o => o.ContactNo == staffMaster.ContactNo))
                {
                    errors.Add("Contact No. is Exists");
                }

                if (staffMaster.Email != null)
                {
                    if (existData.Any(o => o.Email == staffMaster.Email))
                    {
                        errors.Add("Email is Exists");
                    }
                }

                if (errors.Count == 0)
                {
                    var existDetail = await _dbContext.StaffMasters.FindAsync(staffMaster.StaffId);
                    if (existData != null)
                    {
                        staffMaster.Password = staffMaster.Password;
                        _dbContext.StaffMasters.Update(staffMaster);
                        await _dbContext.SaveChangesAsync();
                        return Ok(new { Status = "OK", Result = "Update Successfully Saved" });
                    }
                    else
                    {
                        return Ok(new { Status = "Fail", Result = "Not Found" });
                    }
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
        [Route("List")]
        public async Task<IActionResult> getStaffMaster()
        {
            try
            {
                var Data = await _dbContext.StaffMasters.ToListAsync();
                return Ok(new { Status = "OK", Result = Data });
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
            }
        }
        [HttpGet]
        [Route("Details/{Id}")]
        public async Task<IActionResult> getDetails(int? Id)
        {
            try
            {
                var Data = await _dbContext.StaffMasters.Where(o => o.StaffId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    return Ok(new { Status = "OK", Result = Data });
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

        [HttpGet]
        [Route("Remove/{Id}")]
        public async Task<IActionResult> deleteCategory(int? Id)
        {
            try
            {
                var Data = await _dbContext.StaffMasters.Where(o => o.StaffId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.StaffMasters.Remove(Data);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "OK", Result = "Deleted Successfully" });
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

    }
}
