﻿using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public MaterialController(ApplicationDBContext dBContext)
        {
            _dbContext=dBContext;
        }
        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> AddMaterial(Material material)
        {
            try
            {
                if (!_dbContext.Materials.Any(o => o.MaterialName == material.MaterialName && o.Brand==material.Brand && o.Unit==material.Unit && o.Qty==material.Qty))
                {
                    _dbContext.Materials.Add(material);
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
        public async Task<IActionResult> EditMaterial(Material material)
        {
            try
            {
                var Data = _dbContext.Materials.Find(material.MaterialId);

                if (Data != null)
                {
                    _dbContext.Entry(Data).State = EntityState.Detached;
                    _dbContext.Update(material);
                    await _dbContext.SaveChangesAsync();
                    return Ok(new { Status = "OK", Result = "Successfully Saved" });
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
        [Route("List")]
        public async Task<IActionResult> getMaterial()
        {
            try
            {
                var Data = await _dbContext.Materials.Select(o=> new { 
                    o.MaterialId,
                    o.MaterialName,
                    o.Brand,
                    CategoryDetail = _dbContext.Categories.Where(c => c.CategoryId == o.CategoryId ).FirstOrDefault(),
                    o.Unit,
                    o.Net_Qty,
                    o.GST,
                    o.GST_Type,
                    o.Price,
                    o.Qty,
                    InwardStock = _dbContext.Inwordstocks.Where(X=> X.MaterialId == o.MaterialId).DefaultIfEmpty().Sum(x => (x != null ? x.Qty : 0)),
                    stockSale = _dbContext.InvoiceDetails.Where(X => X.MaterialId == o.MaterialId).DefaultIfEmpty().Sum(x => (x != null ? x.Qty : 0)),
                    returnStock = _dbContext.SellsReturnDetails.Where(X=> X.MaterialId == o.MaterialId).DefaultIfEmpty().Sum(x => (x != null ? x.Qty : 0)),
                    outwardStock = _dbContext.OutwordItems.Where(X => X.MaterialId == o.MaterialId).DefaultIfEmpty().Sum(x => (x != null ? x.Qty : 0)),
                    StaffName=_dbContext.StaffMasters.Where(c => c.StaffId == o.StaffId).Select(c=>c.FullName).FirstOrDefault()
                }).Select(o=> new
                {
                    o.MaterialId,
                    o.MaterialName,
                    o.Brand,
                    o.CategoryDetail,
                    o.Unit,
                    o.Net_Qty,
                    o.GST,
                    o.GST_Type,
                    o.Price,
                    o.Qty,
                    o.InwardStock,
                    o.stockSale,
                    o.returnStock,
                    o.outwardStock,
                    staffName=o.StaffName,
                    Stock = (o.InwardStock + o.returnStock) - (o.stockSale + o.outwardStock)
                }).ToListAsync();
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
                var Data = await _dbContext.Materials.Where(o => o.MaterialId == Id).FirstOrDefaultAsync();

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
        public async Task<IActionResult> deleteMaterial(int? Id)
        {
            try
            {
                var Data = await _dbContext.Materials.Where(o => o.MaterialId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.Materials.Remove(Data);
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
