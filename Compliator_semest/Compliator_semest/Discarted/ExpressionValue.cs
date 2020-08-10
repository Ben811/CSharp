using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ValueFolder
{
    public class ExpressionValue : Value
    {
        private string ident;
        public Expression Expression { get; set; }
        public ExpressionValue(Expression expression) : base(ValType.EXPRESSION)
        {
            Expression = expression;
        }

        public override string Evaluate(ExecutionContext context)
        {

            return Expression.Evaluate(context).ToString();
        }
    }
}
