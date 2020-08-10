using Compliator_semest.InterpreterFolder;

namespace Compliator_semest.ParserFolder.StatementFolder
{
    public class DeclareStatement : Statement
    {
        public string Ident { get; set; }

        public DeclareStatement(string ident)
        {
            Ident = ident;
        }

        public override void Execute(ExecutionContext context)
        {
            context.AddVariable(Ident);
        }
    }
}
