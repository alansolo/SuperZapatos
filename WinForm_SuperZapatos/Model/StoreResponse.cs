using System;
using System.Collections.Generic;
using System.Text;

namespace WinForm_SuperZapatos.Model
{
    public class StoreResponse
    {
        public bool success { get; set; }
        public int error_code { get; set; }
        public string error_msg { get; set; }
        public int total_elements { get; set; }
        /*public ICollection<Stores> stores { get; set; }*/
    }
}
