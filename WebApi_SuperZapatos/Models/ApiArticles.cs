﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi_SuperZapatos.Models
{
    public class ApiArticles
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int total_in_shelf { get; set; }
        public int total_in_vault { get; set; }
        public int store_id { get; set; }
        public string store_name { get; set; }
    }
}
