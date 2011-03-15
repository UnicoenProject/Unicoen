﻿using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedUnaryExpression : UnifiedExpression {
		public UnifiedUnaryOperator Operator { get; set; }
		public UnifiedExpression Operand { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Operator;
			yield return Operand;
		}
	}
}
