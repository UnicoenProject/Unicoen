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
using System.Diagnostics.Contracts;
using System.Linq;
using ICSharpCode.NRefactory.CSharp;
using ICSharpCode.NRefactory.TypeSystem;
using Unicoen.Core.Model;

namespace Unicoen.Languages.CSharp.ModelFactories {
	internal partial class NRefactoryModelVisitor {
		#region Lookups

		private static UnifiedClassKind LookupClassKind(ClassType type) {
			switch (type) {
			case ClassType.Class:
				return UnifiedClassKind.Class;
			case ClassType.Struct:
				return UnifiedClassKind.Struct;
			case ClassType.Interface:
				return UnifiedClassKind.Interface;
			}
			throw new InvalidOperationException("LookupClassKind : " + type + "には対応していません。");
		}

		private static UnifiedModifierCollection LookupModifier(Modifiers mods) {
			Contract.Ensures(Contract.Result<UnifiedModifierCollection>() != null);

			var pairs = new[] {
					new { Mod = Modifiers.Public, Name = "public" },
					new { Mod = Modifiers.Protected, Name = "protected" },
					new { Mod = Modifiers.Internal, Name = "internal" },
					new { Mod = Modifiers.Abstract, Name = "abstract" },
					new { Mod = Modifiers.Private, Name = "private" },
					new { Mod = Modifiers.Partial, Name = "partial" },
					new { Mod = Modifiers.Static, Name = "static" },
					new { Mod = Modifiers.Sealed, Name = "sealed" },
					new { Mod = Modifiers.Const, Name = "const" },
					new { Mod = Modifiers.Readonly, Name = "readonly" },
					new { Mod = Modifiers.New, Name = "new" },
					new { Mod = Modifiers.Override, Name = "override" },
					new { Mod = Modifiers.Virtual, Name = "virtual" },
					new { Mod = Modifiers.Extern, Name = "extern" },
					new { Mod = Modifiers.Fixed, Name = "fixed" },
					new { Mod = Modifiers.Unsafe, Name = "unsafe" },
					new { Mod = Modifiers.Volatile, Name = "volatile" },
			};
			var uMods =
					from pair in pairs
					where (mods & pair.Mod) != 0
					select UnifiedModifier.Create(pair.Name);
			return UnifiedModifierCollection.Create(uMods);
		}

		private static UnifiedType LookupType(AstType type) {
			Contract.Requires<ArgumentNullException>(type != null);
			Contract.Ensures(Contract.Result<UnifiedType>() != null);

			var prim = type as PrimitiveType;
			if (prim != null) {
				return UnifiedType.CreateUsingString(prim.Keyword);
			}
			var sim = type as SimpleType;
			if (sim != null) {
				return UnifiedType.CreateUsingString(sim.Identifier);
			}
			var com = type as ComposedType;
			if (com != null) {
				var baseType = LookupType(com.BaseType);
				foreach (var aSpec in  com.ArraySpecifiers) {
					baseType.AddSupplement(UnifiedTypeSupplement.CreateRectangleArray(aSpec.Dimensions));
				}
				return baseType;
			}

			throw new NotImplementedException("LookupType");
		}

		private static UnifiedBinaryOperator LookupBinaryOperator(BinaryOperatorType op) {
			Contract.Ensures(Contract.Result<UnifiedBinaryOperator>() != null);

			switch (op) {
			case BinaryOperatorType.Add:
				return UnifiedBinaryOperator.Create("+", UnifiedBinaryOperatorKind.Add);
			case BinaryOperatorType.Subtract:
				return UnifiedBinaryOperator.Create("-", UnifiedBinaryOperatorKind.Subtract);
			case BinaryOperatorType.Multiply:
				return UnifiedBinaryOperator.Create("*", UnifiedBinaryOperatorKind.Multiply);
			case BinaryOperatorType.Divide:
				return UnifiedBinaryOperator.Create("/", UnifiedBinaryOperatorKind.Divide);

			case BinaryOperatorType.GreaterThan:
				return UnifiedBinaryOperator.Create(">", UnifiedBinaryOperatorKind.GreaterThan);
			case BinaryOperatorType.GreaterThanOrEqual:
				return UnifiedBinaryOperator.Create(">=", UnifiedBinaryOperatorKind.GreaterThanOrEqual);
			case BinaryOperatorType.LessThanOrEqual:
				return UnifiedBinaryOperator.Create("<=", UnifiedBinaryOperatorKind.LessThanOrEqual);
			case BinaryOperatorType.LessThan:
				return UnifiedBinaryOperator.Create("<", UnifiedBinaryOperatorKind.LessThan);

			case BinaryOperatorType.Equality:
				return UnifiedBinaryOperator.Create("==", UnifiedBinaryOperatorKind.Equal);
			case BinaryOperatorType.InEquality:
				return UnifiedBinaryOperator.Create("!=", UnifiedBinaryOperatorKind.NotEqual);

			}
			throw new NotImplementedException("LookupBinaryOperator");
		}

		#endregion

		private static UnifiedLiteral ParseValue(object value) {
			Contract.Ensures(Contract.Result<UnifiedLiteral>() != null);

			if (value == null)
				return UnifiedNullLiteral.Create();
			if (value is string)
				return UnifiedStringLiteral.Create((string)value, UnifiedStringLiteralKind.String);
			if (value is int)
				return UnifiedIntegerLiteral.Create((int)value);

			throw new NotImplementedException("ParseValue");
		}

	}
}