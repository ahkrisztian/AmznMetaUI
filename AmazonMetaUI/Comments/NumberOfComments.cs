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
        public static async Task<int> GetNumberOfComments(string url, IProgress<string> progress)
        {
            progress.Report("Counting Comments");

            var asyncHtml = await GetHtml.getHtml(url);

            string[] divs = asyncHtml.Split('<');

            string reviewlinkfoot = GetLinksFunctions.linkfoot(divs, "see-all-reviews-link-foot");


            //Get a reviews page
            string nexturl = GetLinksFunctions.link(reviewlinkfoot);

            var nextUrlAsync = await GetHtml.getHtml(nexturl);

            string[] div = nextUrlAsync.Split('\n');

            List<string> temp = new List<string>();

            foreach (string s in div)
            {

                if (s.Contains("Gesamtbewertungen"))
                {
                    string[] splittedS = s.Split(' ');

                    foreach (string splitted in splittedS)
                    {
                        if (splitted != "")
                        {
                            temp.Add(splitted);
                        }
                    }
                }

                progress.Report("Counting Comments");
            }

            List<char> numberofcommentsList = new List<char>();

            foreach (char c in temp[0])
            {
                if (Char.IsDigit(c))
                {
                    numberofcommentsList.Add(c);
                }
            }

            string tempnumberofcomment = string.Concat(numberofcommentsList);

            progress.Report("");

            return Convert.ToInt32(tempnumberofcomment);
           
        }
    }
}
