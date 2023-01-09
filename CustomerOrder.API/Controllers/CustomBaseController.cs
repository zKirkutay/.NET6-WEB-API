using CustomerOrder.Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CustomerOrder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDTO<T> reponse)
        {
            if (Response.StatusCode == (int)HttpStatusCode.NoContent)
            {
                return new ObjectResult(null)
                {
                    StatusCode = Response.StatusCode
                };
            }
            return new ObjectResult(reponse)
            {
                StatusCode = Response.StatusCode
            };
        }
    }
}
