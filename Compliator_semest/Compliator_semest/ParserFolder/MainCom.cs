using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder
{
    public class MainCom
    {
        public Block Block { get; set; }

        public MainCom()
        {
            Block = new Block();
        }

        internal void Execute(ExecutionContext context)
        {
            Block.Execute(context);
        }
    }
}
