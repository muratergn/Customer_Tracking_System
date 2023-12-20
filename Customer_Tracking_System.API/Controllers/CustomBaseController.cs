using Customer_Tracking_System.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Customer_Tracking_System.API.Controllers
{
    public class CustomBaseController : ControllerBase
    {
       [NonAction]
       public IActionResult CreateIActionResult<T>(CustomResponseDto<T> response)
       {
           if(response.StatusCode == 204)
           {
               return new ObjectResult(null)
               { 
                   StatusCode= response.StatusCode 
               };
           }

           return new ObjectResult(response)
           { 
               StatusCode= response.StatusCode 
           };
       }
    }
}
