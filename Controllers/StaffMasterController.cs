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
                var exist = await _dbContext.StaffMasters.ToListAsync();

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


        [HttpPost]
        [Route("AuthenticationStaff")]
        public async Task<IActionResult> Authentication(Authentication staff)
        {
            try
            {
                AESCrypto aESCrypto = new AESCrypto();

                // ✅ Check if FullName exists
                var existingStaff = await _dbContext.StaffMasters
                                                    .Where((o => o.FullName == staff.UserName))
                                                    .FirstOrDefaultAsync();

                if (existingStaff != null)
                {
                    // ✅ Decrypt the password from the database
                    var decryptedPassword = aESCrypto.Decrypt(existingStaff.Password);

                    // ✅ Compare decrypted password with entered password
                    if (decryptedPassword == staff.Password)
                    {
                        var data = new
                        {
                            existingStaff.FullName,
                            existingStaff.StaffId,
                            existingStaff.Category
                        };

                        return Ok(new { status = "OK", result = data });
                    }
                    else
                    {
                        return Ok(new { status = "Fail", result = "Wrong Password" });
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



        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(StaffMaster staffMaster)
        {
            try
            {
                var existingStaff = await _dbContext.StaffMasters.AsNoTracking() // ✅ Prevent Tracking Conflict
                                                                 .FirstOrDefaultAsync(x => x.StaffId == staffMaster.StaffId);

                if (existingStaff != null)
                {
                    _dbContext.Entry(staffMaster).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { status = "OK", message = "Updated Successfully." });
                }
                else
                {
                    return BadRequest(new { status = "Error", message = "Staff not found." });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { status = "Error", message = ex.Message });
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
        [Route("ForgotPasswd/{FullName}")]
        public async Task<IActionResult> ForgotPasswd(string FullName)
        {
            try
            {
                var exisData = await _dbContext.StaffMasters.Where(o => o.FullName == FullName).FirstOrDefaultAsync();
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

        [HttpGet]
        [Route("EncPasswd/{Passwd}")]
        public IActionResult encPasswd(string Passwd)
        {
            AESCrypto aESCrypto = new AESCrypto();
            return Ok(new { Password = aESCrypto.Encrypt(Passwd) });
        }

        [HttpGet]
        [Route("DycPasswd/{Passwd}")]
        public IActionResult DycPasswd(string Passwd)
        {
            AESCrypto aESCrypto = new AESCrypto();
            return Ok(new { Password = aESCrypto.Decrypt(Passwd) });
        }

        //[HttpPost]
        //[Route("ChangePassword")]
        //public async Task<IActionResult> changePassword(StaffMaster Model)
        //{
        //    try
        //    {
        //        var ExistData = await _dbContext.StaffMasters.FindAsync(Model.StaffId);
        //        if (ExistData != null)
        //        {
        //            if (ExistData.Password == Model.OldPassword)
        //            {
        //                ExistData.Password = Model.NewPassword;
        //                _dbContext.StaffMasters.Update(ExistData);
        //                await _dbContext.SaveChangesAsync();
        //                return Ok(new { Status = "Ok", Result = "Password Change Successfully" });
        //            }
        //            else
        //            {
        //                return Ok(new { Status = "Fail", Result = "Old Password is Incorrect" });

        //            }
        //        }
        //        else
        //        {
        //            return Ok(new { Status = "Fail", Result = "Not Found" });
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });

        //    }
        //}
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> changePassword(StaffMaster Model)
        {
            try
            {
                var ExistData = await _dbContext.StaffMasters.FindAsync(Model.StaffId);
                AESCrypto aESCrypto = new AESCrypto();
                var encPasswd = aESCrypto.Encrypt(Model.OldPassword);   


                if (ExistData != null)
                {
                    if (ExistData.Password == encPasswd)
                    {
                        ExistData.Password = aESCrypto.Encrypt(Model.NewPassword);
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
