﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Ucpf.Languages.C.CodeModel
{
	public class CLogicalOperator : COperator
	{
		public static new CLogicalOperator Create(XElement opeNode)
		{
			var sw = opeNode.Value;
			switch (sw)
			{
				case "&&":
					return new CLogicalAndOperator();
				case "||":
					return new CLogicalOrOperator();
				default:
					throw new InvalidOperationException("CreateLogicalOperator");
			}
		}

		// constructor
		public CLogicalOperator(string name) : base(name) { }
	}
}
