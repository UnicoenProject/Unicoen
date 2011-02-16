﻿using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.Common.CodeGenerators;

namespace Ucpf.Languages.Java.CodeGenerators {
	[Export(typeof(CodeGenerator))]
	public class JavaCodeGenerator : CodeGeneratorBase {
		private static JavaCodeGenerator _instance;

		private JavaCodeGenerator() {}

		public static JavaCodeGenerator Instance {
			get { return _instance ?? (_instance = new JavaCodeGenerator()); }
		}

		public override string ParserName {
			get { return "Java6"; }
		}

		public override string DefaultExtension {
			get { return new[] { ".java" }[0]; }
		}

		protected override bool TreatTerminalSymbol(XElement element) {
			switch (element.Value) {
			case "<":
			case ">":
			case "=":
				WriteWordWithoutWhiteSpace(element.Value);
				break;

			case ";":
				WriteLine(";");
				break;

			case "{":
				WriteLine("{");
				Depth++;
				break;

			case "}":
				Depth--;
				WriteLine("}");
				break;

			default:
				return false;
			}

			return true;
		}
	}
}