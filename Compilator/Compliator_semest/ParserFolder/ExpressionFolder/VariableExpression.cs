using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ValueFolder
{
    public class VariableExpression : Expression
    {
        public string Ident { get; set; }

        public VariableExpression(string ident)
        {
            Ident = ident;
        }

        public override Value Evaluate(ExecutionContext context)
        {
            return context.GetVariable(Ident).Value;
        }
    }
}
