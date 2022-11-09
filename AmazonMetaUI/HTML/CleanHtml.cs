using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonMetaUI.HTML
{
    public static class CleanHtml
    {
        public static List<string> GetCommentsTitlesParallel(string page)
        {
            List<string> data = new List<string>();

            List<string> data2 = new List<string>();

            string[] html = page.Split(new[] { "cr-filter-info-section", "window.P.register('cf')" }, StringSplitOptions.RemoveEmptyEntries);

            //Second part - where the reviews are
            string[] htmll = html[1].Split(new[] { "data-hook=\"review\"" }, StringSplitOptions.RemoveEmptyEntries);

            var values = new String[] {
                "div", "/div", "class", "<a>", "</a>", "script", "{", "}",
                "src=", "imagePopoverController", "<br>", "Bilder in dieser Rezension",
                "Kommentare anzeigen", "data-hook" };

            Parallel.Invoke(() =>
            {
                //Get the reviews which contains <span>
                foreach (string s in htmll)
                {

                    string[] temp = s.Split(new[] { "<span>", "</span>", }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var v in temp)
                    {
                        if (!values.Any(v.Contains) && !string.IsNullOrWhiteSpace(v))
                        {
                            data.Add(v);
                        }

                    }

                }
            },
            () =>
            {
                //Get the reviews which contains <span class="cr-original-review-content">
                foreach (string s in htmll)
                {

                    string[] temp = s.Split(new[] { "<span" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var v in temp)
                    {
                        if (v.Contains("cr-original-review-content"))
                        {
                            data2.Add(v);
                        }

                    }

                }
            });

            List<string> ConcataData = data.Concat(data2).ToList();

            List<string> cleanData = new List<string>();

            //data.AddRange(data2);

            foreach (string s in ConcataData)
            {
                if (!s.StartsWith("Von") && !s.Contains("globale Bewertungen"))
                {
                    cleanData.Add(s.Replace("<br />", "").Replace("</span>", "").Replace("class=", "").Replace("\"cr-original-review-content\">", "").TrimStart());
                }
            }

            return cleanData;
        }
    }
}

