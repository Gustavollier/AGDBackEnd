using Application.Interface.UseCase.Complaint;
using Application.Models;
using Application.ResultPattern;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers;

[ApiController]
[Route("Complaint")]
public class ComplaintController : ControllerBase
{
    private readonly IInsertComplaintCase _insertComplaintCase;

    public ComplaintController(IInsertComplaintCase insertComplaintCase)
    {
        _insertComplaintCase = insertComplaintCase;
    }

    [HttpPost]
    public async Task<IActionResult> CreateComplaint([FromBody] Complaint complaint)
    {
        try
        {
            Result result = await _insertComplaintCase.ExecuteAsync(complaint);
            
            if(result.IsSuccess)
                return Ok(result.Data);
            
            return BadRequest(result.Data);
        }
        catch(Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
   }
}
