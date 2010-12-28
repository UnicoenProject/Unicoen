﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Ucpf.Languages.JavaScript.CodeModel
{
	// statementBlock
	// : '{' LT!* statementList? LT!* '}'
	
    // statementList
	// : statement (LT!* statement)*
	public class JSBlock : JSStatement
	{
		//constructor
		public JSBlock(XElement xElement) : base(xElement) {
			//TODO null check
			Statements = xElement.Element("statementList").Elements("statement")
				.Select(e => JSStatement.CreateStatement(e));
		}

		//field
		public IEnumerable<JSStatement> Statements { get; private set; }

		//function
		public void Accept(JSCodeModelToCode conv)
		{
			conv.Generate(this);
		}

		public override string ToString() {
			string str = null;
			foreach (var stat in Statements) {
				str += stat.ToString();
			}
			return str;
		}
	}
}
