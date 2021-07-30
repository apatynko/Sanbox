using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticsApp.Domain
{
    public class RoomImageInfo: BaseEntity
    {
        public string CustomerId { get; set; }
        public string ProjectId { get; set; }
        public string Ip { get; set; }
        public string UserAgent { get; set; }
        public string RequestString { get; set; }
    }
}
