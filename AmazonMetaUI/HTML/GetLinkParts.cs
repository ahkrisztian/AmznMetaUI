using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonMetaUI.Models;

namespace AmazonMetaUI.HTML
{
    public static class GetLinkParts
    {
        public static async Task<PageLinkModel> NewPageLinkModel(string url)
        {
            List<string> darabolt2 = new List<string>();

            string asyncDivs = await GetHtml.getHtml(url);

            string[] divs = asyncDivs.Split('<');

            string reviewlinkfoot = GetLinksFunctions.linkfoot(divs, "see-all-reviews-link-foot");


            //Get a reviews page
            string nexturl = GetLinksFunctions.link(reviewlinkfoot);


            //Next page buttom link

            string divAsync = await GetHtml.getHtml(nexturl);

            string[] div = divAsync.Split(' ');

            string[] nexturlarray = GetLinksFunctions.nextpageurl(div);

            //Split next page link
            string[] darabolt = nexturlarray[1].Split('/');

            //Next page link pieces

            foreach (var v in darabolt)
            {
                if (!String.IsNullOrEmpty(v))
                {
                    darabolt2.Add(v);
                }
            }

            darabolt2.ToArray();

            return new PageLinkModel { LinkFirst = darabolt2[0], LinkSecond = darabolt2[1], LinkThird = darabolt2[2] };

        }
    }
}
