using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarBook.Dto.FeatureDtos;

namespace CarBook.Dto.CarFeatureDtos
{
    public class CreateCarFeatureDto
    {
        public List<ResultFeatureWithStatusDto> Features { get; set; }
        public int CarID { get; set; }
    }
}
