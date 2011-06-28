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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Paraiba.Core;
using Unicoen.Core.Processor;
using Unicoen.Core.Tests;
using Unicoen.Languages.Tests;

namespace Unicoen.Languages.JavaScript.Tests {
	public class JavaScriptFixture : Fixture {
		private const string CompileCommand = "java";

		private readonly string[] _compileArguments;

		public JavaScriptFixture() {
			_compileArguments = new[] {
					"-cp",
					SetUpRhino(),
					"org.mozilla.javascript.tools.jsc.Main"
			};
		}

		/// <summary>
		///   対応する言語のソースコードの拡張子を取得します．
		/// </summary>
		public override string Extension {
			get { return ".js"; }
		}

		/// <summary>
		///   対応する言語のソースコードの拡張子を取得します．
		/// </summary>
		public override string CompiledExtension {
			get { return ".class"; }
		}

		/// <summary>
		///   対応する言語のモデル生成器を取得します．
		/// </summary>
		public override ModelFactory ModelFactory {
			get { return JavaScriptFactory.ModelFactory; }
		}

		/// <summary>
		///   対応する言語のコード生成器を取得します．
		/// </summary>
		public override CodeFactory CodeFactory {
			get { return JavaScriptFactory.CodeFactory; }
		}

		/// <summary>
		///   テスト時に入力されるA.xxxファイルのメソッド宣言の中身です。
		///   Java言語であれば，<c>class A { public void M1() { ... } }</c>の...部分に
		///   このプロパティで指定されたコード断片を埋め込んでA.javaファイルが生成されます。
		/// </summary>
		public override IEnumerable<TestCaseData> TestCodes {
			get {
				return new[] {
						"var a = 1;",
				}.Select(s => new TestCaseData(s));
			}
		}

		/// <summary>
		///   テスト時に入力するファイルパスの集合です．
		/// </summary>
		public override IEnumerable<TestCaseData> TestFilePathes {
			get {
				// 必要に応じて以下の要素をコメントアウト
				return new[] {
						"fibonacci",
						"student",
				}
						.Select(
								s =>
								new TestCaseData(
										FixtureUtil.GetInputPath(LanguageName, s + Extension)));
			}
		}

		/// <summary>
		///   テスト時に入力するプロジェクトファイルのパスとコンパイル処理の組み合わせの集合です．
		/// </summary>
		public override IEnumerable<TestCaseData> TestProjectInfos {
			get {
				var arguments = _compileArguments.JoinString(" ") + " *.js";
				return new[] {
						new {
								DirName = "Blocks",
								Command = CompileCommand,
								Arguments = arguments,
						},
						new {
								DirName = "Waseda",
								Command = CompileCommand,
								Arguments = arguments,
						},
				}
						.Select(
								o => {
									Action<string> action = s => CompileWithArguments(s, o.Command, o.Arguments);
									return new TestCaseData(FixtureUtil.GetInputPath(LanguageName, o.DirName), action);
								})
								.Concat(new [] {
										SetUpjQuery(),
			});
			}
		}

		public override IEnumerable<TestCaseData> TestHeavyProjectInfos {
			get { yield break; }
		}

		/// <summary>
		///   セマンティクスの変化がないか比較するためにソースコードをデフォルトの設定でコンパイルします．
		/// </summary>
		/// <param name = "dirPath">コンパイル対象のソースコードが格納されているディレクトリのパス</param>
		/// <param name = "fileName">コンパイル対象のソースコードのファイル名</param>
		public override void Compile(string dirPath, string fileName) {
			var args = _compileArguments.Concat(
					new[] {
							"\"" + Path.Combine(dirPath, fileName) + "\""
					});
			//e.g. (java) -cp js.jar org.mozilla.javascript.tools.jsc.Main **.js
			var arguments = args.JoinString(" ");
			CompileWithArguments(dirPath, CompileCommand, arguments);
		}

		private string SetUpRhino() {
			var path = FixtureUtil.GetDownloadPath(LanguageName, "Rhino");
			var jarPath = Path.Combine(path, "rhino1_7R3", "js.jar");
			if (Directory.Exists(path))
				return jarPath;
			var zipPath = Path.Combine(path, "rhino.zip");
			Directory.CreateDirectory(path);
			FixtureManager.Download(
					"ftp://ftp.mozilla.org/pub/mozilla.org/js/rhino1_7R3.zip", zipPath);
			FixtureManager.Unzip(zipPath);
			return jarPath;
		}

		private TestCaseData SetUpjQuery() {
			var path = FixtureUtil.GetDownloadPath(LanguageName, "jQuery1.6.1");
			const string fileName = "jquery-1.6.1.js";
			var srcPath = Path.Combine(path, fileName);
			Action<string> action = s => Compile(s, fileName);
			var testCase = new TestCaseData(path, action);
			if (Directory.Exists(path))
				return testCase;
			Directory.CreateDirectory(path);
			FixtureManager.Download(
					"http://code.jquery.com/jquery-1.6.1.js", srcPath);
			return testCase;
		}
	}
}