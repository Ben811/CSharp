using Compliator_semest.LexerFolder;
using Compliator_semest.ParserFolder;
using Compliator_semest.InterpreterFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest
{
    public class MainClass
    {
        static void Main()
        {
            try
            {
                Lexer lexer = new Lexer(FileTxtReader.ReadFile("../../../textProgram.txt"));                
                Parser parser = new Parser(lexer.Tokenize());
                Interpreter interpreter = new Interpreter(parser.Parse());
                interpreter.Execute();
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Program Termination");
                Console.WriteLine(ex.Message);
                
            }

        }
    }
}
