using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ConditionFolder
{
    public abstract class Condition
    {
        public abstract bool Evaluate(ExecutionContext context);
    }
}
