using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ValueFolder
{
    public abstract class UnaryExpression : Expression
    {
        public Expression Expression { get; set; }

        public UnaryExpression(Expression expression)
        {
            Expression = expression;
        }
    }
}
