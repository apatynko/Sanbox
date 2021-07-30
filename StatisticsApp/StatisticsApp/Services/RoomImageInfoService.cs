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
        private readonly ILogger _logger;

        public RoomImageInfoService(IRoomImageInfoRepository roomImageInfoRepository, ILogger logger)
        {
            _roomImageInfoRepository = roomImageInfoRepository;
            _logger = logger;
        }
        public async Task CreateRoomImageInfoAsync(RoomImageInfo roomImageInfo)
        {
            await _roomImageInfoRepository.CreateAsync(roomImageInfo);
        }
    }
}
