using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WebAPI
{
    //[Serializable, XmlRoot(ElementName = "HR_OUTBOUND_STAFF_INFO", Namespace = "http://NK.com/PDW/PaymentToSap")]
    //[Serializable, XmlRoot(ElementName = "HR_OUTBOUND_STAFF_INFO", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    [Keyless]
    public class IDoc
    {
        //public string Email { get; set; }
        //[XmlElement("Header")]
        //[XmlArray("Header")]
        //[XmlElement("Header")]

        public List<Header> Header { get; set; }
        //[XmlElement("Body")]
        public List<Body> Body { get; set; }
    }
}

