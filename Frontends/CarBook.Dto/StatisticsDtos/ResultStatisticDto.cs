using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticsDtos
{
    public class ResultStatisticDto
    {
        public int carCount { get; set; }
        public int locationCount { get; set; }
        public int authorCount { get; set; }
        public int blogCount { get; set; }
        public int brandCount { get; set; }
        public decimal avgPriceDaily { get; set; }
        public decimal avgRentPriceForWeekly { get; set; }
        public decimal avgRentPriceForMonthly { get; set; }
    }
}
