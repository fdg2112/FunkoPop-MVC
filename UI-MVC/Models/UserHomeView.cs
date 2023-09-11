using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_MVC.Models
{
	public class UserHomeView
	{
        public IEnumerable<Product> ProductsAZ { get; set; }
        public IEnumerable<Product> ProductsZA { get; set; }
        public IEnumerable<Product> ProductsByPriceAsc { get; set; }
        public IEnumerable<Product> ProductsByPriceDesc { get; set; }
        public IEnumerable<Product> ProductsShine { get; set; }
        public Product OneProduct { get; set; }
    }
}