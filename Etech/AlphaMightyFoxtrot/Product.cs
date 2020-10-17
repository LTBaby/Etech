using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Etech.AlphaMightyFoxtrot
{
    class Product
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public char Active { get; set; }
        public string Description { get; set; }
        public byte [] ImageUrl { get; set; }
        public byte [] ThumbnailUrl { get; set; }
    }
}