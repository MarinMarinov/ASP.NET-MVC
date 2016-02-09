namespace Tweeter
{
    using System.Data.Entity;
    using Data;
    using Data.Migrations;

    public static class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TweeterDbContext, Configuration>());
            TweeterDbContext.Create().Database.Initialize(true);
        }
    }
}