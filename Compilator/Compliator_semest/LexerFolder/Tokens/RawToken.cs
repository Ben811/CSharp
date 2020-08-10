using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.LexerFolder.Tokens
{
    public class RawToken
    {
        public string Value { get; set; }
        public int LineNumber { get; set; }

        public RawToken(string value, int lineNumber)
        {
            Value = value;
            LineNumber = lineNumber;
        }
    }
}
