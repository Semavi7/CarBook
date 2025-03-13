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
        public int carCountByTramissionIsAuto { get; set; }
        public int carCountByKmSmallerThen1000 { get; set; }
        public int getCarCountByFuelGasolineOrDisel { get; set; }
        public int carCountByFuelElectric { get; set; }
        public string carBrandAndModelByRentPriceMax { get; set; }
        public string carBrandAndModelByRentPriceDailyMin { get; set; }
    }
}
