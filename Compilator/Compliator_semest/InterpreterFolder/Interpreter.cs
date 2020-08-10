using Compliator_semest.ParserFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.InterpreterFolder
{
    public class Interpreter
    {
        private readonly Program program;
        public Interpreter(Program program)
        {
            this.program = program;
        }

        public void Execute()
        {
            program.Execute();
        }
    }
}
