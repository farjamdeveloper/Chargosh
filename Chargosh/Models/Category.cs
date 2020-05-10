using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chargosh.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Display(Name = "دسته بندی")]
        [Required]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}