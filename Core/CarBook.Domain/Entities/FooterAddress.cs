using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class FooterAddress
    {
        public int FooterAddressID { get; set; }
        public int Description { get; set; }
        public int Address { get; set; }
        public int Phone { get; set; }
        public int Email { get; set; }
    }
}
