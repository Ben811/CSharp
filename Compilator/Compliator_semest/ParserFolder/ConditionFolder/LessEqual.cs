using Compliator_semest.InterpreterFolder;
using Compliator_semest.ParserFolder.ValueFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ConditionFolder
{
    public class LessEqual : BinaryCondition
    {
        public LessEqual(Expression left, Expression right) : base(left, right)
        {
        }

        public override bool Evaluate(ExecutionContext context)
        {
            var left = Left.Evaluate(context);
            var right = Right.Evaluate(context);

            if (left.IsType(ValType.NUMBER) && right.IsType(ValType.NUMBER))
                return left.AsDouble() <= right.AsDouble();
            else if (left.IsType(ValType.TEXT) && right.IsType(ValType.TEXT))
                return left.AsString()?.CompareTo(right.AsString()) <= 0;

            throw new Exception("LessEqual: invalid data on right or left side");
        }
    }
}
