using System;
using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
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
        [Route("addAdmin")]
        public async Task<IActionResult> InsertAdmin(Admin admin)
        {
            try
            {
                _dbContext.Admins.Add(admin);
                await _dbContext.SaveChangesAsync();
                return Ok(new { Status = "OK", Result = "Save" });

            }
            catch (Exception Exp)
            {
                return Ok(new { Status = "Fail", Result = Exp.Message });
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


        [HttpGet]
        [Route("adminDetails/{AdminId?}")]
        public async Task<IActionResult> ShowAdmin(int? AdminId)
        {
            if (AdminId != null)
            {
                var data = await _dbContext.Admins.FindAsync(AdminId);
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


        [HttpDelete]
        [Route("deleteAdmin/{AdminId?}")]
        public async Task<IActionResult> RemoveAdmin(int? AdminId)
        {
            try
            {
                var data = await _dbContext.Admins.FindAsync(AdminId);
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
