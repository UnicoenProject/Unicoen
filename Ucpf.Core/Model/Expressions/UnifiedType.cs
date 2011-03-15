﻿using System;
using System.Collections.Generic;
using Ucpf.Core.Model.Visitors;

namespace Ucpf.Core.Model {
	public class UnifiedType : UnifiedElement {
		public string Name { get; set; }

		public static UnifiedType Create(string name) {
			return new UnifiedType {
				Name = name,
			};
		}

		public override void Accept(IUnifiedModelVisitor visitor) {
			visitor.Visit(this);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield break;
		}
	}
}
