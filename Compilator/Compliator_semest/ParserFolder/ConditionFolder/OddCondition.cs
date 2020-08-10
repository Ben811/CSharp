using Compliator_semest.InterpreterFolder;
using Compliator_semest.ParserFolder.ValueFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ConditionFolder
{
    public class OddCondition : Condition
    {
        public Expression Expression { get; set; }

        public OddCondition(Expression expression)
        {
            Expression = expression;
        }

        public override bool Evaluate(ExecutionContext context)
        {
            var expression = Expression.Evaluate(context);
            if (expression.IsType(ValType.NUMBER))
                return expression.AsDouble() != 0;

            throw new Exception("OddCondition: Expected number ");
        }
    }
}
