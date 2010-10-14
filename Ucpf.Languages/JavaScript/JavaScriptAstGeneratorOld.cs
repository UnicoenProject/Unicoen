﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Xml.Linq;
using Antlr.Runtime;
using OpenCodeProcessorFramework.Languages.Common.Antlr;
using Ucpf.AstGenerators;
using Ucpf.Weavers;

namespace OpenCodeProcessorFramework.Languages.JavaScript
{
	[Export(typeof(IAstGenerator))]
	public class JavaScriptAstGeneratorOld : AntlrAstGeneratorOld<JavaScriptParser>
	{
		private static JavaScriptAstGeneratorOld _instance;
		public static JavaScriptAstGeneratorOld Instance
		{
			get { return _instance ?? (_instance = new JavaScriptAstGeneratorOld()); }
		}

		private JavaScriptAstGeneratorOld() { }

		protected override Action<JavaScriptParser> DefaultParseAction
		{
			get { return parser => parser.program(); }
		}

		public override string ParserName
		{
			get { return GlobalInformation.JavaScriptLanguage; }
		}

		public override IEnumerable<string> TargetExtensions
		{
			get { return GlobalInformation.JavaScriptExtensions; }
		}

		protected override void ArrangeAst(XElement ast)
		{
			var nodes = GetLackingBlockNodes(ast);
			Weaver.SafeWeaveAround(nodes,
				node => AntlrBlockGenerator.Generate(node, this));
		}

		protected override ITokenSource CreateTokenSource(ICharStream stream)
		{
			return new JavaScriptLexer(stream);
		}

		protected override JavaScriptParser CreateParser(ITokenStream tokenStream)
		{
			return new JavaScriptParser(tokenStream);
		}

		private static IEnumerable<XElement> GetLackingBlockNodes(XElement root)
		{
			var ifs = JavaScriptElements.If(root)
				.SelectMany(JavaScriptElements.IfAndElseProcesses);
			var whiles = JavaScriptElements.While(root)
				.Select(JavaScriptElements.WhileProcess);
			var dos = JavaScriptElements.DoWhile(root)
				.Select(JavaScriptElements.DoWhileProcess);
			var fors = JavaScriptElements.For(root)
				.Select(JavaScriptElements.ForProcess);
			var foreaches = JavaScriptElements.ForEach(root)
				.Select(JavaScriptElements.ForEachProcess);
			var withs = JavaScriptElements.With(root)
				.Select(JavaScriptElements.WithProcess);

			return ifs.Concat(whiles)
				.Concat(dos)
				.Concat(fors)
				.Concat(foreaches)
				.Concat(withs);
		}
	}
}