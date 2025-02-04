using Bhutawala_Traders_API.ApplicationContext;
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
        [Route("InsertCreditNote")]
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

        [HttpPut]
        [Route("EditCreditNote")]
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
        [Route("AllCreditNote")]
        public async Task<IActionResult> getCreditNote()
        {
            try
            {
                var Data = await _dbContext.CreditNotes.ToArrayAsync();
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
                var Data = await _dbContext.CreditNotes.Where(o => o.CreditNoteId == Id).FirstOrDefaultAsync();

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
    }
}
