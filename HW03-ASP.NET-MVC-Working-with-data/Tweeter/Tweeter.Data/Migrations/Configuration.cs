namespace Tweeter.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<TweeterDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            
        }

        protected override void Seed(TweeterDbContext context)
        {

        }
    }
}
