using Compliator_semest.InterpreterFolder;
using Compliator_semest.ParserFolder.ConditionFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.StatementFolder
{
    public class WhileStatement : Statement
    {
        public Condition Condition { get; set; }
        public Block Block { get; set; }

        public override void Execute(ExecutionContext context)
        {
            while (Condition.Evaluate(context))
            {
                Block.Execute(context);
            }
        }
    }
}
