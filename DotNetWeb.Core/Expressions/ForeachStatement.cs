using DotNetWeb.Core.Statements;
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetWeb.Core.Expressions
{
    public class ForeachStatement : Statement
    {
        public ForeachStatement(Token tmpVar, Token token, Statement statement)
        {
            TmpVar = tmpVar;
            Token = token;
            Statement = statement;
        }

        public Token TmpVar { get; }
        public Token Token { get; }
        public Statement Statement { get; }

        public override string Generate()
        {
            throw new NotImplementedException();
        }

        public override void Interpret()
        {
            throw new NotImplementedException();
        }

        public override void ValidateSemantic()
        {
            throw new NotImplementedException();
        }
    }
}
