namespace JokeSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using JokeSystem.Data.Common;
    using JokeSystem.Data.Models;
    using JokeSystem.Web.Infrastructure.Mapping;
    using JokeSystem.Web.ViewModels.Feedback;

    public class PageableFeedbackListController : BaseController
    {
        private const int ItemsPerPage = 4;
        private IDbRepository<Feedback> feedRepo;

        public PageableFeedbackListController(IDbRepository<Feedback> feed)
        {
            this.feedRepo = feed;
        }

        [HttpGet]
        public ActionResult Index(int id = 1)
        {
            var page = id;
            var totalItemsCount = this.feedRepo.All().Count();
            var totalPages = (int)Math.Ceiling((double)totalItemsCount / (double)ItemsPerPage);
            var itemsToSkip = (page - 1) * ItemsPerPage;

            var feedbacks = this.Cache.Get(
                "feedback",
                () => this.feedRepo.All()
                .OrderBy(x => x.CreatedOn)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage)
                .To<FeedbackViewModel>()
                .ToList(),
                20);

            var listViewModel = new FeedbackListViewModel
            {
                CurrentPage = page,
                TotalPages = totalPages,
                Feedbacks = feedbacks
            };

            return this.View(listViewModel);
        }
    }
}