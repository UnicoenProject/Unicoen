﻿using System.ComponentModel.Composition;
using System.Xml.Linq;
using Ucpf.CodeGenerators;

namespace OpenCodeProcessorFramework.Languages.Lua
{
	[Export(typeof(ICodeGenerator))]
	public class LuaCodeGenerator : CodeGenerator
	{
		private static LuaCodeGenerator _instance;
		public static LuaCodeGenerator Instance
		{
			get { return _instance ?? (_instance = new LuaCodeGenerator()); }
		}

		private LuaCodeGenerator() { }

		public override string ParserName
		{
			get { return GlobalInformation.LuaLanguage; }
		}

		public override string DefaultExtension
		{
			get { return GlobalInformation.LuaExtensions[0]; }
		}

		protected override bool TreatTerminalSymbol(XElement element)
		{
			switch (element.Value)
			{
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

