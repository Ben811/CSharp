using Compliator_semest.ParserFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.InterpreterFolder
{
    public class ProgramContext
    {
        private ProcedureCom[] _procedures;

        public ProgramContext(List<ProcedureCom> procedures)
        {
            _procedures = procedures.ToArray();
        }
        public bool Call(string procedure, ExecutionContext context)
        {
            for (int i = 0; i < _procedures.Length; i++)
            {
                if (_procedures[i].Ident.Equals(procedure))
                {
                    _procedures[i].Block.Execute(context);
                    return true;
                }
            }
            return false;
        }
    }
}
