﻿using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedArrayNew : UnifiedExpression {
		public UnifiedType Type { get; set; }
		public UnifiedArgumentCollection Arguments { get; set; }

		public UnifiedArrayNew() {
			Arguments = new UnifiedArgumentCollection();
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}