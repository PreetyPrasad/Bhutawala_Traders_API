using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
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
                if (!_dbContext.StaffMasters.Any(o => o.FullName == staffMaster.FullName))
                {
                    _dbContext.StaffMasters.Add(staffMaster);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Successfully Saved" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Already Exists" });
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
                if (!_dbContext.StaffMasters.Any(o => o.FullName == staffMaster.FullName ))
                {
                    _dbContext.StaffMasters.Update(staffMaster);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "OK", Result = "Successfully Saved" });
                }
                else
                {
                    return Ok(new { Status = "Fail", Result = "Already Exists" });
                }
            }
            catch (Exception ex)
            {
                return Ok(new { Status = "Fail", Result = "Error: " + ex.Message });
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
