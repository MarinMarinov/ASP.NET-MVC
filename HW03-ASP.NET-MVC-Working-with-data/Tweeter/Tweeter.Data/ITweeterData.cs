namespace Tweeter.Data
{
    using Models;
    using Repository;
    using System;

    public interface ITweeterData : IDisposable
    {
        IRepository<Tweet> Tweets { get;}

        IRepository<Tag> Tags { get;}

        IRepository<User> Users { get;}

        int SaveChanges();
    }
}
