using Blog.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
<<<<<<< HEAD
=======
using System.Data.Entity.Validation;
using System.Diagnostics;
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

<<<<<<< HEAD
namespace Blog.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        //
        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //
=======

namespace Blog.Controllers.Admin
{
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        //
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        // GET: User/List
        public ActionResult List()
        {
            using (var database = new BlogDbContext())
            {
                var users = database.Users
                    .ToList();

<<<<<<< HEAD
=======
                // using private metod GetAdminUserNames in current controller, for take out names of admins (UserName)
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                var admins = GetAdminUserNames(users, database);
                ViewBag.Admins = admins;

                return View(users);
<<<<<<< HEAD
            }
        }

        //
=======
            }   
        }

        // GET: User
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        private HashSet<string> GetAdminUserNames(List<ApplicationUser> users, BlogDbContext context)
        {
            // Create User Manager
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // Get all user names that are in role "Admin"
            var admins = new HashSet<string>();

            foreach(var user in users)
            {
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    admins.Add(user.UserName);
                }
            }

            // returning the hashSet
            return admins;
        }

        // 
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        // GET: User/Edit
        public ActionResult Edit(string id)
        {
            // Validate Id
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                // Get user from database
                var user = database.Users
<<<<<<< HEAD
                    .Where(u => u.Id == id)
                    .First();

                // Check if user exists
=======
                    .Where(u => u.Id == (id))
                    .First();

                // Check if user exist
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                if (user == null)
                {
                    return HttpNotFound();
                }

                // Create a view model
                var viewModel = new EditUserViewModel();
                viewModel.User = user;
                viewModel.Roles = GetUserRoles(user, database);

                // Pass the model to the view
                return View(viewModel);
<<<<<<< HEAD
            }
        }

=======

            }
        }
        
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        //
        // POST: User/Edit
        [HttpPost]
        public ActionResult Edit(string id, EditUserViewModel viewModel)
        {
<<<<<<< HEAD
            if (ModelState.IsValid)
            {
                using (var db = new BlogDbContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Id.Equals(id));

                    if (user == null)
                    {
                        //
                    }

                    user.Email = viewModel.User.Email;
                    user.FullName = viewModel.User.FullName;
                    user.UserName = viewModel.User.Email;

                    if (!string.IsNullOrEmpty(viewModel.Password))
                    {
                        var passwordHasher = new PasswordHasher();
                        var newPasswordHash = passwordHasher.HashPassword(viewModel.Password);
                        user.PasswordHash = newPasswordHash;
                    }

                    SetUserRoles(user, db, viewModel);

                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("List");
=======
            // Check if model is valid
            if(ModelState.IsValid)
            {
                using (var database = new BlogDbContext())
                {
                    // Get user from database
                    var user = database.Users.FirstOrDefault(u => u.Id == (id));

                    // Check if user exist
                    if(user == null)
                    {
                        return HttpNotFound();
                    }

                    // If password field is not empty, change password
                    if (!string.IsNullOrEmpty(viewModel.Password))
                    {
                        var hasher = new PasswordHasher();
                        var passwordHash = hasher.HashPassword(viewModel.Password);
                        user.PasswordHash = passwordHash;
                    }

                    // Set user properties
                    user.Email = viewModel.User.Email;
                    user.FullName = viewModel.User.FullName;
                    user.UserName = viewModel.User.Email;
                    SetUserRoles(viewModel, user, database);

                    // Save changes
                    database.Entry(user).State = EntityState.Modified;
                    try
                    {
                        database.SaveChanges();
                    }
                    catch (DbEntityValidationException e)
                    {
                        foreach (var eve in e.EntityValidationErrors)
                        {
                            Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                eve.Entry.Entity.GetType().Name, eve.Entry.State);
                            foreach (var ve in eve.ValidationErrors)
                            {
                                Debug.WriteLine("- Property: \"{0}\", value: \"{1}\", Error: \"{2}\"",
                                    ve.PropertyName,
                                    eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                                    ve.ErrorMessage);
                            }
                        }
                        throw;
                    }
                    
                    

                    return RedirectToAction("List");
                }
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
            }

            return View(viewModel);
        }

        //
        // GET: User/Delete
        public ActionResult Delete(string id)
        {
<<<<<<< HEAD
            if (id == null)
=======
            if(id == null)
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                // Get user from database
                var user = database.Users
<<<<<<< HEAD
                    .Where(u => u.Id.Equals(id))
                    .First();

                // Check if user exists
                if (user == null)
=======
                    .Where(u => u.Id == id)
                    .First();

                // Check if user exist
                if(user == null)
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                {
                    return HttpNotFound();
                }

                return View(user);
<<<<<<< HEAD
            }
=======
            }  
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        }

        //
        // POST: User/Delete
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
<<<<<<< HEAD
            if (id == null)
=======
            if(id == null)
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
<<<<<<< HEAD
                // Get user from database
                var user = database.Users
                    .Where(u => u.Id.Equals(id))
=======

                // Get user from datatabase
                var user = database.Users
                    .Where(u => u.Id == (id))
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                    .First();

                // Get user articles from database
                var userArticles = database.Articles
<<<<<<< HEAD
                    .Where(a => a.Author.Id == user.Id);

                // Delete user articles
                foreach (var article in userArticles)
=======
                    .Where(a => a.Author.Id.Equals(user.Id));


                // Delete user articles
                foreach(var article in userArticles)
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                {
                    database.Articles.Remove(article);
                }

                // Delete user and save changes
                database.Users.Remove(user);
                database.SaveChanges();

                return RedirectToAction("List");
            }
        }

<<<<<<< HEAD
        private HashSet<string> GetAdminUserNames(List<ApplicationUser> users, BlogDbContext context)
        {
            var admins = new HashSet<string>();

            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            foreach (var user in users)
            {
                if (userManager.IsInRole(user.Id, "Admin"))
                {
                    admins.Add(user.UserName);
                }
            }

            return admins;
        }

        private void SetUserRoles(ApplicationUser user, BlogDbContext db, EditUserViewModel model)
        {
=======
        // Private method GetUserRoles for method Edit
        // To fill the view with users roles
        
        private List<Role> GetUserRoles(ApplicationUser user, BlogDbContext db)
        {
            // Create user manager
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
            var userManager = Request
                .GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

<<<<<<< HEAD
            foreach (var role in model.Roles)
            {
                if (role.IsSelected)
                {
                    userManager.AddToRole(user.Id, role.Name);
                }
                else if (!role.IsSelected)
                {
                    userManager.RemoveFromRole(user.Id, role.Name);
                }
            }
        }

        private void ChangeUserPassword(string userId, EditUserViewModel viewModel)
        {
            // Create user manager
            var userManager = Request.GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            // Create password reset token
            var token = userManager.GeneratePasswordResetToken(userId);
            var result = userManager.ResetPassword(userId, token, viewModel.Password);

            // Check if operation succeeded
            if (!result.Succeeded)
            {
                throw new Exception(string.Join(";", result.Errors));
            }
        }

        private List<Role> GetUserRoles(ApplicationUser user, BlogDbContext context)
        {
            // Create user and role managers
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(
                new RoleStore<IdentityRole>(context));

            // Get all application roles
            var roles = roleManager.Roles
=======
            // Get all application roles
            var roles = db.Roles
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                .Select(r => r.Name)
                .OrderBy(r => r)
                .ToList();

            // For each application role, check if the user has it
            var userRoles = new List<Role>();

            foreach (var roleName in roles)
            {
                var role = new Role { Name = roleName };

                if (userManager.IsInRole(user.Id, roleName))
                {
                    role.IsSelected = true;
                }

                userRoles.Add(role);
            }

            // Return a list with all roles
<<<<<<< HEAD
            return userRoles;
        }
=======

            return userRoles;
        }
      // Private helper method that loops throught all roles that we received from the form in the view.
        // For each role, it checks weather it is selected and if the user is in the role. Based on that,
        // The user either receives a new role or is removed from it.
        //private void SetUserRoles(EditUserViewModel viewModel, ApplicationUser user, BlogDbContext context)
        //{
        //    var userManager = HttpContext.GetOwinContext()
        //        .GetUserManager<ApplicationUserManager>();

        //    foreach(var role in viewModel.Roles)
        //    {
        //        if(role.IsSelected && !userManager.IsInRole(user.Id, role.Name))
        //        {
        //            userManager.AddToRole(user.Id, role.Name);
        //        }
        //        else if(!role.IsSelected && userManager.IsInRole(user.Id, role.Name))
        //        {
        //            userManager.RemoveFromRole(user.Id, role.Name);
        //        }
        //    }
        //}

        private void SetUserRoles(EditUserViewModel model, ApplicationUser user, BlogDbContext context)
        {
            var userManager = Request
                .GetOwinContext()
                .GetUserManager<ApplicationUserManager>();

            foreach(var role in model.Roles)
            {
                if(role.IsSelected)
                {
                    userManager.AddToRole(user.Id, role.Name);
                }
                else if(!role.IsSelected)
                {
                    userManager.RemoveFromRole(user.Id, role.Name);
                }
            }
        }
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
    }
}