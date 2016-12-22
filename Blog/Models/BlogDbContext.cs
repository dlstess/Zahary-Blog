<<<<<<< HEAD
﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Blog.Models
{
=======
﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Blog.Models
{

>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Article> Articles { get; set; }

<<<<<<< HEAD
=======
        public virtual IDbSet<Category> Categories { get; set; }

        public virtual IDbSet<Tag> Tags { get; set; }

>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        public static BlogDbContext Create()
        {
            return new BlogDbContext();
        }
    }
}