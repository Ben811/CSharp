using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.LexerFolder.Tokens
{
    public class NumberToken : Token
    {
        public double Value { get; private set; }
        public NumberToken(double value, int lineNumber) : base(TokenType.NUMBER, lineNumber)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"[ Line: {this.LineNumber.ToString()}; Type: {this.Type.ToString()}; Value: {this.Value.ToString()} ]";
        }
    }
}

