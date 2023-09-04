using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UI_MVC.Models
{
    public class ProductView
    {
        [Key]
        public int Id { get; set; }
        public int Catalog_number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public bool Shine { get; set; }
        public int? Collection_id { get; set; }
        public bool Active { get; set; }
        public string Url_image { get; set; }
        public string Ref_image { get; set; }
    }
}