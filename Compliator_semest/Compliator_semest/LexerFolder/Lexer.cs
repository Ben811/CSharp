using Compliator_semest.LexerFolder.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.LexerFolder
{
    public class Lexer
    {
        private readonly string code;
        private readonly TokenizerFactory tokenizerFactory;
        public string Code => code;
        public Lexer(string code)
        {
            this.code = code;
            this.tokenizerFactory = new TokenizerFactory();
        }

        public Queue<Token> Tokenize()
        {
            var rawTokens = SeparateCode();
            return tokenizerFactory.Tokenize(rawTokens);
        }


        private List<RawToken> SeparateCode()
        {
            List<RawToken> rawTokens = new List<RawToken>();
            //refactor(ref code);

            int lineNumber = 1;
            for (int i = 0; i < code.Length; i++)
            {
                if (code[i].Equals('\n'))
                    lineNumber++;


                if (Char.IsWhiteSpace(code[i]))
                    continue;

                //ignore one line comments
                if (!IsOutOfRange(i + 1, code.Length) && code[i].Equals('/') && code[i + 1].Equals('/'))
                {
                    string comment = "";
                    for (; i < code.Length; i++)
                    {
                        comment += code[i];
                        if (comment.Contains(Environment.NewLine) || comment.Contains('\n'))
                            break;
                    }
                    i--;
                    continue;
                }

                //ignore multiline Comments
                if (!IsOutOfRange(i, code.Length) && code[i].Equals('/') && code[i + 1].Equals('*'))
                {
                    for (i += 2; i < code.Length; i++) //start looping from fisrt nonCommentIndicator char 
                    {
                        if (IsOutOfRange(i + 1, code.Length) || (code[i].Equals('*') && code[i + 1].Equals('/')))
                        {
                            i++; //skip the last slash 
                            break;
                        }
                    }
                    continue;
                }






                string word = "";
                //read text between quotation marks
                if (code[i].Equals('"'))
                {
                    word += code[i++];
                    while (IsOutOfRange(i, code.Length) || !code[i].Equals('"'))
                    {
                        word += code[i++];
                    }
                    word += code[i];
                }
                else if (IsCharacterFromAlfabet(code[i]))
                {
                    for (; i < code.Length; i++)
                    {
                        if (!ÏsLetterOrNumber(code[i]))
                        {
                            i--;
                            break;
                        }

                        word += code[i];
                    }
                }
                else if (IsCharacterNumber(code[i]))
                {
                    for (; i < code.Length; i++)
                    {
                        if (!IsCharacterNumber(code[i]))
                        {
                            i--;
                            break;
                        }
                        word += code[i];
                    }
                }
                else
                {
                    word += code[i];
                    if (i + 1 < code.Length && code[i + 1] == '=')
                    {
                        word += code[++i];
                    }

                    //for (; i < code.Length; i++)
                    //{
                    //    if (ÏsLetterOrNumber(code[i]) || Char.IsWhiteSpace(code[i]))
                    //    {
                    //        i--;
                    //        break;
                    //    }
                    //    word += code[i];
                    //}
                }
                rawTokens.Add(new RawToken(word, lineNumber));
            }

            return rawTokens;
        }
        private bool IsCharacterFromAlfabet(char letter)
        {
            return (letter >= 'A' && letter <= 'Z') || (letter >= 'a' && letter <= 'z');
        }

        private bool IsCharacterNumber(char letter)
        {
            return (letter >= '0' && letter <= '9');
        }

        private bool ÏsLetterOrNumber(char letter)
        {
            return (letter >= 0 && letter <= 9) || (letter >= 'A' && letter <= 'Z') || (letter >= 'a' && letter <= 'z');
        }

        private bool IsOutOfRange(int possition, int maxRange)
        {
            return possition >= maxRange;
        }

    }
}
