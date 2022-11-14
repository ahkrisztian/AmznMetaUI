using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonMetaUI.HTML;

namespace AmazonMetaUI.Comments
{
    public static class NumberOfComments
    {
        public static async Task<List<int>> GetNumberOfComments(string url, IProgress<string> progress)
        {
            progress.Report("Counting Comments");

            var asyncHtml = await GetHtml.getHtml(url);

            string[] divs = asyncHtml.Split('<');

            string reviewlinkfoot = GetLinksFunctions.linkfoot(divs, "see-all-reviews-link-foot");


            //Get a reviews page
            //

            string nexturl = GetLinksFunctions.link(reviewlinkfoot);

            var nextUrlAsync = await GetHtml.getHtml(nexturl);

            string[] div = nextUrlAsync.Split('\n');


            //Get the number of comments and reviews
            //

            List<int> temp = new List<int>();

            foreach (string s in div)
            {

                if (s.Contains("Gesamtbewertungen"))
                {
                    string[] splittedS = s.Split(' ');

                    foreach (string splitted in splittedS)
                    {
                        if (splitted != "")
                        {
                            if (int.TryParse(splitted.Replace(".", ""), out int result))
                            {
                                temp.Add(result);
                            }
                        }
                    }
                }

                progress.Report("Counting Comments");
            }

            progress.Report("");

            return temp;
           
        }
    }
}
