using Compliator_semest.ParserFolder.ValueFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ConditionFolder
{
     public abstract class BinaryCondition : Condition
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public BinaryCondition(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }
    }
}
