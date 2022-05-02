using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetCore5UI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace NetCore5UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration Configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<JsonResult> AjaxMethod(string name)
        {
            using var client = new HttpClient();

            var result = await client.GetAsync(Configuration["API"]);
            var data= JsonConvert.DeserializeObject<SysModel>(result.Content.ReadAsStringAsync().Result);
            Console.WriteLine(result.StatusCode);
            SysModel model = new SysModel
            {
                HostName = data.HostName,
                LocalIPAddress=data.LocalIPAddress,
                LocalPort=data.LocalPort,
                RemoteIpAddress=data.RemoteIpAddress,
                RemotePort=data.RemotePort,
                EnvVariables = data.EnvVariables,
            };

            return Json(model);
        }
    }

    internal class SysModel
    {
        public string HostName { get; set; }
        public string LocalIPAddress { get; set; }

        public string LocalPort { get; set; }

        public string RemoteIpAddress { get; set; }

        public string RemotePort { get; set; }

        public EnvironmentVariables EnvVariables { get; set; }

    }

    public class EnvironmentVariables
    {
        public string DOTNET_RUNNING_IN_CONTAINER { get; set; }
        public string KUBERNETES_PORT_443_TCP_PORT { get; set; }
        public string KUBERNETES_PORT { get; set; }
        public string ASPNET_VERSION { get; set; }
        public string INMEMORYAPISERVICE_SERVICE_HOST { get; set; }
        public string INMEMORYAPISERVICE_PORT { get; set; }
        public string PATH { get; set; }
        public string COREUISERVICE_PORT_8080_TCP_ADDR { get; set; }
        public string COREUISERVICE_SERVICE_HOST { get; set; }
        public string COREUISERVICE_PORT { get; set; }
        public string COREUISERVICE_SERVICE_PORT { get; set; }
        public string INMEMORYAPISERVICE_PORT_8080_TCP { get; set; }
        public string COREUISERVICE_PORT_8080_TCP { get; set; }
        public string INMEMORYAPISERVICE_SERVICE_PORT { get; set; }
        public string HOSTNAME { get; set; }

    }
}
