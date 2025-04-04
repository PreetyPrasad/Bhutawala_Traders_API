﻿using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bhutawala_Traders_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditNoteController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public CreditNoteController(ApplicationDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpPost]
        [Route("Save")]
        public async Task<IActionResult> Add(CreditNote creditNote)
        {
            try
            {

                if (!_dbContext.CreditNotes.Any(o => o.CreditNoteId == creditNote.CreditNoteId))
                {
                    _dbContext.CreditNotes.Add(creditNote);
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
        public async Task<IActionResult> EditCreditNote(CreditNote creditNote)
        {
            try
            {
                if (!_dbContext.CreditNotes.Any(o => o.CreditNoteId == creditNote.CreditNoteId))
                {
                    _dbContext.CreditNotes.Update(creditNote);
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
        public async Task<IActionResult> getCreditNote()
        {
            try
            {
                var Data = await (from A in _dbContext.CreditNotes
                                  join B in _dbContext.InvoiceMasters on A.InvoiceId equals B.InvoiceId
                                  select new
                                  {
                                      A.CreditNoteId,
                                      A.NoteNo,
                                      A.InvoiceId,
                                      A.Amount, 
                                      A.NoteDate,
                                      A.StaffId,
                                      B.InvoiceDate,
                                      B.InvoiceNo,
                                      B.GST,
                                      B.Total
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
                var Data = await _dbContext.CreditNotes.Where(o => o.CreditNoteId == Id && !(_dbContext.ApplyCredits.Select(A=> A.CreditNoteId).Contains(o.CreditNoteId))).FirstOrDefaultAsync();

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
        public async Task<IActionResult> deleteCreditNote(int? Id)
        {
            try
            {
                var Data = await _dbContext.CreditNotes.Where(o => o.CreditNoteId == Id).FirstOrDefaultAsync();

                if (Data != null)
                {
                    _dbContext.CreditNotes.Remove(Data);
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

        [HttpGet]
        [Route("Verify/{Id}")]
        public async Task<IActionResult> Verify(int? Id)
        {
            try
            {
                var Data = await _dbContext.CreditNotes.Where(o => o.CreditNoteId == Id).FirstOrDefaultAsync();
                if (Data != null)
                {

                    var appliedCreditNote = await _dbContext.ApplyCredits.Where(o => o.CreditNoteId == Id).FirstOrDefaultAsync();
                    if (appliedCreditNote == null)
                    {
                        return Ok(new { Status = "OK", Result = Data });
                    }
                    else
                    {
                        return Ok(new { Status = "Fail", Result = "Already Applied" });
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
