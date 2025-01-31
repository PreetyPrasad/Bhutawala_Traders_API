using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public SupplierController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("InsertPurchaseMaster")]
        public async Task<IActionResult> AddPurchaseMaster(Supplier supplier)
        {
            try
            {
                if (!_dbContext.Suppliers.Any(o => o.SupplierId == supplier.SupplierId))
                {
                    _dbContext.Suppliers.Add(supplier);
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
        [Route("EditSupplier")]
        public async Task<IActionResult> EditSupplier(Supplier supplier)
        {
            try
            {
                if (!_dbContext.Suppliers.Any(o => o.SupplierId == supplier.SupplierId))
                {
                    _dbContext.Suppliers.Update(supplier);
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
        [Route("AllSupplier")]
        public async Task<IActionResult> getSupplier()
        {
            try
            {
                var Data = await _dbContext.Suppliers.ToListAsync();
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
                var Data = await _dbContext.Suppliers.Where(o => o.SupplierId == Id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> deleteSupplier(int? Id)
        {
            try
            {
                var Data = await _dbContext.Suppliers.Where(o => o.SupplierId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.Suppliers.Remove(Data);
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
    }
}
