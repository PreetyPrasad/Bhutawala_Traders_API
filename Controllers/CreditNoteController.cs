using Bhutawala_Traders_API.ApplicationContext;
using Bhutawala_Traders_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AddCreditNote(CreditNote creditNote)
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

    }
}
