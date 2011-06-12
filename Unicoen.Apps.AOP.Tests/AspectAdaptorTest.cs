﻿#region License

// Copyright (C) 2011 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System.IO;
using Antlr.Runtime;
using Antlr.Runtime.Tree;
using NUnit.Framework;
using Paraiba.Text;
using Unicoen.Apps.Aop.Visitor;
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.Apps.Aop.Tests {
	/// <summary>
	///   AspectAdaptorを用いたコードの合成が正しく行われるかテストします
	/// </summary>
	[TestFixture]
	public class AspectAdaptorTest {
		private const string JavaCodePath =
				"../../fixture/AspectCompiler/input/JavaSample.java";

		private const string JavaScriptCodePath =
				"../../fixture/AspectCompiler/input/JavaScriptSample.js";

		private UnifiedProgram _javaModel;
		private UnifiedProgram _javaScriptModel;

		/// <summary>
		///   基準となるソースコードをモデルに変換します
		/// </summary>
		[SetUp]
		public void Setup() {
			//Java言語のモデルを作成
			var javaCode = File.ReadAllText(JavaCodePath, XEncoding.SJIS);
			_javaModel = CodeProcessor.CreateModel(".java", javaCode);

			//JavaScript言語のモデルを作成
			var javaScriptCode = File.ReadAllText(JavaScriptCodePath, XEncoding.SJIS);
			_javaScriptModel = CodeProcessor.CreateModel(".js", javaScriptCode);
		}

		public AstVisitor CreateAspectElement(string path) {
			//アスペクトファイルの生成
			var aspect = new ANTLRFileStream(path);
			var lexer = new AriesLexer(aspect);
			var tokens = new CommonTokenStream(lexer);
			var parser = new AriesParser(tokens);

			//アスペクトファイルを解析してASTを生成する
			var result = parser.aspect();
			var ast = (CommonTree)result.Tree;

			var visitor = new AstVisitor();
			visitor.Visit(ast, 0, null);

			return visitor;
		}

		[Test]
		public void Java言語の関数実行前にコードが正しく合成される() {
			//アスペクトモデルの作成
			const string aspectPath =
					"../../fixture/AspectCompiler/input/partial_aspect/before_execution.txt";
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("Java", _javaModel, visitor);

			//期待されるモデルの作成
			const string filePath =
					"../../fixture/AspectCompiler/input/expectation/before_execution.java";
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".java", code);

			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaModel, expectation),
					Is.True);
		}

		//TODO このケースだとbeforeとafterのコード挿入位置が変わらないので、もっといいテストケースを用意する
		[Test]
		public void Java言語の関数実行後にコードが正しく合成される() {
			//アスペクトモデルの作成
			const string aspectPath =
					"../../fixture/AspectCompiler/input/partial_aspect/after_execution.txt";
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("Java", _javaModel, visitor);

			//期待されるモデルの作成
			const string filePath =
					"../../fixture/AspectCompiler/input/expectation/after_execution.java";
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".java", code);

			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaModel, expectation),
					Is.True);
		}

		[Test]
		public void Java言語の関数呼び出し前にコードが正しく合成される() {
			//アスペクトモデルの作成
			const string aspectPath =
					"../../fixture/AspectCompiler/input/partial_aspect/before_call.txt";
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("Java", _javaModel, visitor);

			//期待されるモデルの作成
			const string filePath =
					"../../fixture/AspectCompiler/input/expectation/before_call.java";
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".java", code);

			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaModel, expectation),
					Is.True);
		}

		[Test]
		public void Java言語の関数呼び出し後にコードが正しく合成される() {
			//アスペクトモデルの作成
			const string aspectPath =
					"../../fixture/AspectCompiler/input/partial_aspect/after_call.txt";
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("Java", _javaModel, visitor);

			//期待されるモデルの作成
			const string filePath =
					"../../fixture/AspectCompiler/input/expectation/after_call.java";
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".java", code);

			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaModel, expectation),
					Is.True);
		}

		[Test]
		public void JavaScript言語の関数実行前にコードが正しく合成される() {
			//アスペクトモデルの作成
			const string aspectPath =
					"../../fixture/AspectCompiler/input/partial_aspect/before_execution.txt";
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("JavaScript", _javaScriptModel, visitor);

			//期待されるモデルの作成
			const string filePath =
					"../../fixture/AspectCompiler/input/expectation/before_execution.js";
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".js", code);

			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaScriptModel, expectation),
					Is.True);
		}

		[Test]
		public void JavaScript言語の関数実行後にコードが正しく合成される() {
			//アスペクトモデルの作成
			const string aspectPath =
					"../../fixture/AspectCompiler/input/partial_aspect/after_execution.txt";
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("JavaScript", _javaScriptModel, visitor);

			//期待されるモデルの作成
			const string filePath =
					"../../fixture/AspectCompiler/input/expectation/after_execution.js";
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".js", code);

			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaScriptModel, expectation),
					Is.True);
		}

		//TODO InsertAtBeforeCallの修正待ち
		[Test, Ignore]
		public void JavaScript言語の関数呼び出し前にコードが正しく合成される() {
			//アスペクトモデルの作成
			const string aspectPath =
					"../../fixture/AspectCompiler/input/partial_aspect/before_call.txt";
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("JavaScript", _javaScriptModel, visitor);

			//期待されるモデルの作成
			const string filePath =
					"../../fixture/AspectCompiler/input/expectation/before_call.js";
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".js", code);

			var a = _javaScriptModel.ToString();
			var b = expectation.ToString();

			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaScriptModel, expectation),
					Is.True);
		}

		//TODO InsertAtBeforeCallの修正待ち
		[Test, Ignore]
		public void JavaScript言語の関数呼び出し後にコードが正しく合成される() {
			//アスペクトモデルの作成
			const string aspectPath =
					"../../fixture/AspectCompiler/input/partial_aspect/after_call.txt";
			var visitor = CreateAspectElement(aspectPath);

			//アスペクトの合成処理
			AspectAdaptor.Weave("JavaScript", _javaScriptModel, visitor);

			//期待されるモデルの作成
			const string filePath =
					"../../fixture/AspectCompiler/input/expectation/after_call.js";
			var code = File.ReadAllText(filePath, XEncoding.SJIS);
			var expectation = CodeProcessor.CreateModel(".js", code);

			Assert.That(
					StructuralEqualityComparer.StructuralEquals(_javaScriptModel, expectation),
					Is.True);
		}

		//TODO インタータイプ宣言に関するテストの追加
	}
}