﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Ucpf.Core.Model;
using Ucpf.Core.Tests;
using Ucpf.Languages.Java.Model;

namespace Ucpf.Languages.Java.Tests {
	[TestFixture]
	public class JavaSpecificationTest {
		[Test]
		[TestCase("while(true) return;")]
		[TestCase("while(true) { return; }")]
		[TestCase("while(true) { { return; } }")]
		public void CreateWhile(string fragment) {
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.WhileModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("do return; while(true);")]
		[TestCase("do { return; } while(true);")]
		[TestCase("do { { return; } } while(true);")]
		public void CreateDoWhile(string fragment) {
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.DoWhileModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("for (int i = 0; i < 1; i++) break;")]
		[TestCase("for (int i = 0; i < 1; i++) { break; }")]
		[TestCase("for (int i = 0; i < 1; i++) { { break; } }")]
		public void CreateFor(string fragment) {
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.ForModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		[TestCase("for (int i : new int[] { 1 }) continue;")]
		[TestCase("for (int i : new int[] { 1 }) { continue; }")]
		[TestCase("for (int i : new int[] { 1 }) { { continue; } }")]
		public void CreateForeach(string fragment) {
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.ForeachModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("if (true) return -1;")]
		[TestCase("if (true) { return -1; }")]
		[TestCase("if (true) { { return -1; } }")]
		[TestCase("if (true) { { { return -1; } } }")]
		public void CreateIf(string fragment) {
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.IfModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("if (false) return -1; else return 0.1;")]
		[TestCase("if (false) { return -1; } else return 0.1;")]
		[TestCase("if (false) return -1; else { return 0.1; }")]
		[TestCase("if (false) { return -1; } else { return 0.1; }")]
		[TestCase("if (false) { { return -1; } } else { return 0.1; }")]
		[TestCase("if (false) { return -1; } else { { return 0.1; } }")]
		[TestCase("if (false) { { return -1; } } else { { return 0.1; } }")]
		[TestCase("if (false) { { { return -1; } } } else { { return 0.1; } }")]
		[TestCase("if (false) { { return -1; } } else { { { return 0.1; } } }")]
		[TestCase("if (false) return -1; else { { { return 0.1; } } }")]
		[TestCase("if (false) { { { return -1; } } } else return 0.1;")]
		[TestCase("if (false) { { { return -1; } } } else { { { return 0.1; } } }")]
		public void CreateIfElse(string fragment) {
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.IfElseModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		[TestCase("new List<List<int>>();")]
		public void CreateNewGenericType(string fragment) {
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.NewGenericTypeModel)
				.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("int a = +1;")]
		public void CreatePlusIntegerLiteral(string fragment) {
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.PlusIntegerLiteralModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("switch (1) { case 1: break; }")]
		public void CreateSwitchCase(string fragment) {
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.SwitchCaseModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Test]
		[TestCase("switch (1) { case 1: break; default: break; }")]
		public void CreateSwitchCaseWithDefault(string fragment) {
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.SwitchCaseWithDefaultModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		[TestCase("Integer i = (Integer)1;")]
		public void CreateCast(string fragment) {
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(null)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}

		[Ignore, Test]
		[TestCase("synchronized (this) { m1(); }")]
		public void CreateSynchronized(string fragment) {
			var code = CSharpAndJavaSpecificationTest.CreateCode(fragment);
			var actual = JavaModelFactory.CreateModel(code);

			Assert.That(actual,
				Is.EqualTo(CSharpAndJavaSpecificationTest.SynchronizedModel)
					.Using(StructuralEqualityComparerForDebug.Instance));
		}
	}
}
