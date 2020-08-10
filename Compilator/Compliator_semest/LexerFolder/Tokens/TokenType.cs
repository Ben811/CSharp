using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.LexerFolder.Tokens
{
    public enum TokenType
    {
        NUMBER,
        IDENT,
        TEXT,
        VAR,
        PROCEDURE,
        MAIN,
        ODD,
        IF,        
        WHILE,
        READ,
        WRITE,
        COMMA,
        SEMICOLON,        
        SET,
        EQUALS,
        LESS_EQUALS,
        MORE_EQUALS,
        NOT_EQUAL,
        LESS,
        MORE,
        PLUS,
        MINUS,
        MULTIPLY,
        DIVIDE,
        LEFT_BRACKET,
        LEFT_BRACE,
        RIGHT_BRACKET,
        RIGHT_BRACE,
        READNUM
    }
}
