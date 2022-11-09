using AmazonMetaUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonMetaUI.Calculator
{
    public abstract class CalculatorBaseClass
    {
        protected readonly List<CommentModel> _models;
        public CalculatorBaseClass(List<CommentModel> models)
        {
            _models = models;
        }
        public abstract double CommentLength();

    }
}
