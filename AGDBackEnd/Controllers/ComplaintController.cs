using Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace Api.Controllers
{
    [ApiController]
    [Route("Complaint")]
    public class ComplaintController : ControllerBase
    {
       public async Task<IActionResult> CreateComplaint([FromBody] Complaint complaint)
       {
            try
            {

            }
            catch(Exception ex)
            {
                return new StatusCodes(HttpStatusCode.InternalServerError,ex.Message)
            }
       }
    }
}
