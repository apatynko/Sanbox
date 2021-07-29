using AspNetCoreDapperCrudDemo.Repositories;
using Microsoft.Extensions.Configuration;
using StatisticsApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsApp.Repositories
{
    public class RoomImageInfoRepository : BaseRepository, IRoomImageInfoRepository
    {
        public RoomImageInfoRepository(IConfiguration configuration)
            : base(configuration)
        { }
        public Task<int> CreateAsync(RoomImageInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
