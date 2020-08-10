using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ValueFolder
{
    public class Plus : BinaryExpression
    {
        public Plus(Expression left, Expression right) : base(left, right)
        {
        }

        public override Value Evaluate(ExecutionContext context)
        {
            var left = Left.Evaluate(context);
            var right = Right.Evaluate(context);

            if (left.IsType(ValType.NUMBER) && right.IsType(ValType.NUMBER))
                return new NumberValue(left.AsDouble() + right.AsDouble());
            else if (left.IsType(ValType.TEXT) && right.IsType(ValType.TEXT))
                return new TextValue(left.AsString() + right.AsString());
            
            throw new Exception("Plus: invalid data on right or left side");
        }
    }
}
