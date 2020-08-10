using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.LexerFolder.Tokens
{
    public class TextToken : Token
    {
        public string Value 
        {
            get
            {
                return value.Replace("\"","");
            }
            private set 
            {
                this.value = value;
            } 
        }
        private string value;

        public TextToken(string value, int lineNumber) : base(TokenType.TEXT, lineNumber)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"[ Line: {this.LineNumber.ToString()}; Type: {this.Type.ToString()}; Value: {this.Value} ]";
        }
    }




}
