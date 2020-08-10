using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ValueFolder
{
    public abstract class BinaryExpression : Expression
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }

        public BinaryExpression(Expression left, Expression right)
        {
            Left = left;
            Right = right;
        }        
    }
}
