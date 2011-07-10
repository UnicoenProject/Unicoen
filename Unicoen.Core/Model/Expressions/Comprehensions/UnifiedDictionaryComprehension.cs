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

using Unicoen.Core.Processor;

namespace Unicoen.Core.Model {
	/// <summary>
	///   辞書内包表記を表します．
	/// </summary>
	public class UnifiedDictionaryComprehension
			: UnifiedElement, IUnifiedExpression {
		private UnifiedKeyValue _element;

		/// <summary>
		///   辞書内包表記によって生成される要素部分の式を表します．
		/// </summary>
		public UnifiedKeyValue Element {
			get { return _element; }
			set { _element = SetChild(value, _element); }
		}

		private UnifiedExpressionCollection _generator;

		/// <summary>
		///   辞書内包表記の集合を生成する式を表します．
		/// </summary>
		public UnifiedExpressionCollection Generator {
			get { return _generator; }
			set { _generator = SetChild(value, _generator); }
		}

		private UnifiedDictionaryComprehension() {}

		public override void Accept(IUnifiedVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TArg>(
				IUnifiedVisitor<TArg> visitor, TArg arg) {
			visitor.Visit(this, arg);
		}

		public override TResult Accept<TArg, TResult>(
				IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
			return visitor.Visit(this, arg);
		}

		public static UnifiedDictionaryComprehension Create(
				UnifiedKeyValue element = null,
				UnifiedExpressionCollection generator = null) {
			return new UnifiedDictionaryComprehension {
					Element = element,
					Generator = generator,
			};
		}
			}
}