using Compliator_semest.InterpreterFolder;
using Compliator_semest.ParserFolder.ValueFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.StatementFolder
{
    public class SetStatement : Statement
    {
        public string Ident { get; set; }
        public Expression Expression { get; set; }

        public SetStatement(string ident)
        {
            Ident = ident;
        }

        public override void Execute(ExecutionContext context)
        {
            var value = Expression.Evaluate(context);
            context.SetVariable(Ident, value);
        }
    }
}
