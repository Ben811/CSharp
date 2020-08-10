using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ValueFolder
{
    public class MinusUnary : UnaryExpression
    {

        public MinusUnary(Expression expression) : base(expression)
        {
        }

        public override Value Evaluate(ExecutionContext context)
        {
            var expression = Expression.Evaluate(context);
            if (expression.IsType(ValType.NUMBER))
                return new NumberValue(expression.AsDouble()*(-1));

            throw new Exception("MinusUnary: Expected Number; got text");

        }
    }
}
