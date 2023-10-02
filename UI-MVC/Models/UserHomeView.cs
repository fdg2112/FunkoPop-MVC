using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI_MVC.Models
{
	public class UserHomeView
	{
        public List<Product> AllProducts { get; set; }
        public List<Collection> AllCollections { get; set; }
    }
}