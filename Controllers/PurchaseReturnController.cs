﻿using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseReturnController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public PurchaseReturnController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> AddPurchaseReturn(PurchaseReturn purchaseReturn)
        {
            try
            {
                if (!_dbContext.PurchaseReturns.Any(o => o.PurchaseReturnId == purchaseReturn.PurchaseReturnId))
                {
                    _dbContext.PurchaseReturns.Add(purchaseReturn);
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

        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> EditPurchaseReturn(PurchaseReturn purchaseReturn)
        {
            try
            {
                if (!_dbContext.PurchaseReturns.Any(o => o.PurchaseReturnId == purchaseReturn.PurchaseReturnId))
                {
                    _dbContext.PurchaseReturns.Update(purchaseReturn);
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
        public async Task<IActionResult> getPurchaseReturn()
        {
            try
            {
                var Data = await _dbContext.PurchaseReturns.ToArrayAsync();
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
                var Data = await _dbContext.PurchaseReturns.Where(o => o.PurchaseReturnId == Id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> deletePurchaseReturn(int? Id)
        {
            try
            {
                var Data = await _dbContext.PurchaseReturns.Where(o => o.PurchaseReturnId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.PurchaseReturns.Remove(Data);
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
