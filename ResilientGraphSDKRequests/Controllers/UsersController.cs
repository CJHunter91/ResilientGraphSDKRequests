using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ResilientGraphSDKRequests.ServiceClients;

namespace ResilientGraphSDKRequests.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IMSGraphServiceClientAdaptor _graphClient;

        public UsersController(ILogger<UsersController> logger, IMSGraphServiceClientAdaptor graphClient)
        {
            _logger = logger;
            _graphClient = graphClient;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var userNames = await _graphClient.GetUsers();
            return Ok(userNames);
        }

        [HttpGet]
        [Route("/users/{userId}")]
        public async Task<IActionResult> GetById([FromRoute] string userId)
        {
            var userNames = await _graphClient.GetUserById(userId);
            return Ok(userNames);
        }
    }
}
