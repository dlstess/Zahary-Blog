<<<<<<< HEAD
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
=======
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e

namespace Blog.Models
{
    public class Article
    {
<<<<<<< HEAD
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
=======

        private ICollection<Tag> tags;
        public Article()
        {
            this.tags = new HashSet<Tag>();
        }

        

        public Article(string authorId, string title, string content, int categoryId)
        {
            this.AuthorId = authorId;
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.tags = new HashSet<Tag>();
        }

        [Key]
        public int Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Title { get; set; }

>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        public string Content { get; set; }

        [ForeignKey("Author")]
        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

<<<<<<< HEAD
=======
        // Every article should have categoryId
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Tag> Tags
        {
            //get; set;
            get { return this.tags; }
            set { this.tags = value; }
        }

>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        public bool IsAuthor(string name)
        {
            return this.Author.UserName.Equals(name);
        }
<<<<<<< HEAD
    }
}
=======


    }
}
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
