namespace Tweeter.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class TweeterDbContext : IdentityDbContext<User>
    {
        public TweeterDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Tweet> Tweets { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public static TweeterDbContext Create()
        {
            return new TweeterDbContext();
        }
    }
}
