namespace Tweeter.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class TweeterDbContext : IdentityDbContext<User>
    {
        public TweeterDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TweeterDbContext Create()
        {
            return new TweeterDbContext();
        }
    }
}
