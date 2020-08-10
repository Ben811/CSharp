using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.LexerFolder.Tokens
{
    public class Token
    {
        public TokenType Type { get; private set; }
        public int LineNumber { get; set; }
        public Token(TokenType type, int lineNumber)
        {
            Type = type;
            LineNumber = lineNumber;
        }

        public override string ToString()
        {
            return $"[ Line: {this.LineNumber.ToString()}; Type: {this.Type.ToString()} ]";
        }
    }
}