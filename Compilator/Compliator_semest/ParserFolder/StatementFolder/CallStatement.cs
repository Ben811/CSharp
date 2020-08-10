using Compliator_semest.InterpreterFolder;
using Compliator_semest.ParserFolder.ValueFolder;
using System.Collections.Generic;

namespace Compliator_semest.ParserFolder.StatementFolder
{
    public class CallStatement : Statement
    {
        public string Ident { get; set; }
        public List<Expression> Parameters { get; set; }
        public CallStatement()
        {
            Parameters = new List<Expression>();
        }

        public override void Execute(ExecutionContext context)
        {
            List<Value> parameters = new List<Value>();
            foreach (var item in Parameters)
            {
                parameters.Add(item.Evaluate(context));
            }
            context.CallProcedure(Ident, parameters);
        }
    }
}
