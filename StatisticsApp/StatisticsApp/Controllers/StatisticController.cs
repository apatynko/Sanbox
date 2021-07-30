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

        public StatisticController(IRoomImageInfoService roomImageInfoService)
        {
            this._roomImageInfoService = roomImageInfoService;
        }

        [HttpPut]
        public async Task<IActionResult> PutRoomImageInfo(RoomImageInfo roomImageInfo)
        {
            
            try
            {
                if (ModelState.IsValid)
                {
                    // put roomimage info
                    await _roomImageInfoService.CreateRoomImageInfoAsync(roomImageInfo);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return Ok();
        }
    }
}
