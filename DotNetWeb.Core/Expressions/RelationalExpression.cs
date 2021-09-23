﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetWeb.Core.Expressions
{
    public class RelationalExpression : TypedBinaryOperator
    {
        private readonly Dictionary<(Type, Type), Type> _typeRules;
        public RelationalExpression(Token token, TypedExpression leftExpression, TypedExpression rightExpression)
            : base(token, leftExpression, rightExpression, null)
        {
            _typeRules = new Dictionary<(Type, Type), Type>
            {
                { (Type.Float, Type.Float), Type.Bool },
                { (Type.Int, Type.Int), Type.Bool },
                { (Type.String, Type.String), Type.Bool },
                { (Type.Float, Type.Int), Type.Bool },
                { (Type.Int, Type.Float), Type.Bool }
            };
        }

        public override dynamic Evaluate()
        {
            return Token.TokenType switch
            {
                TokenType.GreaterThan => LeftExpression.Evaluate() > RightExpression.Evaluate(),
                TokenType.LessThan => LeftExpression.Evaluate() < RightExpression.Evaluate(), 
                TokenType.Equal => LeftExpression.Evaluate() == RightExpression.Evaluate(),
                TokenType.NotEqual => LeftExpression.Evaluate() != RightExpression.Evaluate(),
                _ => throw new NotImplementedException()
            };
        }

        public override string Generate()
        {
            return "";
        }

        public override Type GetExpressionType()
        {
            if (_typeRules.TryGetValue((LeftExpression.GetExpressionType(), RightExpression.GetExpressionType()), out var resultType))
            {
                return resultType;
            }

            throw new ApplicationException($"Cannot perform relational operation on {LeftExpression.GetExpressionType()}, {RightExpression.GetExpressionType()}");
        }
    }
}
