namespace Crawler
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    using AngleSharp;
    using JokeSystem.Data;
    using JokeSystem.Data.Common;
    using JokeSystem.Data.Models;
    using JokeSystem.Services.Data;

    public static class Crawler
    {
        public static void Main(ApplicationDbContext db)
        {
            var repo = new DbRepository<JokeCategory>(db);
            var categoriesService = new CategoriesService(repo);

            var configuration = Configuration.Default.WithDefaultLoader();
            var browsingContext = BrowsingContext.New(configuration);
            var jokes = new List<Joke>();

            for (int i = 1; i <= 100; i++)
            {
                var url = string.Format("http://vicove.com/vic-{0}", i);
                var document = browsingContext.OpenAsync(url).Result;
                var jokeContent = document.QuerySelector("#content_box .post-content").TextContent.Trim();

                if (!string.IsNullOrWhiteSpace(jokeContent))
                {
                    var categoryName = document.QuerySelector("#content_box .thecategory a").TextContent.Trim();
                    var category = categoriesService.EnsureCategory(categoryName);
                    var joke = new Joke { Category = category, Content = jokeContent };
                    jokes.Add(joke);
                }
            }

            db.Jokes.AddOrUpdate(jokes.ToArray());
            db.SaveChanges();
        }
    }
}
