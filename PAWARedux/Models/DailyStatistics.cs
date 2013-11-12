using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PAWARedux.Models
{
    public class DailyStatistics
    {
        public int DailyStatisticsID { get; set; }
        public DateTime Date { get; set; }
        public int? UsersAddedCount { get; set; }
        public int? UsersLostCount { get; set; }
        public int? ImagesAddedCount { get; set; }
        public int? ImagesLostCount { get; set; }
        public int? VideosAddedCount { get; set; }
        public int? VideosLostCount { get; set; }
    }
}