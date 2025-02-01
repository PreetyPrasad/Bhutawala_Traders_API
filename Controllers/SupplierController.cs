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
        [Route("Save")]
        public async Task<IActionResult> AddSupplier(Supplier supplier)
        {
            try
            {
                var existData = await _dbContext.Suppliers.ToListAsync();
                List<string> errors = new List<string>();

                if (existData.Any(o=> o.ContactNo == supplier.ContactNo)) {
                    errors.Add("Contact No. is Exists");
                }

                if (existData.Any(o => o.AccountNo == supplier.AccountNo))
                {
                    errors.Add("Account No. is Exists");
                }

                if (existData.Any(o => o.GSTIN == supplier.GSTIN))
                {
                    errors.Add("GST No. is Exists");
                }

                if (existData.Any(o => o.PAN == supplier.PAN))
                {
                    errors.Add("PAN No. is Exists");
                }

                if ( supplier.Email != null) {
                    if (existData.Any(o => o.Email == supplier.Email))
                    {
                        errors.Add("PAN No. is Exists");
                    }
                }
                
                if (errors.Count == 0) {
                    _dbContext.Suppliers.Add(supplier);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Successfully Saved" });
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
        [Route("EditSupplier")]
        public async Task<IActionResult> EditSupplier(Supplier supplier)
        {
            try
            {
                var existData = await _dbContext.Suppliers.Where(o=> o.SupplierId != supplier.SupplierId).ToListAsync();
                List<string> errors = new List<string>();

                if (existData.Any(o => o.ContactNo == supplier.ContactNo))
                {
                    errors.Add("Contact No. is Exists");
                }

                if (existData.Any(o => o.AccountNo == supplier.AccountNo))
                {
                    errors.Add("Account No. is Exists");
                }

                if (existData.Any(o => o.GSTIN == supplier.GSTIN))
                {
                    errors.Add("GST No. is Exists");
                }

                if (existData.Any(o => o.PAN == supplier.PAN))
                {
                    errors.Add("PAN No. is Exists");
                }

                if (supplier.Email != null)
                {
                    if (existData.Any(o => o.Email == supplier.Email))
                    {
                        errors.Add("Email is Exists");
                    }
                }

                if (errors.Count == 0)
                {
                    _dbContext.Suppliers.Update(supplier);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "Ok", Result = "Successfully Saved" });
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
