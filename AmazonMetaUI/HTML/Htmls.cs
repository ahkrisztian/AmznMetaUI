using AmazonMetaUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AmazonMetaUI.HTML
{
    public static class Htmls
    {

        public static async Task<List<ReviewModel>> asynchtml(List<IPageLinkModel> htmls, IProgress<string> progress)
        {
            //
            List<ReviewModel> websites = new List<ReviewModel>();

            List<Task<List<ReviewModel>>> tasks = new List<Task<List<ReviewModel>>>();

            foreach (var html in htmls)
            {
                tasks.Add(Task.Run(async () => await GetHtmlTextParallel.getHtml2(html.LinkForth)));
                progress.Report($"Collecting Data");
            }

            var result = await Task.WhenAll(tasks);

            foreach (var item in result)
            {
                foreach (var v in item)
                {
                    websites.Add(v);
                }
            }

            return websites;
        }

    }
}
