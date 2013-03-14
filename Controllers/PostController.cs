using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using XavierSite.DB;
using XavierSite.ViewModel;

namespace XavierSite.Controllers
{
    public class PostController : Controller
    {
        private XavierSiteConnect db = new XavierSiteConnect();

        //
        // GET: /Post/

        public ActionResult Index()
        {
            return View(db.Posts.OrderByDescending(p => p.CreatedDate).ToList());
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // GET: /Post/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Post/Create

        [HttpPost]
        [ValidateInput(false)]//The second attribute ValidateInput is telling MVC not to validate the user input, without this when submitting the form you will see the error message shown below.
        public ActionResult Create(PostViewModel postVM)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post();
                post.ModifiedDate = post.CreatedDate = DateTime.Now;
                post.Content = postVM.Content;
                post.Title = postVM.Title;

                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postVM);
        }

        //
        // GET: /Post/Edit/5

        public ActionResult Edit(int postId = 0)
        {
            Post post = db.Posts.Find(postId);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        //
        // GET: /Post/Delete/5

        public ActionResult Delete(int postId)
        {
            Post post = db.Posts.Find(postId);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Post/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int postId)
        {
            Post post = db.Posts.Find(postId);

            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddComment(string commentBody, string username, string postId)
        {
            Comment comment = new Comment();
            Author author = new Author();

            author.Name = username;
            author.EmailAddress = username;
            comment.Content = commentBody;
            comment.Author = author;
            comment.PostId = int.Parse(postId);
            comment.CreatedDate = DateTime.Now;

            db.Comments.Add(comment);

            db.SaveChanges();

            if (Request.IsAjaxRequest())
            {
                return Json(new { username = username, commentBody = commentBody, commentDate = comment.CreatedDate.ToString() });
            }

            Post post = new Post();
            post = db.Posts.Find(int.Parse(postId));

            return View("Details", new { post = post });
        }

        [HttpPost]
        public ActionResult Search(string searchString)
        {
            var searchResult = (from b in db.Posts
                                where b.Title.Contains(searchString) || b.Content.Contains(searchString)
                                orderby b.CreatedDate descending
                                select b).Distinct().ToList();
            TempData["searchResults"] = searchResult;
            return RedirectToAction("SearchResults", new { q = searchString });
        }

        public ActionResult SearchResults()
        {
            List<Post> posts = (List<Post>)TempData["searchResults"];
            return View(posts);
        }

    }
}