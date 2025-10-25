using Application;
using Application.Interface.UseCase.Partner;
using Application.Models;
using Application.ResultPattern;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace AGDBackEnd.Controllers;

[ApiController]
[Route("Partner")]
public class PartnerController : ControllerBase
{
    private readonly IInsertPartnerCase _insertPartnerCase;
    private readonly IDeletePartnerCase _deletePartnerCase;
    private readonly IGetPartnerByEmailCase _getPartnerByEmail;

    public PartnerController(IInsertPartnerCase insertPartnerCase, IDeletePartnerCase deletePartnerCase, IGetPartnerByEmailCase getPartnerByEmailCase)
    {
        _insertPartnerCase = insertPartnerCase;
        _deletePartnerCase = deletePartnerCase;
        _getPartnerByEmail = getPartnerByEmailCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetPartner([FromQuery][RegularExpression(Constantes.RegexEmail, ErrorMessage = "O Email infomado deve ser valido")] string email)
    {
        try
        {
            Result result = await _getPartnerByEmail.ExecuteAsync(email);

            if (result.IsSuccess && result.Data is Partner)
                return base.Ok(result.Data);

            if (result.IsSuccess)
                return NoContent();

            return BadRequest(result.Data);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task <IActionResult> InsertPartner([FromBody] Partner body)
    {
        try
        {
            Result result = await _insertPartnerCase.ExecuteAsync(body);

            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest(result.Data);
        }
        catch (Exception ex)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{email}")]
    public async Task<IActionResult> DeletePartner([FromRoute][RegularExpression(Constantes.RegexEmail, ErrorMessage = "O email infomado deve ser valido")] string email)
    {
        try
        {
            Result result = await _deletePartnerCase.ExecuteAsync(email);

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
