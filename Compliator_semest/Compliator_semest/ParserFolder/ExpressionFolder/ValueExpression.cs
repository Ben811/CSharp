using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ValueFolder
{
    public class ValueExpression : Expression
    {
        public Value Data { get; set; }

        public ValueExpression(double data)
        {
            Data = new NumberValue(data);
        }

        public ValueExpression(string data)
        {
            Data = new TextValue(data);
        }

        public override Value Evaluate(ExecutionContext context)
        {
            return Data;                
        }
    }
}
