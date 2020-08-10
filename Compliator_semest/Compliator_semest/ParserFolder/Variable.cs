using Compliator_semest.ParserFolder.ValueFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder
{
    public class Variable
    {
        public string Ident { get; set; }

        public Value Value { get; set; }

        public Variable(string ident)
        {
            Ident = ident;
        }

        public Variable(string ident, Value value) : this(ident)
        {
            Value = value;
        }
    }
}
