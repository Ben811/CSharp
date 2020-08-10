using Compliator_semest.InterpreterFolder;
using Compliator_semest.ParserFolder.ValueFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.StatementFolder
{
    public class WriteStatement : Statement
    {
        public Expression Expression { get; set; }

        public override void Execute(ExecutionContext context)
        {
            var value = Expression.Evaluate(context);
            Console.WriteLine(value.ToString());
        }
    }
}
