using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectToIsracard.Models
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public Owner owner { get; set; }
    }
}