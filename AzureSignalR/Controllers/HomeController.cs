using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AzureSignalR.SignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace AzureSignalR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private IHubContext<SimpleNotificationsHub> _hub;
        public HomeController(ILogger<HomeController> logger, IHubContext<SimpleNotificationsHub> context)
        {
            _logger = logger;
            _hub = context;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new[] { "" };
        }


        [HttpGet("SendMessage/{message}")]
        public async Task<ActionResult>SendMessage(string message)
        {
            await _hub.Clients.All.SendAsync("broadcastMessage", message);
            return Ok();
        }
    }
}
