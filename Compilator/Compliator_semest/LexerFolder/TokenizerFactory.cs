using Compliator_semest.LexerFolder.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.LexerFolder
{
    public class TokenizerFactory
    {
        public Queue<Token> Tokenize(List<RawToken> rawTokens)
        {
            Queue<Token> tokens = new Queue<Token>();
            Fliter filter = new Fliter();
            foreach (var item in rawTokens)
            {
                tokens.Enqueue(filter.FilterToken(item));
            }
            return tokens;
        }
    }
}
