using Compliator_semest.InterpreterFolder;
using Compliator_semest.ParserFolder.ValueFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.StatementFolder
{
    public class ReadNumStatement : Statement
    {
        public string Ident { get; set; }

        public override void Execute(ExecutionContext context)
        {
            Console.Write($"{Ident}: ");
            if (double.TryParse(Console.ReadLine(), out double value))
                context.SetVariable(Ident, new NumberValue(value));
            else
                throw new Exception($"ReadNumStatement: expected numeric input; variable: {Ident}");

        }
    }
}
