﻿namespace Dota2API.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class Dota2APIContextInitializer : DropCreateDatabaseIfModelChanges<Dota2APIContext>
    {
        protected override void Seed(Dota2APIContext context)
        {
            var resources = new List<ResourcesModel>()
            {
                new ResourcesModel() {Resource = "http://blog.dota2.com/feed/", Language = Languages.en, ParserType = ParserTypeEnum.Dota2ru},
                new ResourcesModel() {Resource = "http://ru.dota2.com/feed/", Language = Languages.ru, ParserType = ParserTypeEnum.Dota2ru},
            };

            resources.ForEach(p => context.Resources.Add(p));
            context.SaveChanges();

            var news = new List<NewsModel>()            
            {
                new NewsModel() { Title = "Test News", Content = "Content is going here", PublishDate = DateTime.Now, Link = "http://google.com", Resource = resources[1] }
            };

            news.ForEach(p => context.News.Add(p));
            context.SaveChanges();
        }
    }
}