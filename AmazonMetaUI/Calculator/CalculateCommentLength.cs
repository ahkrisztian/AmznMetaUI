using AmazonMetaUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonMetaUI.Calculator
{
    public class CalculateCommentLength : CalculatorBaseClass
    {
        public CalculateCommentLength(List<CommentModel> models)
        : base(models)
        {
        }
        public override double CommentLength()
        {
            List<int> temp = new List<int>();

            foreach (var v in _models)
            {
                if (v.comment != null)
                {
                    temp.Add(v.comment.Length);
                }

            }

            //_models.ForEach(n => temp.Add(n.comment.Length));

            return temp.Average();
        }

        public override string ToString()
        {
            return $"The average length of the comments:{Environment.NewLine} {CommentLength():0}";
        }
    }
}
