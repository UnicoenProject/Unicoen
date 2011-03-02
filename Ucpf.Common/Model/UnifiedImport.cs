﻿using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedImport : UnifiedExpression {
		public string Name { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}