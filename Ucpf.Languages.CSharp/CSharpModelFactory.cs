﻿using System;
using System.IO;
using System.Linq;
using ICSharpCode.NRefactory;
using ICSharpCode.NRefactory.Ast;
using Ucpf.Common.Model;
using ICSharpCode.NRefactory.Parser;

namespace Ucpf.Languages.CSharp {

	public class CSharpModelFactory {

		public static UnifiedElement CreateModel(string code) {
			var reader = new StringReader(code);
			using (var parser = ParserFactory.CreateParser(SupportedLanguage.CSharp, reader)) {
				parser.Parse();
				var unit = parser.CompilationUnit;
				var visitor = new Translator();
				return unit.AcceptVisitor(visitor, null) as UnifiedElement;
			}
		}
	}

}