using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    public partial class HeaderVM
    {
        public string IDocNo { get; set; }
        public string IDOCType { get; set; }
        public DateTime OutDate { get; set; }
        public string SITECode { get; set; }

        public List<BodyVM> Body { get; set; }
       
    }
}
