using Compliator_semest.InterpreterFolder;
using System;

namespace Compliator_semest.ParserFolder.ValueFolder
{
    public abstract class Value
    {
        public ValType Type { get; set; }
        public object Data { get; set; }

        protected Value(ValType type, object data)
        {
            Type = type;
            Data = data;
        }

        public bool IsType(ValType type)
        {
            return Type == type;
        }

        public string AsString()
        {
            if (Type == ValType.TEXT)
                return (string)Data;
            throw new Exception("Wrong data type; expected Text; got Number");
        }

        public double AsDouble()
        {
            if (Type == ValType.NUMBER)
                return (double)Data;
            throw new Exception("Wrong data type; expected Number; got Text");
        }

        public override string ToString()
        {
            if (Data == null)
                return "";

            if (IsType(ValType.NUMBER))
                return AsDouble().ToString();

            if (IsType(ValType.TEXT))
                return AsString();

            throw new Exception("ToString: Invalid Value instance state");
        }
    }
}
