using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

<<<<<<< HEAD
        public string Content { get; set; }

        [Required]
        public string AuthorId { get; set; }
=======
        [Required]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        //public ICollection<Category> Categories { get; set; }

        public List<Category> Categories { get; set; }

        public string Tags { get; set; }
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
    }
}