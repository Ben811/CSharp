using Compliator_semest.InterpreterFolder;
using Compliator_semest.ParserFolder.StatementFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder
{
    public class Program
    {
        public MainCom MainCom { get; set; }
        public List<ProcedureCom> ProcedureComs { get; set; }
        public List<Statement> Variables { get; set; }

        public Program()
        {
            ProcedureComs = new List<ProcedureCom>();
            Variables = new List<Statement>();            
        }

        public void Execute()
        {
            ExecutionContext context = new ExecutionContext(ProcedureComs, null);
            foreach (var item in Variables)
            {
                item.Execute(context);
            }
            MainCom.Execute(context);
        }
    }
}
