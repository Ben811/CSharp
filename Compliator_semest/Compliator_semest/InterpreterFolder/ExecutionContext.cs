using Compliator_semest.ParserFolder;
using Compliator_semest.ParserFolder.ValueFolder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compliator_semest.InterpreterFolder
{
    public class ExecutionContext
    {
        private readonly ProgramContext _programContext;
        private readonly Variables _variables;
        private readonly ExecutionContext _global;

        public ExecutionContext(List<ProcedureCom> procedures, ExecutionContext global)
        {
            _programContext = new ProgramContext(procedures);
            _variables = new Variables();
            _global = global;
        }

        public ExecutionContext(ExecutionContext global) 
        {
            _programContext = global._programContext;
            _variables = new Variables();
            _global = global;
        }

        public void CallProcedure(string ident, List<Value> parameters)
        {
            bool isCalled = _programContext.Call(ident, this);

            if (_global == null && !isCalled)
                throw new Exception($"Procedure: {ident}, not found");

            if (!isCalled)
                _global.CallProcedure(ident, parameters);
        }

        public Variable GetVariable(string ident)
        {

            var variable = _variables.Get(ident);

            if (_global == null && variable == null)
                throw new Exception($"variable: {ident}, could not get");

            if (variable == null)
                return _global.GetVariable(ident);
            else
                return variable;
        }

        public void SetVariable(string ident, Value value)
        {
            var variable = _variables.Get(ident);

            if (_global == null && variable == null)
                AddVariable(ident, value);
            else if (variable == null)
                _global.SetVariable(ident, value);
            else
                variable.Value = value;


        }

        public void AddVariable(string ident)
        {
            _variables.VarList.Add(new Variable(ident));
        }

        public void AddVariable(string ident, Value value)
        {
            _variables.VarList.Add(new Variable(ident, value));
        }


    }
}
