using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.StatementFolder
{
    public abstract class Statement
    {
        public abstract void Execute(ExecutionContext context);
    }
}
