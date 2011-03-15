﻿using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedModifierCollection
		: UnifiedElementCollection<UnifiedModifier> {
		public UnifiedModifierCollection() {}

		public UnifiedModifierCollection(IEnumerable<UnifiedModifier> elements)
			: base(elements) {}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			return this;
		}
		}
}