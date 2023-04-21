using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System;

namespace WebAPI.Models
{
    [Table("Admin_users")]
    [DataContract]
    public class Model_API_Users
    {

        [Key]
        [DataMember]
        public string ID_user { get; set; }

        //[Required]
        [MaxLength(200)]
        [DataMember]
        public string Mail { get; set; }


        [MaxLength(100)]
        [DataMember]
        public string Password { get; set; }

        //[Required]
        [MaxLength(100)]
        [DataMember]
        public string FullName { get; set; }

        //[Required]
        [MaxLength(100)]
        [DataMember]
        public string displayName { get; set; }
        

        [DataMember]
        public DateTime? Birthday { get; set; }


        [MaxLength(50)]
        [DataMember]
        public string Acc_Type { get; set; }


        [MaxLength(50)]
        [DataMember]
        public string Address { get; set; }

        [MaxLength(50)]
        [DataMember]
        public string Jobtitle { get; set; }


        [DataMember]
        public int? Phone { get; set; }


        [MaxLength(1000)]
        [DataMember]
        public string Avatar { get; set; }

        [DataMember]
        public bool? User_Status { get; set; }

    }
}
