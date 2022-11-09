using System;
using System.Collections.Generic;
using System.Linq;
using AmazonMetaUI.Models;

namespace AmazonMetaUI.CreateLinks
{
    public class CreateLinkList
    {
        private readonly List<CommentModel> models;
        public CreateLinkList()
        {
            models = new List<CommentModel>();
        }

        public List<CommentModel> AddLinkModel(List<ReviewModel> commentandtitle)
        {

            for (int i = 0; i < commentandtitle.Count; i++)
            {
                string title = commentandtitle[i].title;
                string comment = commentandtitle[i].comment;
                string stars = commentandtitle[i].stars;
                string date = commentandtitle[i].date;
                string link = commentandtitle[i].linkToCostumer;
                string formed = 
                    $"Stars: {stars} - {date}{Environment.NewLine}" +
                    $"Title: {title}{Environment.NewLine}" +
                    $"Comment:{comment}{Environment.NewLine}" +
                    $"https://www.amazon.de{link}{Environment.NewLine}" +
                    $"------------------------------------------";

            models.Add(new CommentModel(title, comment, formed));

            }

            return models;
        }

        public override string ToString() =>
                string.Join(Environment.NewLine,
                models.Select(x => x.Formed));
    }
}
