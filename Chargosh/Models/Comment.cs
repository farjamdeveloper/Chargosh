using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chargosh.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [Display(Name = "نام")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "ایمیل")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "متن نظر")]
        [Required]
        public string Text { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }
    }
}