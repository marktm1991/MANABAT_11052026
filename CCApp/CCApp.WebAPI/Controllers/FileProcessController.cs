using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.IO;
using System.Text;

namespace CCApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileProcessController : ControllerBase
    {
        private readonly ILogger<FileProcessController> _logger;
        public FileProcessController(ILogger<FileProcessController> logger)
        {
            _logger = logger;
        }

        [HttpPost("SaveFile")]
        public IActionResult SaveFile(string filePath)
        {
            HttpResponseMessage? response = null;
            string responseStatues = "";

            try
            {
                if (!System.IO.File.Exists(filePath))
                {
                    _logger.LogError("CSV File does not exist.");
                    responseStatues = "error";
                }
                else
                {
                    responseStatues = "success";
                }


            }
            catch (Exception ex)
            {

                _logger.LogError("An error occured in uploading the file. error description: {0}", ex.Message);
                responseStatues = "error";
            }
            finally
            {
                response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(string.Concat("{\"status\":\"{0}\"}", responseStatues), Encoding.UTF8, "application/json")
                };
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet("GetTotalAmount")]
        public IActionResult GetTotalAmount()
        {
            HttpResponseMessage? response = null;
            string responseStatues = "";

            try
            {
                responseStatues = "success";
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occured in getting total amount. error description: {0}", ex.Message);
                responseStatues = "error";
            }
            finally
            {
                response = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(string.Concat("{\"status\":\"{0}\"}", responseStatues), Encoding.UTF8, "application/json")
                };
            }

            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}
