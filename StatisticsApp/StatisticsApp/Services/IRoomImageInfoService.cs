using StatisticsApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsApp.Services
{
    public interface IRoomImageInfoService
    {
        public Task CreateRoomImageInfoAsync(RoomImageInfo entity);
    }
}
