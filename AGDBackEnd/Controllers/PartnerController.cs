using Application.Interface.UseCase.Partner;
using Application.Models;
using Application.Models.Request;
using Application.ResultPattern;
using Application.VOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AGDBackEnd.Controllers;

[ApiController]
[Route("Partner")]
public class PartnerController : ControllerBase
{
    private readonly IInsertPartnerCase _insertPartnerCase;

    public PartnerController(IInsertPartnerCase insertPartnerCase)
    {
        _insertPartnerCase = insertPartnerCase;
    }

    [HttpPost]
    public IActionResult InsertPartner([FromBody] PartnerRequest body)
    {
        try
        {
             Result result = _insertPartnerCase.ExecuteAsync(new Partner(body.Nome, new Email(body.Email)));

            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest(result.Data);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}
