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
	///   UnifiedTypeの集合を表します。
	/// </summary>
	public class UnifiedTypeCollection
			: UnifiedElementCollection<UnifiedType, UnifiedTypeCollection> {
		private UnifiedTypeCollection() {}

		private UnifiedTypeCollection(IEnumerable<UnifiedType> elements)
				: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override void Accept<TData>(
				IUnifiedModelVisitor<TData> visitor,
				TData data) {
			visitor.Visit(this, data);
		}

		public override TResult Accept<TData, TResult>(
				IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public static UnifiedTypeCollection Create() {
			return new UnifiedTypeCollection();
		}

		public static UnifiedTypeCollection Create(params UnifiedType[] elements) {
			return new UnifiedTypeCollection(elements);
		}

		public static UnifiedTypeCollection Create(IEnumerable<UnifiedType> elements) {
			return new UnifiedTypeCollection(elements);
		}
			}
}