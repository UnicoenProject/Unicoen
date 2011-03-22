﻿using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedProgram : UnifiedElementCollection<UnifiedExpression> {
		public UnifiedProgram() {}

		public UnifiedProgram(IEnumerable<UnifiedExpression> elements)
			: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			return this;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>>
			GetElementsAndSetters() {
			var count = Count;
			for (int i = 0; i < count; i++) {
				yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
					(this[i], v => this[i] = (UnifiedExpression)v);
			}
		}
	}
}