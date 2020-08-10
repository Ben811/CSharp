using Compliator_semest.InterpreterFolder;
using Compliator_semest.ParserFolder.ValueFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.StatementFolder
{
    public class SetNumStatement : Statement
    {
        public string Ident { get; set; }
        public Expression Value { get; set; }

        public SetNumStatement(string ident)
        {
            Ident = ident;
        }

        public override void Execute(ExecutionContext context)
        {
            var value = Value.Evaluate(context);
            context.SetVariable(Ident, new NumberValue());            
        }
    }
}
