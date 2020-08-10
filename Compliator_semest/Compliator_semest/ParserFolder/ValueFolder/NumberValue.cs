using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder.ValueFolder
{
    public class NumberValue : Value
    {
        public NumberValue(double data) : base(ValType.NUMBER, data)
        {
        }
        
    }
}
