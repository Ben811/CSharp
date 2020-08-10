using Compliator_semest.LexerFolder.Tokens;
using Compliator_semest.ParserFolder.ConditionFolder;
using Compliator_semest.ParserFolder.StatementFolder;
using Compliator_semest.ParserFolder.ValueFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.ParserFolder
{
    public class Parser
    {
        private readonly Queue<Token> tokens;

        public Parser(Queue<Token> tokens)
        {
            this.tokens = tokens;
        }

        public Program Parse()
        {
            return ReadProgram();
        }

        private Program ReadProgram()
        {
            Program program = new Program();

            Token token;
            while ((token = PeekToken()).Type != TokenType.MAIN)
            {
                if (token.Type == TokenType.VAR)
                {
                    program.Variables.Add(ReadDeclareStatement());
                    TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.SEMICOLON);
                }
                else if (token.Type == TokenType.PROCEDURE)
                {
                    program.ProcedureComs.Add(ReadProcedure());
                }
                else
                    throw new Exception($"Expected Token: VAR or PROCEDURE; got Token: {token.Type}, on line: {token.LineNumber}");
            }

            program.MainCom = ReadMainCom();

            return program;
        }

        private MainCom ReadMainCom()
        {
            MainCom mainCom = new MainCom();

            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.MAIN);

            mainCom.Block = ReadBlock();

            return mainCom;

        }

        private ProcedureCom ReadProcedure()
        {
            ProcedureCom procedure = new ProcedureCom();

            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.PROCEDURE);

            TokenTypeComparatorAndExceptionThrower(PeekToken(), TokenType.IDENT);
            procedure.Ident = ((IdentifierToken)ReadToken()).Value;

            procedure.Block = ReadBlock();

            return procedure;
        }

        private Block ReadBlock()
        {
            Block block = new Block();

            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.LEFT_BRACE);

 
            while (PeekToken().Type != TokenType.RIGHT_BRACE)
            {             
                block.Statements.Add(ReadStatement());                                
                TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.SEMICOLON);
            }

            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.RIGHT_BRACE);

            return block;
        }

        private Expression ReadExpression()
        {
            Expression root;
            Expression left;

            if (PeekToken().Type == TokenType.MINUS)
            {
                ReadToken();
                left = new MinusUnary(ReadTerm());
            }
            else if (PeekToken().Type == TokenType.PLUS)
            {
                ReadToken();
                left = new PlusUnary(ReadTerm());
            }
            else
                left = ReadTerm();


            if (PeekToken().Type == TokenType.MINUS)
            {
                ReadToken();
                root = new Minus(left, ReadTerm());
            }
            else if (PeekToken().Type == TokenType.PLUS)
            {
                ReadToken();
                root = new Plus(left, ReadTerm());
            }
            else
                return left;

            return ReadExpression(root);
        }

        private Expression ReadExpression(Expression root)
        {
            if (!IsTokenPlusOrMinus(PeekToken()))
                return root;

            Expression left = root;
            TokenType tokenType = ReadToken().Type;

            if (tokenType == TokenType.MINUS)
                return ReadExpression(new Minus(left, ReadTerm()));

            else if (tokenType == TokenType.PLUS)
            {
                return ReadExpression(new Plus(left, ReadTerm()));
            }
            return root;
        }
        private bool IsTokenPlusOrMinus(Token token)
        {
            return token.Type == TokenType.PLUS || token.Type == TokenType.MINUS;
        }

        /// <summary>
        /// term = factor {("*"|"/") factor} . 
        /// </summary>
        /// <returns>BinaryExpression</returns>
        public Expression ReadTerm()
        {
            return ReadTerm(null);
        }

        private Expression ReadTerm(BinaryExpression root)
        {
            Expression left, right;
            if (root == null)
                left = ReadFactor();
            else
                left = root;

            if (IsTokenMultiplyOrDivide(PeekToken()))
            {
                TokenType type = ReadToken().Type;
                right = ReadFactor();
                if (type == TokenType.MULTIPLY)
                    return ReadTerm(new Multiply(left, right));
                else
                    return ReadTerm(new Divide(left, right));
            }

            if (root != null)
                return root;
            else
                return left;
        }

        private bool IsTokenMultiplyOrDivide(Token token)
        {
            return token.Type == TokenType.MULTIPLY || token.Type == TokenType.DIVIDE;
        }


        private Expression ReadFactor()
        {
            Token token = PeekToken();
            if (token.Type == TokenType.VAR)
            {
                TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.VAR);
                TokenTypeComparatorAndExceptionThrower(PeekToken(), TokenType.IDENT);
                return new VariableExpression(((IdentifierToken)ReadToken()).Value);
            }
            else if (token.Type == TokenType.NUMBER)
                return new ValueExpression(((NumberToken)ReadToken()).Value);
            else if (token.Type == TokenType.TEXT)
                return new ValueExpression(((TextToken)ReadToken()).Value);
            else if (token.Type == TokenType.LEFT_BRACKET)
            {
                TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.LEFT_BRACKET);
                Expression expression = ReadExpression();
                TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.RIGHT_BRACKET);
                return expression;
            }
            else
                throw new Exception($"Invalid expression token; got: {token.Type} on line {token.LineNumber}");
        }

        private Statement ReadStatement()
        {
            Token token = PeekToken();
            return token.Type switch
            {
                TokenType.VAR => ReadDeclareStatement(), 
                TokenType.IDENT => ReadCallStatement(),
                TokenType.READ => ReadReadStatement(),
                TokenType.READNUM => ReadReadNumStatement(),
                TokenType.WRITE => ReadWriteStatement(),
                TokenType.IF => ReadIfStatement(),
                TokenType.WHILE => ReadWhileStatement(),
                _ => throw new Exception($"Exprected Statement token; got {token.Type} on line {token.LineNumber}"),
            };
        }


        private Statement ReadDeclareStatement()
        {
            Statement statement;
            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.VAR);

            TokenTypeComparatorAndExceptionThrower(PeekToken(), TokenType.IDENT);
            string ident = ((IdentifierToken)ReadToken()).Value;

            Token token = PeekToken();

            if (token.Type == TokenType.SET)
            {
                statement = ReadSetStatement(ident);
            }
            else if (token.Type == TokenType.SEMICOLON)
            {
                statement = new DeclareStatement(ident);
            }
            else
                throw new Exception($"Expected Token: SET or SEMICOLON; got Token: {token.Type}, on line: {token.LineNumber}");

            return statement;
        }

        private Statement ReadSetStatement(string ident)
        {
            Statement statement;
            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.SET);

            statement = new SetStatement(ident)
            {
                Expression = ReadExpression()
            };

            return statement;
        }


        private Statement ReadCallStatement()
        {
            CallStatement statement = new CallStatement(); 
            
            TokenTypeComparatorAndExceptionThrower(PeekToken(), TokenType.IDENT);
            statement.Ident = ((IdentifierToken)ReadToken()).Value;

            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.LEFT_BRACKET);

            
            bool first = true;
            while (PeekToken().Type != TokenType.RIGHT_BRACKET)
            {
                if (!first)
                {
                    TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.COMMA);
                }
                statement.Parameters.Add(ReadExpression());

                first = false;
            }

            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.RIGHT_BRACKET);

            return statement;
        }

        private Statement ReadReadStatement()
        {
            ReadStatement statement = new ReadStatement();
            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.READ);
            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.VAR);

            TokenTypeComparatorAndExceptionThrower(PeekToken(), TokenType.IDENT);
            statement.Ident = ((IdentifierToken)ReadToken()).Value;

            return statement;
        }

        private Statement ReadReadNumStatement()
        {
            ReadNumStatement statement = new ReadNumStatement();
            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.READNUM);
            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.VAR);

            TokenTypeComparatorAndExceptionThrower(PeekToken(), TokenType.IDENT);
            statement.Ident = ((IdentifierToken)ReadToken()).Value;

            return statement;
        }


        private Statement ReadWriteStatement()
        {
            WriteStatement statement = new WriteStatement();
            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.WRITE);

            statement.Expression = ReadExpression();

            return statement;

        }

        private Statement ReadIfStatement()
        {
            IfStatement statement = new IfStatement();
            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.IF);
            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.LEFT_BRACKET);

            statement.Condition = ReadCondition();

            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.RIGHT_BRACKET);

            statement.Block = ReadBlock();

            return statement;
        }

        private Statement ReadWhileStatement()
        {
            WhileStatement statement = new WhileStatement();
            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.WHILE);
            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.LEFT_BRACKET);

            statement.Condition = ReadCondition();

            TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.RIGHT_BRACKET);

            statement.Block = ReadBlock();

            return statement;
        }

        private Condition ReadCondition()
        {
            Token token = PeekToken();
            if (token.Type == TokenType.ODD)
            {
                TokenTypeComparatorAndExceptionThrower(ReadToken(), TokenType.ODD);
                return new OddCondition(ReadExpression());
            }
            else
            {
                Expression left = ReadExpression();

                return ReadToken().Type switch
                {
                    TokenType.EQUALS => new Equal(left, ReadExpression()),
                    TokenType.NOT_EQUAL => new NotEqual(left, ReadExpression()),
                    TokenType.LESS => new Less(left, ReadExpression()),
                    TokenType.LESS_EQUALS => new LessEqual(left, ReadExpression()),
                    TokenType.MORE => new More(left, ReadExpression()),
                    TokenType.MORE_EQUALS => new MoreEqual(left, ReadExpression()),
                    _ => throw new Exception($"Exprected Relation token; got {token.Type} on line {token.LineNumber}")
                };
            }
        }

        private Token PeekToken()
        {
            return tokens.Peek();
        }
        private Token ReadToken()
        {
            return tokens.Dequeue();
        }

        private void TokenTypeComparatorAndExceptionThrower(Token token, TokenType desiredTokenType)
        {
            if (token.Type != desiredTokenType)
                throw new Exception($"On Line: {token.LineNumber} was expected Token: {desiredTokenType.ToString()}, got Token: {token.Type.ToString()}");
        }


    }
}
