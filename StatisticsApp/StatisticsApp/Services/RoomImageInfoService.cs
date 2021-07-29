using StatisticsApp.Domain;
using StatisticsApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsApp.Services
{
    public class RoomImageInfoService : IRoomImageInfoService
    {
        private readonly IRoomImageInfoRepository _roomImageInfoRepository;

        public RoomImageInfoService(IRoomImageInfoRepository roomImageInfoRepository)
        {
            _roomImageInfoRepository = _roomImageInfoRepository;
        }
        public Task<int> CreateRoomImageInfoAsync(RoomImageInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
