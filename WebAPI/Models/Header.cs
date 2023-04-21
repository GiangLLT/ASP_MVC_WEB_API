using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
    [Table("Idoc_Header")]
    [DataContract]
    public partial class Header
    {
        [Key]
        [DataMember]
        public string IDocNo { get; set; }

        [Required]
        [DataMember]
        public string IDOCType { get; set; }

        [Required]
        [DataMember]
        public DateTime OutDate { get; set; }

        [Required]
        [MaxLength(4)]
        [IgnoreDataMember]
        //[DataMember(Name = "Site")]
        public string SITECode { get; set; }

        //public List<Body> Body { get; set; }

        public ICollection<Body> Body { get; set; }
        public Header()
        {
            Body = new List<Body>();
        }
    }
}
