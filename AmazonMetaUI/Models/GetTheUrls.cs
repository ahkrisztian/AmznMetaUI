using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonMetaUI.HTML;
using AmazonMetaUI.Comments;
using System.Threading;

namespace AmazonMetaUI.Models
{
    public static class GetTheUrls
    {
        public static List<IPageLinkModel> urls(string url, IProgress<string> progress, int comments, PageLinkModel pageModel)
        {          
            int Comments = comments / 10 + 2;

            progress.Report("Counting Comments");

            //var pageModel = GetLinkParts.NewPageLinkModel(url);

            List<IPageLinkModel> models = new List<IPageLinkModel>();

            for (int i = 1; i < Comments; i++)
            {
                progress.Report($"Creating the links");

                models.Add(new PageLinkModel
                {
                    LinkFirst = pageModel.LinkFirst,
                    LinkSecond = pageModel.LinkSecond,
                    LinkThird = pageModel.LinkThird,
                    PageNumber = i,
                    LinkForth = $"https://www.amazon.de/{pageModel.LinkFirst}/{pageModel.LinkSecond}/{pageModel.LinkThird}" +
                                $"/ref=cm_cr_getr_d_paging_btm_next_{i}?ie=UTF8&reviewerType=all_reviews&pageNumber={i}"

                });
            
            }

            return models;
        }
    }
}
