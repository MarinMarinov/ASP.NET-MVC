using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JokeSystem.Web.Controllers
{
    using JokeSystem.Data.Common;
    using JokeSystem.Data.Models;
    using Microsoft.AspNet.Identity;

    [Authorize]
    public class VotesController : BaseController
    {
        private IDbRepository<Vote> votesRepo;

        public VotesController(IDbRepository<Vote> votesRepo)
        {
            this.votesRepo = votesRepo;
        }

        [HttpPost]
        public ActionResult Vote(int jokeId, int voteType)
        {
            if (voteType > 1)
            {
                voteType = 1;
            }

            if (voteType < -1)
            {
                voteType = 1;
            }

            var userId = this.User.Identity.GetUserId();
            var vote = this.votesRepo.All().FirstOrDefault(v => v.AuthorId == userId && v.JokeId == jokeId);

            if (vote == null)
            {
                vote = new Data.Models.Vote { VoteType = (VoteType)voteType, JokeId = jokeId, AuthorId = userId };
                this.votesRepo.Add(vote);
            }
            else
            {
                if (vote.VoteType != (VoteType)voteType)
                {
                    vote.VoteType = VoteType.Neutral;
                }
                else if (vote.VoteType == VoteType.Neutral)
                {
                    vote.VoteType = (VoteType)voteType;
                }
            }

            this.votesRepo.Save();

            var jokeVotes = this.votesRepo.All().Where(v => v.JokeId == jokeId).Sum(v => (int)v.VoteType);

            return this.Json(new { JokeVotes = jokeVotes });
        }
    }
}