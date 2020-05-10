using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Chargosh.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name = "نام محصول")]
        [Required]
        public string ProductName { get; set; }
        [Display(Name = "عنوان")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "قیمت")]
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "توضیحات")]
        [Required]
        public string Description { get; set; }
        [Display(Name = "پسندیده")]
        [Required]
        public int Like { get; set; }
        [Display(Name = "درصد تخفیف")]
        [Required]
        public int SalePercent { get; set; }
        [Display(Name = "آدرس عکس")]
        [Required]
        public string ImageProduct { get; set; }
        [Display(Name = "تاریخ ثبت")]
        [Required]
        public DateTime DateAdded { get; set; }
        [Display(Name = "تگ")]
        [Required]
        public string Tag { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Categories { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }
        
    }
}