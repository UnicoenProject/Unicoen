﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Core.Model;
using Unicoen.Languages.CSharp;
using Unicoen.Languages.Java.ModelFactories;

namespace Unicoen.Apps.AOP.Tests {
	/// <summary>
	/// アスペクト指向プログラミング処理系の作成に辺り，
	/// 共通コードモデル上の特定の要素だけを取得できるかテストする．
	/// </summary>
	/// 
	[TestFixture]
	public class ModelFilterTest {
		private const string filePath =
				@"C:\Users\GreatAS\Desktop\Unicoen\fixture\Java\input\default\Block1.java";

		private string _ext;
		private string _code;
		private UnifiedProgram _model;

		[SetUp]
		public void Setup() {
			_ext = Path.GetExtension(filePath);
			_code = File.ReadAllText(filePath, XEncoding.SJIS);
			_model = Program.CreateModel(_ext, _code);
		}

		[Test]
		[TestCase("method1")]
		public void GetFunctionDefinitionByName(string name) {
			var e = CodeProcessor.GetFunctionDefinitionByName(_model, name);
			Assert.That(e.Name.Value, Is.EqualTo(name));
		}
	}
}