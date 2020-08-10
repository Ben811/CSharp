using Compliator_semest.InterpreterFolder;
using Compliator_semest.ParserFolder.ConditionFolder;

namespace Compliator_semest.ParserFolder.StatementFolder
{
    public class IfStatement : Statement
    {
        public Condition Condition { get; set; }
        public Block Block { get; set; }

        public override void Execute(ExecutionContext context)
        {
            if (Condition.Evaluate(context))
            {
                Block.Execute(context);
            }
        }
    }
}
