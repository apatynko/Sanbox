using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StatisticsApp.Domain;
using StatisticsApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsApp.Controllers
{
    [ApiController]
    [Route("api/Statistics/projectimage")]
    public class StatisticController : ControllerBase
    {
        private readonly IRoomImageInfoService _roomImageInfoService;
        private readonly StatisticsApp.Services.ILogger _logger;

        public StatisticController(IRoomImageInfoService roomImageInfoService, ILogger logger)
        {
            _roomImageInfoService = roomImageInfoService;
            _logger = logger;
        }

        [HttpPut]
        public async Task<IActionResult> PutRoomImageInfo(RoomImageInfo roomImageInfo)
        {
            
            try
            {
                if (ModelState.IsValid)
                {   
                    roomImageInfo.Ip = Request.HttpContext.Connection.RemoteIpAddress.ToString();                    

                    await _roomImageInfoService.CreateRoomImageInfoAsync(roomImageInfo);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                _logger.LogException(ex);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return BadRequest();
        }
    }
}
