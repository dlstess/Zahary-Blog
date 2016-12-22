using Blog.Models;
<<<<<<< HEAD
using System.Data.Entity;
using System.Linq;
using System.Net;
=======
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
<<<<<<< HEAD
        //
=======
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        // GET: Article
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        //
        // GET: Article/List
        public ActionResult List()
        {
<<<<<<< HEAD
            using (var database = new BlogDbContext())
            {
                var articles = database.Articles
                    .Include(a => a.Author)
=======

            using (var database = new BlogDbContext())
            {
                // Get articles from database
                var articles = database.Articles
                    .Include(a => a.Author)
                    .Include(a => a.Tags)
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                    .ToList();

                return View(articles);
            }
<<<<<<< HEAD
=======
            //return View();
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        }

        //
        // GET: Article/Details
        public ActionResult Details(int? id)
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
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
=======
                // Get the article from database

                var article = database.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .Include(a => a.Tags)
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                    .First();

                if (article == null)
                {
                    return HttpNotFound();
                }

                return View(article);
            }
<<<<<<< HEAD
=======

            
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        }

        //
        // GET: Article/Create
<<<<<<< HEAD
        [Authorize]
        public ActionResult Create()
        {
            return View();
=======
        [HttpGet]
        [Authorize]
        public ActionResult Create()
        {
            using (var database = new BlogDbContext())
            {
                var model = new ArticleViewModel();
                model.Categories = database.Categories
                    .OrderBy(c => c.Name)
                    .ToList();

                return View(model);
            }

>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        }

        //
        // POST: Article/Create
        [HttpPost]
        [Authorize]
<<<<<<< HEAD
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                using (var database = new BlogDbContext())
                {
=======
        public ActionResult Create(ArticleViewModel model)
        {
            if(ModelState.IsValid)
            {
                using (var database = new BlogDbContext())
                {
                    // Get author id
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                    var authorId = database.Users
                        .Where(u => u.UserName == this.User.Identity.Name)
                        .First()
                        .Id;

<<<<<<< HEAD
                    article.AuthorId = authorId;

=======
                    var article = new Article(authorId, model.Title, model.Content, model.CategoryId);

                    // Set articles author
                    article.AuthorId = authorId;

                    this.SetArticleTags(article, model, database);

                    // Save article in DB
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                    database.Articles.Add(article);
                    database.SaveChanges();

                    return RedirectToAction("Index");
                }
            }

<<<<<<< HEAD
            return View(article);
=======
            return View(model);
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        }

        //
        // GET: Article/Delete
<<<<<<< HEAD
        [Authorize]
=======
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
<<<<<<< HEAD
            
            using (var database = new BlogDbContext())
            {
                // Get article from database
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();
=======

            using (var database = new BlogDbContext())
            {
                // Get article from database
                //var article = database.Articles
                //    .Where(a => a.Id == id)
                //    .Include(a => a.Author)
                //    .First();

                var article = database.Articles
                    .Include(a => a.Category)
                    .FirstOrDefault(a => a.Id == id);
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e

                if (!IsUserAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

<<<<<<< HEAD
                // Check if article exists
=======
                ViewBag.TagsString = string.Join(", ", article.Tags.Select(t => t.Name));
                // Check if article exist
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                if (article == null)
                {
                    return HttpNotFound();
                }

                // Pass article to view
                return View(article);
            }
        }

        //
        // POST: Article/Delete
<<<<<<< HEAD
        [HttpPost, Authorize]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if (id == null)
=======
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int? id)
        {
            if(id==null)
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                // Get article from database
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .Include(a => a.Author)
                    .First();

<<<<<<< HEAD
                // Check if article exists
=======
                // Check if article exist
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                if (article == null)
                {
                    return HttpNotFound();
                }

                // Delete article from database
                database.Articles.Remove(article);
                database.SaveChanges();

                // Redirect to index page
                return RedirectToAction("Index");
            }
<<<<<<< HEAD
=======
            
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        }

        //
        // GET: Article/Edit
<<<<<<< HEAD
        [Authorize]
=======
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            using (var database = new BlogDbContext())
            {
                // Get article from the database
                var article = database.Articles
                    .Where(a => a.Id == id)
                    .First();

                if (!IsUserAuthorizedToEdit(article))
                {
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                }

<<<<<<< HEAD
                // Check if article exists
=======
                // Check if article exist
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                if (article == null)
                {
                    return HttpNotFound();
                }

                // Create the view model
                var model = new ArticleViewModel();
                model.Id = article.Id;
<<<<<<< HEAD
                model.AuthorId = article.AuthorId;
                model.Title = article.Title;
                model.Content = article.Content;

                // Show the editing view
=======
                model.Title = article.Title;
                model.Content = article.Content;
                model.CategoryId = article.CategoryId;
                model.Categories = database.Categories
                    .OrderBy(c => c.Name)
                    .ToList();

                model.Tags = string.Join(", ", article.Tags.Select(t => t.Name));

                //  Pass the view model to view
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                return View(model);
            }
        }

        //
        // POST: Article/Edit
        [HttpPost]
<<<<<<< HEAD
        [Authorize]
        public ActionResult Edit(ArticleViewModel model)
        {
            // Check if model state is valid
            if (ModelState.IsValid)
=======
        public ActionResult Edit(ArticleViewModel model)
        {
            // Check if model state is valid
            if(ModelState.IsValid)
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
            {
                using (var database = new BlogDbContext())
                {
                    // Get article from database
                    var article = database.Articles
                        .FirstOrDefault(a => a.Id == model.Id);

<<<<<<< HEAD
                    // Set article title and content
                    article.AuthorId = model.AuthorId;
                    article.Title = model.Title;
                    article.Content = model.Content;

                    // Save article state in database
=======
                    // Set article properties
                    article.Title = model.Title;
                    article.Content = model.Content;
                    article.CategoryId = model.CategoryId;
                    this.SetArticleTags(article, model, database);

                    // Save article stata in database
>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
                    database.Entry(article).State = EntityState.Modified;
                    database.SaveChanges();

                    // Redirect to the index page
                    return RedirectToAction("Index");
                }
            }

            // If model state is invalid, return the same view
            return View(model);
        }

<<<<<<< HEAD
=======
        private void SetArticleTags(Article article, ArticleViewModel model, BlogDbContext database)
        {
            // Split tags
            var tagsStrings = model.Tags
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(t => t.ToLower())
                .Distinct();

            // Clear current Article tags
            article.Tags.Clear();

            // Set new article tags
            foreach (var tagString in tagsStrings)
            {
                // Get tag from db by its name
                Tag tag = database.Tags.FirstOrDefault(t => t.Name.Equals(tagString));

                // If the tag is null, create new tag
                if (tag == null)
                {
                    tag = new Tag() { Name = tagString };
                    database.Tags.Add(tag);
                }

                // Add tag to article tags
                article.Tags.Add(tag);
            }
        }

>>>>>>> bb2f3aa44f68db192bd45cb5288d83367e83e90e
        private bool IsUserAuthorizedToEdit(Article article)
        {
            bool isAdmin = this.User.IsInRole("Admin");
            bool isAuthor = article.IsAuthor(this.User.Identity.Name);

            return isAdmin || isAuthor;
        }
    }
}