using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder
{
    public class ProcedureCom
    {
        public string Ident { get; set; }
        public Block Block { get; set; }

        public ProcedureCom()
        {
            Ident = "";
            Block = new Block();
        }
    }
}
