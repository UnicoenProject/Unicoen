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
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   Cast式を表します。
	///   e.g. Javaにおける<c>(int)a</c>
	/// </summary>
	public class UnifiedCast : UnifiedElement, IUnifiedExpression {
		private UnifiedType _type;

		/// <summary>
		///   キャスト先の型を表します
		///   e.g. Javaにおける<c>(int)a</c>の<c>int</c>
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetParentOfChild(value, _type); }
		}

		private IUnifiedExpression _expression;

		/// <summary>
		///   キャスト対象の式を表します
		///   e.g. Javaにおける<c>(int)a</c>の<c>a</c>
		/// </summary>
		public IUnifiedExpression Expression {
			get { return _expression; }
			set { _expression = SetParentOfChild(value, _expression); }
		}

		private UnifiedCast() {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData state) {
			visitor.Visit(this, state);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData state) {
			return visitor.Visit(this, state);
		}

		public override IEnumerable<IUnifiedElement> GetElements() {
			yield return Type;
			yield return Expression;
		}

		public override IEnumerable<ElementReference<IUnifiedElement>>
				GetElementAndSetters() {
			yield return ElementReference.Create
					(Type, v => Type = (UnifiedType)v);
			yield return ElementReference.Create
					(Expression, v => Expression = (IUnifiedExpression)v);
		}

		public override IEnumerable<ElementReference<IUnifiedElement>>
				GetElementAndDirectSetters() {
			yield return ElementReference.Create
					(_type, v => _type = (UnifiedType)v);
			yield return ElementReference.Create
					(_expression, v => _expression = (IUnifiedExpression)v);
		}

		public static UnifiedCast Create(
				UnifiedType type,
				IUnifiedExpression createExpression) {
			return new UnifiedCast {
					Type = type,
					Expression = createExpression
			};
		}
	}
}