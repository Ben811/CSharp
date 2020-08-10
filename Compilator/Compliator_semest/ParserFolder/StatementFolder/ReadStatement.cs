using Compliator_semest.InterpreterFolder;
using Compliator_semest.ParserFolder.ValueFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.StatementFolder
{
    public class ReadStatement : Statement
    {
        public string Ident { get; set; }

        public override void Execute(ExecutionContext context)
        {
            Console.Write($"{Ident}: ");
            string value = Console.ReadLine();
            context.SetVariable(Ident, new TextValue(value));
        }
    }
}
