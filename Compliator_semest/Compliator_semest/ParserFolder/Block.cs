using System;
using System.Collections.Generic;
using Compliator_semest.InterpreterFolder;
using Compliator_semest.ParserFolder.StatementFolder;


namespace Compliator_semest.ParserFolder
{
    public class Block
    {
        public List<Statement> Statements { get; set; }

        public Block()
        {
            Statements = new List<Statement>();
        }

        public void Execute(ExecutionContext context)
        {
            ExecutionContext localContext = new ExecutionContext(context);
            foreach (var item in Statements)
            {
                item.Execute(localContext);
            }
        }
    }
}
