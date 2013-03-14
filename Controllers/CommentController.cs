using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XavierSite.DB;
using XavierSite.ViewModel;

namespace XavierSite.Controllers
{
    public class CommentController : Controller
    {
        private XavierSiteConnect db = new XavierSiteConnect();
         
        //
        // GET: /Comment/Create

        public ActionResult NewComment(int postId)
        {
            ViewData["postId"] = postId;
            return View();
        }

        //
        // POST: /Comment/Create

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(CreateCommentViewModel commentViewModel)
        {
            if (ModelState.IsValid) 
            {
                Comment comment = new Comment();
                Author author = new Author();
                
                author.Name = commentViewModel.Username;
                author.EmailAddress = commentViewModel.EmailAddress;
                comment.Content = commentViewModel.content;
                comment.Author = author;
                comment.PostId = commentViewModel.postId;
                comment.CreatedDate = DateTime.Now;

                TryUpdateModel(comment);
                db.Comments.Add(comment);

                db.SaveChanges();
                return RedirectToAction("Details", "Post", new { postId = commentViewModel.postId });
            }
            return View("NewComment");
        }
    }
}