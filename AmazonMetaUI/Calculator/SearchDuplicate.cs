using AmazonMetaUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonMetaUI.Calculator
{
     public class SearchDuplicate
    {
        private  Dictionary<string, int> duplicates;
        public SearchDuplicate()
        {
            duplicates = new Dictionary<string, int>();
        }

        public void AddDuplicate(List<CommentModel> commentandtitle)
        {
            List<string> temp = new List<string>();

            foreach(var v in commentandtitle)
            {
                if(v.comment != null)
                {
                    temp.Add(v.comment);
                }
            }

            var query = temp.GroupBy(x => x)
              .Where(g => g.Count() > 1)
              .ToDictionary(x => x.Key, y => y.Count());

            duplicates = query;
        }

        public override string ToString()
        {
            if(duplicates.Count > 0)
            {
                return String.Join("\n", duplicates);
            }

            return $"No duplicates";
        }
    }
}
