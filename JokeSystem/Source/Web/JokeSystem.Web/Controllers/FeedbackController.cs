using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JokeSystem.Web.Controllers
{
    using JokeSystem.Data.Common;
    using JokeSystem.Data.Models;
    using JokeSystem.Web.ViewModels.Feedback;

    using Microsoft.AspNet.Identity;

    [Authorize]
    public class FeedbackController : BaseController
    {
        private IDbRepository<Feedback> feedRepo;

        public FeedbackController(IDbRepository<Feedback> feed)
        {
            this.feedRepo = feed;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FeedbackCreateModel model)
        {
            if (this.ModelState.IsValid)
            {
                var feedback = new Feedback
                {
                    Title = model.Title,
                    Content = model.Content
                };

                if (this.User.Identity.IsAuthenticated)
                {
                    feedback.AuthorId = this.User.Identity.GetUserId();
                }

                this.feedRepo.Add(feedback);
                this.feedRepo.Save();

                this.TempData["Notification"] = "Thanks for the feedback!";

                return this.Redirect("/");
            }

            return this.View(model);
        }
    }
}