using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.LexerFolder.Tokens
{
    public class IdentifierToken : Token
    {
        public string Value { get; private set; }
        public IdentifierToken(string value, int lineNumber) : base(TokenType.IDENT, lineNumber)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"[ Line: {this.LineNumber.ToString()}; Type: {this.Type.ToString()}; Value: {this.Value} ]";
        }
    }
}
