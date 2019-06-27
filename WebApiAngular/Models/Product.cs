using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebApiAngular.Models;

namespace project.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public int PriceBeforeDiscount { get; set; }
        public int PriceAfterDiscount { get; set; }
        public float Discount { get; set; }
        public int QuantityInStock { get; set; }
        public string Picture { get; set; }
        public string ProductDiscription { get; set; }

        [ForeignKey("category")]
        public int category_ID { get; set; }
        [JsonIgnore]

        public virtual Category category { get; set; }
      [JsonIgnore]
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }




    }
}