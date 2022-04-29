using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Dynamic;

namespace NetCore5API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]
        public string GetSystemDetails()
        {
            dynamic response = new ExpandoObject();
            response.HostName = Environment.MachineName;
            response.LocalIPAddress = Request.HttpContext.Connection.LocalIpAddress.ToString();
            response.LocalPort= Request.HttpContext.Connection.LocalPort.ToString();
            response.RemoteIpAddress= Request.HttpContext.Connection.RemoteIpAddress.ToString();
            response.RemotePort = Request.HttpContext.Connection.RemotePort.ToString();
            response.RequestHeaders = Request.HttpContext.Request.Headers;
            response.EnvVariables = Environment.GetEnvironmentVariables(EnvironmentVariableTarget.Process);
            return JsonConvert.SerializeObject(response);
        }
    }
}
