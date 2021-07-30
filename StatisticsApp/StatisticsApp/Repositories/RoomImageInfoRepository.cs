using AspNetCoreDapperCrudDemo.Repositories;
using Microsoft.Extensions.Configuration;
using StatisticsApp.Domain;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using StatisticsApp.Services;
using System.Globalization;

namespace StatisticsApp.Repositories
{
    public class RoomImageInfoRepository : BaseRepository, IRoomImageInfoRepository
    {        
        private Dictionary<string, int?> _projectEntryCache = new Dictionary<string, int?>();
        private List<DayEntryCacheItem> _dayEntryCache = new List<DayEntryCacheItem>();
        public RoomImageInfoRepository(IConfiguration configuration, ILogger logger)
            : base(configuration, logger)
        {}
        
        public async Task CreateAsync(RoomImageInfo roomImageInfo)
        {
            DateTime dateNow = DateTime.UtcNow;
            long timestamp = new DateTimeOffset(dateNow).ToUnixTimeMilliseconds();
            DateTime dayDate = dateNow.Date;

            int? projectEntryId = null;
            int? dayEntryId = null;

            projectEntryId = await GetProjectEntryIdFromCache(roomImageInfo.ProjectId, roomImageInfo.CustomerId);

            if (projectEntryId != null)
            {
                dayEntryId = await GetDayEntryIdFromCache(projectEntryId, dayDate);
                if (dayEntryId != null)
                {
                    int? timestampEntryId = await InsertTimeStampEntry(dayEntryId, timestamp);
                    await InsertRequestDetailsEntry(timestampEntryId, roomImageInfo.Ip, roomImageInfo.UserAgent, roomImageInfo.RequestString);
                }
            }
        }

        private async Task<int?> InsertRequestDetailsEntry(int? timeStampEntryId, string ipAddress, string userAgent, string requestString)
        {
            int? requestDetailsEntryId = null;
            try
            {
                using (var connection = CreateConnection())
                {
                    requestDetailsEntryId = await connection.ExecuteScalarAsync<int?>("[dbo].[spRequestDetails_Insert]",
                                new { TimeStamp = timeStampEntryId, IpAddress = ipAddress, UserAgent = userAgent, RequestString = requestString },
                                commandType: CommandType.StoredProcedure);
                }                
            }
            catch (Exception ex)
            {                
                var logger = GetLogger();
                logger.LogException(ex);
                
            }
            return requestDetailsEntryId;
        }

        private async Task<int?> InsertTimeStampEntry(int? dayEntryId, long timestamp)
        {
            int? timestampEntryId = null;
            try
            {                
                using (var connection =CreateConnection())
                {
                    timestampEntryId = await connection.ExecuteScalarAsync<int?>("[dbo].[spTimeStamp_Insert]",
                                new { DayId = dayEntryId, TimeStamp = timestamp },
                                commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                var logger = GetLogger();
                logger.LogException(ex);                
            }
            return timestampEntryId;
        }

        private async Task<int?> GetDayEntryIdFromCache(int? projectEntryId, DateTime dayDate)
        {
            int? dayEntryId = null;
            var result = _dayEntryCache
                    .Where(el => el.ProjectId == projectEntryId && DateTime.Compare(el.Day, dayDate) == 0);

            if (_dayEntryCache.Count == 0 || !result.Any())
            {
                dayEntryId = await SelectOrInsertDayEntry(projectEntryId, dayDate);
                _dayEntryCache.Add(new DayEntryCacheItem(dayEntryId, projectEntryId, dayDate));

            }
            else
            {
                dayEntryId = result.FirstOrDefault().Id;
            }
            return dayEntryId;
        }

        private async Task<int?> SelectOrInsertDayEntry(int? projectEntryId, DateTime dayDate)
        {
            int? dayEntryId = null;
            try
            {
                using (var connection = CreateConnection())
                {
                    dayEntryId = await connection.ExecuteScalarAsync<int?>(
                        "[dbo].[spDays_GetIdByProjectIdAndDay]", new { ProjectId = projectEntryId, Day = dayDate.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture) },
                        commandType: CommandType.StoredProcedure);

                    if (dayEntryId == null)
                    {
                        dayEntryId = await connection.ExecuteScalarAsync<int?>("[dbo].[spDays_Insert]",
                                new { ProjectId = projectEntryId, Day = dayDate.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture) },
                                commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = GetLogger();
                logger.LogException(ex);
            }

            return dayEntryId;
        }

        private async Task<int?> GetProjectEntryIdFromCache(string projectId, string customerId)
        {
            int? projectEntryId = null;
            if (!_projectEntryCache.ContainsKey(projectId))
            {
                projectEntryId = await SelectOrInsertProjectEntry(projectId, customerId);
                _projectEntryCache.Add(projectId, projectEntryId);
            }
            else
            {
                projectEntryId = _projectEntryCache[projectId];
            }
            return projectEntryId;
        }

        private async Task<int?> SelectOrInsertProjectEntry(string projectId, string customerId)
        {
            int? projectEntryId = null;
            try
            {
                using (var connection = CreateConnection())
                {
                    projectEntryId = await connection.ExecuteScalarAsync<int?>(
                        "[dbo].[spProjects_GetIdByProjectId]", new { ProjectId = projectId },
                        commandType: CommandType.StoredProcedure);
                    if (projectEntryId == null)
                    {
                        projectEntryId = await connection.ExecuteScalarAsync<int?>("[dbo].[spProjects_Insert]",
                            new { CustomerId = customerId, ProjectId = projectId },
                            commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = GetLogger();
                logger.LogException(ex);
            }

            return projectEntryId;
        }


    }
}
