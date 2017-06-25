using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebStore2.Web.Models
{
    public class Product
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", Category, Name);
        }
    }
}