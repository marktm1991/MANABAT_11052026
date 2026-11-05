using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text;

namespace CCApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessController : ControllerBase
    {
        public IActionResult SaveFile()
        {
            string responseStatues = "success";

            try
            {
                responseStatues = "success";
            }
            catch (Exception ex)
            {
                responseStatues = "error";
            }
            finally
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(string.Concat("{\"status\":\"{0}\"}", responseStatues), Encoding.UTF8, "application/json")
                };

                return StatusCode(StatusCodes.Status200OK, response);
            }
        }
        public IActionResult CalculateTotalAmount()
        {
            try
            {
                responseStatues = "success";
            }
            catch (Exception ex)
            {
                responseStatues = "error";
            }
            finally
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(string.Concat("{\"status\":\"{0}\"}", responseStatues), Encoding.UTF8, "application/json")
                };

                return StatusCode(StatusCodes.Status200OK, response);
            }
        }
    }
}
