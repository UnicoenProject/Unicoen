﻿using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedProperty : UnifiedExpression {
		public UnifiedExpression Owner { get; set; }
		public string Name { get; set; }

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Owner;
		}
	}
}
