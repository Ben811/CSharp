using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ValueFolder
{
    public abstract class Expression
    {
        public abstract Value Evaluate(ExecutionContext context);
    }
}
