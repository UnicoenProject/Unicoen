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

using System.Diagnostics.Contracts;
using System.Xml.Linq;
using UniUni.Xml.Linq;
using Unicoen.Model;

// ReSharper disable InvocationIsSkipped

namespace Unicoen.Languages.Ruby18.Model {
	public partial class Ruby18ModelFactoryHelper {
		private static void InitializeDefinitions() {
			ExpressionFuncs["defn"] = CreateDefn;
			ExpressionFuncs["class"] = CreateClass;
			ExpressionFuncs["module"] = CreateModule;
			ExpressionFuncs["sclass"] = CreateSclass;

			ExpressionFuncs["defs"] = CreateDefn;
		}

		public static IUnifiedExpression CreateDefn(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "defn" || node.Name() == "defs");
			return UnifiedFunctionDefinition.Create(
					null, null, null, null,
					CreateSymbol(node.NthElement(0)),
					CreateArgs(node.NthElement(1)), null,
					CreateScope(node.NthElement(2)));
		}

		public static UnifiedClassDefinition CreateClass(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "class");
			var constNode = node.NthElement(1);
			var constrain = constNode.Name() != "nil"
			                		? UnifiedExtendConstrain.Create(
			                				UnifiedType.Create(constNode.Value))
			                		: null;
			return UnifiedClassDefinition.Create(
					null, null, CreateSymbol(node.NthElement(0)), null,
					constrain.ToCollection(),
					CreateScope(node.NthElement(2)));
		}

		public static UnifiedClassDefinition CreateModule(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "module");
			return UnifiedClassDefinition.Create(
					null, null, CreateSymbol(node.NthElement(0)), null,
					null,
					CreateScope(node.NthElement(1)));
		}

		public static UnifiedEigenClassDefinition CreateSclass(XElement node) {
			Contract.Requires(node != null);
			Contract.Requires(node.Name() == "sclass");
			return UnifiedEigenClassDefinition.Create(
					null, null, null, null,
					UnifiedEigenConstrain.Create(CreateExpresion(node.NthElement(0))).
							ToCollection(),
					CreateScope(node.NthElement(1)));
		}
	}
}