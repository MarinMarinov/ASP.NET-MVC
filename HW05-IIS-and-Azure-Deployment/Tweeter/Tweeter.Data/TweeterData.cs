using System;
using System.Collections.Generic;

namespace Tweeter.Data
{
    using Models;
    using Repository;

    public class TweeterData : ITweeterData
    {
        private readonly TweeterDbContext context;
        private readonly Dictionary<Type, object> repositories;

        public TweeterData()
            : this(new TweeterDbContext())
        {
        }

        public TweeterData(TweeterDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Tweet> Tweets
        {
            get { return this.GetRepository<Tweet>(); }
        }

        public IRepository<Tag> Tags
        {
            get { return this.GetRepository<Tag>(); }

        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }

        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(EfGenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
