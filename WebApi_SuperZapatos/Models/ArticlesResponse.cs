using BD_SuperZapatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_SuperZapatos.Models
{
    public class ArticlesResponse
    {
        public bool success { get; set; }
        public int error_code { get; set; }
        public string error_msg { get; set; }
        public int total_elements { get; set; }
        public ICollection<ApiArticles> articles { get; set; }
    }
}
