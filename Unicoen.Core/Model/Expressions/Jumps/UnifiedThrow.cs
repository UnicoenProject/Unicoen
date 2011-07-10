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
	public class UnifiedThrow : UnifiedElement, IUnifiedExpression {
		private IUnifiedExpression _value;

		public IUnifiedExpression Value {
			get { return _value; }
			set { _value = SetChild(value, _value); }
		}

		private IUnifiedExpression _data;

		public IUnifiedExpression Data {
			get { return _data; }
			set { _data = SetChild(value, _data); }
		}

		private IUnifiedExpression _trace;

		public IUnifiedExpression Trace {
			get { return _trace; }
			set { _trace = SetChild(value, _trace); }
		}

		protected UnifiedThrow() {}

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

		public static UnifiedThrow Create(
				IUnifiedExpression value = null,
				IUnifiedExpression data = null,
				IUnifiedExpression trace = null
				) {
			return new UnifiedThrow {
					Value = value,
					Data = data,
					Trace = trace,
			};
		}
	}
}