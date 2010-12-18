﻿using System.Xml.Linq;
using Ucpf.Languages.JavaScript.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel {
	// returnStatement
	// : 'return' expression? (LT | ';')
	public class JSReturnStatement : JSStatement {

		//constructor
		public JSReturnStatement(XElement node)	: base(node) {
			ReturnExpression = JSExpression.CreateExpression(node.Element("expression"));
		}

		//field
		public JSExpression ReturnExpression { get; private set; }
		
		//function
		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}
	}
}