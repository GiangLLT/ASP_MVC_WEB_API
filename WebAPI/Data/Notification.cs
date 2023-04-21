using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebAPI
{
    public partial class Notification
    {
        public string Type { get; set; }
        public string Message { get; set; }
    }
}
