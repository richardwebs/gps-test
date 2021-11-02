﻿using gps.codingtest.core.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace gps.codingtest.api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }          

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetStatus([FromRoute] Guid id)
        {
            return await Task.Run(() => Ok(_statusService.GetStatus(id)));            
        }        
    }
}