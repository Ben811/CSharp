using Compliator_semest.ParserFolder;
using Compliator_semest.ParserFolder.ValueFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.InterpreterFolder
{
    public class Variables
    {
        public List<Variable> VarList { get; }

        public Variables(List<Variable> variables)
        {
            VarList = variables;
        }

        public Variables()
        {
            VarList = new List<Variable>();
        }

        public Variable Get(string ident)
        {
            for (int i = 0; i < VarList.Count; i++)
            {
                if (ident.Equals(VarList[i].Ident))
                   return VarList[i];
            }
            return null;
        }

    }
}
