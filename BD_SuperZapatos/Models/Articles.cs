using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BD_SuperZapatos.Models
{
    public class Articles
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string name { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string description { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int total_in_shelf { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int total_in_vault { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public int store_id { get; set; }
        [ForeignKey("store_id")]
        public virtual Stores store { get; set; }
    }
}
