﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Ucpf.CodeModel;

namespace Ucpf.Languages.C.CodeModel
{
	public class CUnaryExpression : CExpression, IUnaryExpression
	{
		// properties
		public CUnaryOperator Operator { get; private set; }
		public CExpression Term { get; private set; }

		// constructor
		public CUnaryExpression(CUnaryOperator ope, XElement expNode)
		{
			Operator = ope;
			if (expNode.Name.LocalName == "primary_expression")
			{
				Term = CPrimaryExpression.Create(expNode);
			}
			else {
				Term = CExpression.Create(expNode);
			}
		}

		public override string ToString()
		{
			return Operator.ToString() + Term.ToString();
		}

		// acceptor
		public new void Accept(CCodeModelToCode conv)
		{
			conv.Generate(this);
		}


		IUnaryOperator IUnaryExpression.Operator
		{
			get
			{
				return Operator;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		IExpression IUnaryExpression.Term
		{
			get
			{
				return Term;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		void ICodeElement.Accept(CodeModelToCode.ICodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}
