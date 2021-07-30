using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using StatisticsApp.Services;

namespace AspNetCoreDapperCrudDemo.Repositories
{
    public abstract class BaseRepository
    {
        private readonly IConfiguration _configuration;
        private readonly StatisticsApp.Services.ILogger _logger;

        protected BaseRepository(IConfiguration configuration, StatisticsApp.Services.ILogger logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        protected IDbConnection CreateConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        protected ILogger GetLogger()
        {
            return _logger;
        }
    }
}
