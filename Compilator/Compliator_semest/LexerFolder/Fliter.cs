using Compliator_semest.LexerFolder.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.LexerFolder
{
    public class Fliter
    {
        private readonly string[] CharFilter = { "$", ",", ";", "=", "<", ">", "+", "-", 
                                                    "*", "/", "(", "{", ")", "}",
                                                    "==", "<=", ">=", "!=", "if" , "odd",
                                                    "main", "read" , "readNum", "while", 
                                                    "write", "procedure"};

        private readonly TokenType[] TypeFilter = { TokenType.VAR, TokenType.COMMA, TokenType.SEMICOLON, TokenType.SET, TokenType.LESS,
                                                       TokenType.MORE, TokenType.PLUS, TokenType.MINUS, TokenType.MULTIPLY,
                                                       TokenType.DIVIDE, TokenType.LEFT_BRACKET,TokenType.LEFT_BRACE, TokenType.RIGHT_BRACKET, TokenType.RIGHT_BRACE,
                                                       TokenType.EQUALS, TokenType.LESS_EQUALS, TokenType.MORE_EQUALS, TokenType.NOT_EQUAL, TokenType.IF, TokenType.ODD,
                                                       TokenType.MAIN, TokenType.READ, TokenType.READNUM , TokenType.WHILE, TokenType.WRITE, TokenType.PROCEDURE};

        public Token FilterToken(RawToken rawToken)
        {
            if (String.IsNullOrEmpty(rawToken.Value))
                throw new ArgumentException();

            int index;
            if ((index = FindIndexInFilter(rawToken, CharFilter)) >= 0)
                return new Token(TypeFilter[index], rawToken.LineNumber);

            if (double.TryParse(rawToken.Value, out double numberValue))
                return new NumberToken(numberValue, rawToken.LineNumber);
            else if (rawToken.Value[0] == '"')
                return new TextToken(rawToken.Value, rawToken.LineNumber);
            else
                return new IdentifierToken(rawToken.Value, rawToken.LineNumber);
        }

        private int FindIndexInFilter(RawToken value, string[] values)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (value.Value.Equals(values[i]))
                    return i;
            }
            return -1;
        }

    }
}
