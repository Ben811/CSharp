using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ValueFolder
{
    public class Divide : BinaryExpression
    {
        public Divide(Expression left, Expression right) : base(left, right)
        {
        }

        public override Value Evaluate(ExecutionContext context)
        {
            var left = Left.Evaluate(context);
            var right = Right.Evaluate(context);

            if (left.IsType(ValType.NUMBER) && right.IsType(ValType.NUMBER))            
                return new NumberValue(left.AsDouble() / right.AsDouble());

            throw new Exception("Divide: Expected Number; got text on right or left side");
        }
    }
}
