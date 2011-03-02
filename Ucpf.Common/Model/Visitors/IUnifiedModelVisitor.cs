﻿namespace Ucpf.Common.Model.Visitors {
	public interface IUnifiedModelVisitor {
		void Visit<T>(UnifiedTypedLiteral<T> element);
		void Visit(UnifiedLiteral element);
		void Visit(UnifiedBinaryOperator element);
		void Visit(UnifiedUnaryOperator element);
		void Visit(UnifiedArgument element);
		void Visit(UnifiedArgumentCollection element);
		void Visit(UnifiedBinaryExpression element);
		void Visit(UnifiedBlock element);
		void Visit(UnifiedCall element);
		void Visit(UnifiedFunctionDefinition element);
		void Visit(UnifiedExpressionStatement element);
		void Visit(UnifiedIf element);
		void Visit(UnifiedParameter element);
		void Visit(UnifiedParameterCollection element);
		void Visit(UnifiedReturn element);
		void Visit(UnifiedVariable element);
		void Visit(UnifiedModifier element);
		void Visit(UnifiedModifierCollection element);
	}
}