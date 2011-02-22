﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucpf.Common.Model.Visitors;

namespace Ucpf.Common.Model {
	public class UnifiedReturn : UnifiedStatement {
		public UnifiedExpression Value { get; set; }

		public UnifiedReturn(UnifiedExpression expression) {
			Value = expression;
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}
	}
}
