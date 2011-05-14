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

using System.Collections.Generic;
using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   3項式（条件式）を表します．
	///   Javaにおける<c>a ? b : c</c>
	/// </summary>
	public class UnifiedTernaryExpression : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _condition;

		/// <summary>
		///   3項式の第1オペランドを表します
		///   e.g. Javaにおける<c>a ? b : c</c>の<c>a</c>
		/// </summary>
		public IUnifiedExpression Condition {
			get { return _condition; }
			set { _condition = SetParentOfChild(value, _condition); }
		}

		private IUnifiedExpression _trueExpression;

		/// <summary>
		///   3項式の第2オペランドを表します
		///   Javaにおける<c>a ? b : c</c>の<c>b</c>
		/// </summary>
		public IUnifiedExpression TrueExpression {
			get { return _trueExpression; }
			set { _trueExpression = SetParentOfChild(value, _trueExpression); }
		}

		private IUnifiedExpression _falseExpression;

		/// <summary>
		///   3項式の第3オペランドを表します
		///   Javaにおける<c>a ? b : c</c>の<c>c</c>
		/// </summary>
		public IUnifiedExpression FalseExpression {
			get { return _falseExpression; }
			set { _falseExpression = SetParentOfChild(value, _falseExpression); }
		}

		private UnifiedTernaryExpression() {}

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
			yield return Condition;
			yield return TrueExpression;
			yield return FalseExpression;
		}

		public override IEnumerable<ElementReference>
				GetElementReferences() {
			yield return ElementReference.Create
					(() => Condition, v => Condition = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => TrueExpression, v => TrueExpression = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => FalseExpression, v => FalseExpression = (IUnifiedExpression)v);
		}

		public override IEnumerable<ElementReference>
				GetElementReferenecesOfPrivateFields() {
			yield return ElementReference.Create
					(() => _condition, v => _condition = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => _trueExpression, v => _trueExpression = (IUnifiedExpression)v);
			yield return ElementReference.Create
					(() => _falseExpression, v => _falseExpression = (IUnifiedExpression)v);
		}

		public static UnifiedTernaryExpression Create(
				IUnifiedExpression firstExpression,
				IUnifiedExpression secondExpression,
				IUnifiedExpression lastExpression) {
			return new UnifiedTernaryExpression {
					Condition = firstExpression,
					TrueExpression = secondExpression,
					FalseExpression = lastExpression,
			};
		}
	}
}