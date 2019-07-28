using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectToIsracard.Models
{
    public class Repository
    {
        public int total_count { get; set; }
        public List<Item> items { get; set; }
    }
}