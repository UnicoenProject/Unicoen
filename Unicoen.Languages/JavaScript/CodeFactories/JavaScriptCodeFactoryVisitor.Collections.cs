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
using Unicoen.Core.Model;
using Unicoen.Core.Processor;

namespace Unicoen.Languages.JavaScript.CodeFactories {
	public partial class JavaScriptCodeFactoryVisitor {
		public void VisitCollection<T, TSelf>(
				UnifiedElementCollection<T, TSelf> elements, VisitorArgument arg)
				where T : class, IUnifiedElement
				where TSelf : UnifiedElementCollection<T, TSelf> {
			var decoration = arg.Decoration;
			arg.Write(decoration.MostLeft);
			var splitter = "";
			foreach (var e in elements) {
				arg.Write(splitter);
				arg.Write(decoration.EachLeft);
				e.TryAccept(this, arg);
				arg.Write(decoration.EachRight);
				splitter = decoration.Delimiter;
			}
			arg.Write(decoration.MostRight);
		}

		public override bool Visit(
				UnifiedArgumentCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(
				UnifiedParameterCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(Paren));
			return false;
		}

		public override bool Visit(
				UnifiedModifierCollection element, VisitorArgument arg) {
			//JavaScriptでは修飾子は出現しない
			return false;
		}

		public override bool Visit(
				UnifiedExpressionCollection element, VisitorArgument arg) {
			//現在は使用していない
			throw new InvalidOperationException();
		}

		public override bool Visit(UnifiedCaseCollection element, VisitorArgument arg) {
			arg = arg.IncrementDepth();
			foreach (var caseElement in element) {
				arg.WriteIndent();
				caseElement.TryAccept(this, arg);
			}
			return false;
		}

		public override bool Visit(UnifiedTypeCollection element, VisitorArgument arg) {
			//JavaScriptでは型の列挙は出現しない
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedGenericParameterCollection element, VisitorArgument arg) {
			//JavaScriptでは型パラメータは出現しない
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedIdentifierCollection element, VisitorArgument arg) {
			VisitCollection(element, arg.Set(CommaDelimiter));
			return false;
		}

		public override bool Visit(
				UnifiedMatcherCollection element, VisitorArgument arg) {
			VisitCollection(element, arg);
			return false;
		}

		public override bool Visit(UnifiedAnnotation element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedAnnotationCollection element, VisitorArgument arg) {
			throw new NotImplementedException();
		}

		public override bool Visit(
				UnifiedVariableDefinitionList element, VisitorArgument arg) {
			if (element.Parent is UnifiedFor) {
				arg.Write("var ");
				VisitCollection(element, arg.Set(CommaDelimiter));
			} else {
				VisitCollection(element, arg.Set(SemiColonDelimiter));
			}
			return true;
		}
	}
}