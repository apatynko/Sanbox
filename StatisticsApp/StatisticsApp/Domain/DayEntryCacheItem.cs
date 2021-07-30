using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsApp.Domain
{
    public readonly struct DayEntryCacheItem
    {
        public int? Id { get; }
        public int? ProjectId { get; }
        public DateTime Day { get; }

        public DayEntryCacheItem(int? id, int? projectId, DateTime day)
        {
            this.Id = id;
            this.ProjectId = projectId;
            this.Day = day;
        }
    }
}
