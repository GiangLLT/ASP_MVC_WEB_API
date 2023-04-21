using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
{
    public class WebAPI
    {
        public int ID { get; set; }
        public int Sale_Order { get; set; }
        public DateTime Document_Date { get; set; }
        public int Customer { get; set; }
        public string Description { get; set; } = string.Empty;
    }
}
