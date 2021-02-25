using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Amarinfinancial.Models
{
    public class Finance
    {
        [Key]
        public int MembersID { get; set; }
        [Column(TypeName ="nvarchar(250)")]

        [Required(ErrorMessage ="This field is required")]

    

        public string Members { get; set; }
        [Column(TypeName = "nvarchar(50)")]

        public string groups { get; set; }
        [Column(TypeName = "nvarchar(100)")]

        public string transactions { get; set; }
       // [Column("nvarchar(100)")]
    }
}
