using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD_SuperZapatos.Models
{
    public class Stores
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string address { get; set; }
    }
}
