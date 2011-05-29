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

using Unicoen.Core.Visitors;

namespace Unicoen.Core.Model {
	/// <summary>
	///   catch節を表します。
	///   e.g. Javaにおける<c>try{...}catch(Exception e){...}</c>の<c>catch(Exception e){...}</c>の部分
	/// </summary>
	public class UnifiedCatch : UnifiedExpressionWithBlock<UnifiedCatch> {
		private UnifiedMatcherCollection _matchers;

		/// <summary>
		///   catch節内の仮引数の集合を表します
		///   e.g. <c>catch(Exception e){...}</c>の<c>Exception e</c>
		/// </summary>
		public UnifiedMatcherCollection Matchers {
			get { return _matchers; }
			set { _matchers = SetChild(value, _matchers); }
		}

		private UnifiedCatch() {}

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

		public static UnifiedCatch Create(
				UnifiedMatcherCollection matchers,
				UnifiedBlock body) {
			return new UnifiedCatch {
					Matchers = matchers,
					Body = body,
			};
		}
	}
}