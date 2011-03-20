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

		public override TResult Accept<TData, TResult>(
			IUnifiedModelVisitor<TData, TResult> visitor, TData data) {
			return visitor.Visit(this, data);
		}

		public override IEnumerable<UnifiedElement> GetElements() {
			yield return Operator;
			yield return Operand;
		}

		public override IEnumerable<Tuple<UnifiedElement, Action<UnifiedElement>>> GetElementsAndSetters() {
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Operator, v => Operator = (UnifiedUnaryOperator)v);
			yield return Tuple.Create<UnifiedElement, Action<UnifiedElement>>
				(Operand, v => Operand = (UnifiedExpression)v);
		}

		public override UnifiedElement Normalize() {
			NormalizeChildren();
			var operand = Operand as UnifiedIntegerLiteral;
			if (operand != null) {
				if (Operator.Type == UnifiedUnaryOperatorType.UnaryPlus) {
					return operand;
				}
				if (Operator.Type == UnifiedUnaryOperatorType.Negate) {
					operand.Value = -operand.Value;
					return operand;
				}
			}
			return this;
		}
	}
}