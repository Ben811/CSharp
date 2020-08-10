using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ValueFolder
{
    public class TextValue : Value
    {

        public TextValue(string data) : base(ValType.TEXT, data)
        {
        }
    }
}
