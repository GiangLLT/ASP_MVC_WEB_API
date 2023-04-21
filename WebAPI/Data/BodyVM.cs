using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WebAPI
{
    public partial class BodyVM
    {
        public string IDocNo { get; set; }
        public string EmplCode { get; set; }
        public string LastName { get; set; }
        public string FrstName { get; set; }
        public string DptmCode { get; set; }
        public string Job_Cod { get; set; }
        public string PstnCode { get; set; }
        public string CurrShft { get; set; }
        public string EmplType { get; set; }
        public string Beg_Temp { get; set; }
        public string Gender { get; set; }
        public string Birth_dat { get; set; }
        public string Birth_plc { get; set; }
        public string IC_numbr { get; set; }
        public string IC_numbr_dat { get; set; }
        public string R_Street_numbr { get; set; }
        public string R_Prov_ID { get; set; }
        public string R_Prov_DES { get; set; }
        public string R_Dist_ID { get; set; }
        public string R_Dist_DES { get; set; }
        public string R_Wards_ID { get; set; }
        public string R_Wards_DES { get; set; }
        public string Street_numbr { get; set; }
        public string Prov_ID { get; set; }
        public string Prov_DES { get; set; }
        public string Dist_ID { get; set; }
        public string Dist_DES { get; set; }
        public string Wards_ID { get; set; }
        public string Wards_DES { get; set; }
        public string Phone_numbr { get; set; }
        public string Bank_acc_numbr { get; set; }
        public string Bankey_numbr { get; set; }
        public string Bank_name { get; set; }
    }
}
