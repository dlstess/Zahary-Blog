namespace Blog.Migrations
{
<<<<<<< HEAD
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<BlogDbContext>
=======
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<Blog.Models.BlogDbContext>
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
<<<<<<< HEAD
        }

        protected override void Seed(BlogDbContext context)
        {
            if (!context.Roles.Any())
=======
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Blog_CSharp.Models.BlogDbContext";
        }

        protected override void Seed(Blog.Models.BlogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            if(!context.Roles.Any())
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
            {
                this.CreateRole(context, "Admin");
                this.CreateRole(context, "User");
            }

<<<<<<< HEAD
            if (!context.Users.Any())
=======
            if(!context.Users.Any())
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
            {
                this.CreateUser(context, "admin@admin.com", "Admin", "123");
                this.SetRoleToUser(context, "admin@admin.com", "Admin");
            }
        }

        private void SetRoleToUser(BlogDbContext context, string email, string role)
        {
<<<<<<< HEAD
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var user = context.Users.Where(u => u.Email == email).First();

            var result = userManager.AddToRole(user.Id, role);

            if (!result.Succeeded)
=======
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            var user = context.Users.Where(u => u.Email.Equals(email)).First();

            var result = userManager.AddToRole(user.Id, role);

            if(!result.Succeeded)
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateUser(BlogDbContext context, string email, string fullName, string password)
        {
            // Create user manager
<<<<<<< HEAD
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
=======
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e

            // Set user manager password validator
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireDigit = false,
                RequireLowercase = false,
                RequireNonLetterOrDigit = false,
                RequireUppercase = false,
            };

            // Create user object
            var admin = new ApplicationUser
            {
                UserName = email,
                FullName = fullName,
                Email = email,
            };

<<<<<<< HEAD
            // Create user
            var result = userManager.Create(admin, password);

            // Validate result
            if (!result.Succeeded)
=======
            // create user
            var result = userManager.Create(admin, password);

            // validate result
            if(!result.Succeeded)
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private void CreateRole(BlogDbContext context, string roleName)
        {
<<<<<<< HEAD
            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));
=======
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e

            var result = roleManager.Create(new IdentityRole(roleName));

            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }
<<<<<<< HEAD
=======

>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
    }
}
