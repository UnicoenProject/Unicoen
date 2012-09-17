﻿#region License

// Copyright (C) 2011-2012 The Unicoen Project
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using Unicoen.Model;

namespace Unicoen.Processor {
	public interface IUnifiedVisitor {
		void Visit(UnifiedBinaryOperator element);
		void Visit(UnifiedUnaryOperator element);
		void Visit(UnifiedArgument element);
		void Visit(UnifiedArgumentCollection element);
		void Visit(UnifiedBinaryExpression element);
		void Visit(UnifiedBlock element);
		void Visit(UnifiedCall element);
		void Visit(UnifiedFunctionDefinition element);
		void Visit(UnifiedIf element);
		void Visit(UnifiedParameter element);
		void Visit(UnifiedParameterCollection element);
		void Visit(UnifiedModifier element);
		void Visit(UnifiedModifierCollection element);
		void Visit(UnifiedImport element);
		void Visit(UnifiedProgram element);
		void Visit(UnifiedNew element);
		void Visit(UnifiedFor element);
		void Visit(UnifiedForeach element);
		void Visit(UnifiedUnaryExpression element);
		void Visit(UnifiedProperty element);
		void Visit(UnifiedExpressionCollection element);
		void Visit(UnifiedWhile element);
		void Visit(UnifiedDoWhile element);
		void Visit(UnifiedIndexer element);
		void Visit(UnifiedGenericArgument element);
		void Visit(UnifiedGenericArgumentCollection element);
		void Visit(UnifiedSwitch element);
		void Visit(UnifiedCaseCollection element);
		void Visit(UnifiedCase element);
		void Visit(UnifiedCatch element);
		void Visit(UnifiedTypeCollection element);
		void Visit(UnifiedCatchCollection element);
		void Visit(UnifiedTry element);
		void Visit(UnifiedCast element);
		void Visit(UnifiedGenericParameterCollection element);
		void Visit(UnifiedTypeConstrainCollection element);
		void Visit(UnifiedGenericParameter element);
		void Visit(UnifiedTernaryExpression element);
		void Visit(UnifiedIdentifierCollection element);
		void Visit(UnifiedLabel element);
		void Visit(UnifiedBooleanLiteral element);
		void Visit(UnifiedFractionLiteral element);
		void Visit(UnifiedBigIntLiteral element);
		void Visit(UnifiedInt8Literal element);
		void Visit(UnifiedInt16Literal element);
		void Visit(UnifiedInt31Literal element);
		void Visit(UnifiedInt32Literal element);
		void Visit(UnifiedInt64Literal element);
		void Visit(UnifiedUInt8Literal element);
		void Visit(UnifiedUInt16Literal element);
		void Visit(UnifiedUInt31Literal element);
		void Visit(UnifiedUInt32Literal element);
		void Visit(UnifiedUInt64Literal element);
		void Visit(UnifiedStringLiteral element);
		void Visit(UnifiedNullLiteral element);
		void Visit(UnifiedUsing element);
		void Visit(UnifiedListComprehension element);
		void Visit(UnifiedListLiteral element);
		void Visit(UnifiedKeyValue element);
		void Visit(UnifiedMapComprehension element);
		void Visit(UnifiedMapLiteral element);
		void Visit(UnifiedSlice element);
		void Visit(UnifiedComment element);
		void Visit(UnifiedAnnotation element);
		void Visit(UnifiedAnnotationCollection element);
		void Visit(UnifiedVariableDefinitionList element);
		void Visit(UnifiedVariableDefinition element);
		void Visit(UnifiedArrayType element);
		void Visit(UnifiedGenericType element);
		void Visit(UnifiedBasicType element);
		void Visit(UnifiedCharLiteral element);
		void Visit(UnifiedIterableLiteral element);
		void Visit(UnifiedArrayLiteral element);
		void Visit(UnifiedSetLiteral element);
		void Visit(UnifiedTupleLiteral element);
		void Visit(UnifiedIterableComprehension element);
		void Visit(UnifiedSetComprehension element);
		void Visit(UnifiedInterfaceDefinition element);
		void Visit(UnifiedClassDefinition element);
		void Visit(UnifiedStructDefinition element);
		void Visit(UnifiedEnumDefinition element);
		void Visit(UnifiedModuleDefinition element);
		void Visit(UnifiedUnionDefinition element);
		void Visit(UnifiedAnnotationDefinition element);
		void Visit(UnifiedNamespaceDefinition element);
		void Visit(UnifiedBreak element);
		void Visit(UnifiedContinue element);
		void Visit(UnifiedReturn element);
		void Visit(UnifiedGoto element);
		void Visit(UnifiedYieldReturn element);
		void Visit(UnifiedYieldBreak element);
		void Visit(UnifiedDelete element);
		void Visit(UnifiedThrow element);
		void Visit(UnifiedAssert element);
		void Visit(UnifiedExec element);
		void Visit(UnifiedStringConversion element);
		void Visit(UnifiedPass element);
		void Visit(UnifiedPrint element);
		void Visit(UnifiedPrintChevron element);
		void Visit(UnifiedWith element);
		void Visit(UnifiedFix element);
		void Visit(UnifiedSynchronized element);
		void Visit(UnifiedConstType element);
		void Visit(UnifiedPointerType element);
		void Visit(UnifiedUnionType element);
		void Visit(UnifiedStructType element);
		void Visit(UnifiedVolatileType element);
		void Visit(UnifiedReferenceType element);
		void Visit(UnifiedConstructor element);
		void Visit(UnifiedStaticInitializer element);
		void Visit(UnifiedInstanceInitializer element);
		void Visit(UnifiedLambda element);
		void Visit(UnifiedConstructorConstrain element);
		void Visit(UnifiedExtendConstrain element);
		void Visit(UnifiedImplementsConstrain element);
		void Visit(UnifiedReferenceConstrain element);
		void Visit(UnifiedSuperConstrain element);
		void Visit(UnifiedValueConstrain element);
		void Visit(UnifiedSuperIdentifier element);
		void Visit(UnifiedThisIdentifier element);
		void Visit(UnifiedLabelIdentifier element);
		void Visit(UnifiedSizeof element);
		void Visit(UnifiedTypeof element);
		void Visit(UnifiedVariableIdentifier element);
		void Visit(UnifiedTypeIdentifier element);
		void Visit(UnifiedRegularExpressionLiteral element);
		void Visit(UnifiedPropertyDefinition element);
		void Visit(UnifiedPropertyDefinitionPart element);
		void Visit(UnifiedSelectQuery element);
		void Visit(UnifiedWhereQuery element);
		void Visit(UnifiedLetQuery element);
		void Visit(UnifiedOrderByQuery element);
		void Visit(UnifiedJoinQuery element);
		void Visit(UnifiedGroupByQuery element);
		void Visit(UnifiedOrderByKeyCollection element);
		void Visit(UnifiedOrderByKey element);
		void Visit(UnifiedLinqExpression element);
		void Visit(UnifiedDefault element);
		void Visit(UnifiedValueIdentifier element);
		void Visit(UnifiedEventDefinition element);
		void Visit(UnifiedFromQuery element);
		void Visit(UnifiedProc element);
		void Visit(UnifiedEigenClassDefinition element);
		void Visit(UnifiedEigenConstrain element);
		void Visit(UnifiedRange element);
		void Visit(UnifiedRetry element);
		void Visit(UnifiedRedo element);
		void Visit(UnifiedSymbolLiteral element);
		void Visit(UnifiedDefined element);
		void Visit(UnifiedAlias element);
		void Visit(UnifiedUncheckedBlock element);
		void Visit(UnifiedCheckedBlock element);
		void Visit(UnifiedCommentCollection element);

		void Visit<TElement>(UnifiedSet<TElement> element)
				where TElement : UnifiedElement;

		void Visit(UnifiedEventDefinitionPart element);
		void Visit(UnifiedDelegateDefinition element);
	}

	public interface IUnifiedVisitor<in TArg> {
		void Visit(UnifiedBinaryOperator element, TArg arg);
		void Visit(UnifiedUnaryOperator element, TArg arg);
		void Visit(UnifiedArgument element, TArg arg);
		void Visit(UnifiedArgumentCollection element, TArg arg);
		void Visit(UnifiedBinaryExpression element, TArg arg);
		void Visit(UnifiedBlock element, TArg arg);
		void Visit(UnifiedCall element, TArg arg);
		void Visit(UnifiedFunctionDefinition element, TArg arg);
		void Visit(UnifiedIf element, TArg arg);
		void Visit(UnifiedParameter element, TArg arg);
		void Visit(UnifiedParameterCollection element, TArg arg);
		void Visit(UnifiedModifier element, TArg arg);
		void Visit(UnifiedModifierCollection element, TArg arg);
		void Visit(UnifiedImport element, TArg arg);
		void Visit(UnifiedProgram element, TArg arg);
		void Visit(UnifiedNew element, TArg arg);
		void Visit(UnifiedFor element, TArg arg);
		void Visit(UnifiedForeach element, TArg arg);
		void Visit(UnifiedUnaryExpression element, TArg arg);
		void Visit(UnifiedProperty element, TArg arg);
		void Visit(UnifiedExpressionCollection element, TArg arg);
		void Visit(UnifiedWhile element, TArg arg);
		void Visit(UnifiedDoWhile element, TArg arg);
		void Visit(UnifiedIndexer element, TArg arg);
		void Visit(UnifiedGenericArgument element, TArg arg);
		void Visit(UnifiedGenericArgumentCollection element, TArg arg);
		void Visit(UnifiedSwitch element, TArg arg);
		void Visit(UnifiedCaseCollection element, TArg arg);
		void Visit(UnifiedCase element, TArg arg);
		void Visit(UnifiedCatch element, TArg arg);
		void Visit(UnifiedTypeCollection element, TArg arg);
		void Visit(UnifiedCatchCollection element, TArg arg);
		void Visit(UnifiedTry element, TArg arg);
		void Visit(UnifiedCast element, TArg arg);
		void Visit(UnifiedGenericParameterCollection element, TArg arg);
		void Visit(UnifiedTypeConstrainCollection element, TArg arg);
		void Visit(UnifiedGenericParameter element, TArg arg);
		void Visit(UnifiedTernaryExpression element, TArg arg);
		void Visit(UnifiedIdentifierCollection element, TArg arg);
		void Visit(UnifiedLabel element, TArg arg);
		void Visit(UnifiedBooleanLiteral element, TArg arg);
		void Visit(UnifiedFractionLiteral element, TArg arg);
		void Visit(UnifiedBigIntLiteral element, TArg arg);
		void Visit(UnifiedInt8Literal element, TArg arg);
		void Visit(UnifiedInt16Literal element, TArg arg);
		void Visit(UnifiedInt31Literal element, TArg arg);
		void Visit(UnifiedInt32Literal element, TArg arg);
		void Visit(UnifiedInt64Literal element, TArg arg);
		void Visit(UnifiedUInt8Literal element, TArg arg);
		void Visit(UnifiedUInt16Literal element, TArg arg);
		void Visit(UnifiedUInt31Literal element, TArg arg);
		void Visit(UnifiedUInt32Literal element, TArg arg);
		void Visit(UnifiedUInt64Literal element, TArg arg);
		void Visit(UnifiedStringLiteral element, TArg arg);
		void Visit(UnifiedNullLiteral element, TArg arg);
		void Visit(UnifiedUsing element, TArg arg);
		void Visit(UnifiedListComprehension element, TArg arg);
		void Visit(UnifiedListLiteral element, TArg arg);
		void Visit(UnifiedKeyValue element, TArg arg);
		void Visit(UnifiedMapComprehension element, TArg arg);
		void Visit(UnifiedMapLiteral element, TArg arg);
		void Visit(UnifiedSlice element, TArg arg);
		void Visit(UnifiedComment element, TArg arg);
		void Visit(UnifiedAnnotation element, TArg arg);
		void Visit(UnifiedAnnotationCollection element, TArg arg);
		void Visit(UnifiedVariableDefinitionList element, TArg arg);
		void Visit(UnifiedVariableDefinition element, TArg arg);
		void Visit(UnifiedArrayType element, TArg arg);
		void Visit(UnifiedGenericType element, TArg arg);
		void Visit(UnifiedBasicType element, TArg arg);
		void Visit(UnifiedCharLiteral element, TArg arg);
		void Visit(UnifiedIterableLiteral element, TArg arg);
		void Visit(UnifiedArrayLiteral element, TArg arg);
		void Visit(UnifiedSetLiteral element, TArg arg);
		void Visit(UnifiedTupleLiteral element, TArg arg);
		void Visit(UnifiedIterableComprehension element, TArg arg);
		void Visit(UnifiedSetComprehension element, TArg arg);
		void Visit(UnifiedInterfaceDefinition element, TArg arg);
		void Visit(UnifiedClassDefinition element, TArg arg);
		void Visit(UnifiedStructDefinition element, TArg arg);
		void Visit(UnifiedEnumDefinition element, TArg arg);
		void Visit(UnifiedModuleDefinition element, TArg arg);
		void Visit(UnifiedUnionDefinition element, TArg arg);
		void Visit(UnifiedAnnotationDefinition element, TArg arg);
		void Visit(UnifiedNamespaceDefinition element, TArg arg);
		void Visit(UnifiedBreak element, TArg arg);
		void Visit(UnifiedContinue element, TArg arg);
		void Visit(UnifiedReturn element, TArg arg);
		void Visit(UnifiedGoto element, TArg arg);
		void Visit(UnifiedYieldReturn element, TArg arg);
		void Visit(UnifiedYieldBreak element, TArg arg);
		void Visit(UnifiedDelete element, TArg arg);
		void Visit(UnifiedThrow element, TArg arg);
		void Visit(UnifiedAssert element, TArg arg);
		void Visit(UnifiedExec element, TArg arg);
		void Visit(UnifiedStringConversion element, TArg arg);
		void Visit(UnifiedPass element, TArg arg);
		void Visit(UnifiedPrint element, TArg arg);
		void Visit(UnifiedPrintChevron element, TArg arg);
		void Visit(UnifiedWith element, TArg arg);
		void Visit(UnifiedFix element, TArg arg);
		void Visit(UnifiedSynchronized element, TArg arg);
		void Visit(UnifiedConstType element, TArg arg);
		void Visit(UnifiedPointerType element, TArg arg);
		void Visit(UnifiedUnionType element, TArg arg);
		void Visit(UnifiedStructType element, TArg arg);
		void Visit(UnifiedVolatileType element, TArg arg);
		void Visit(UnifiedReferenceType element, TArg arg);
		void Visit(UnifiedConstructor element, TArg arg);
		void Visit(UnifiedStaticInitializer element, TArg arg);
		void Visit(UnifiedInstanceInitializer element, TArg arg);
		void Visit(UnifiedLambda element, TArg arg);
		void Visit(UnifiedConstructorConstrain element, TArg arg);
		void Visit(UnifiedExtendConstrain element, TArg arg);
		void Visit(UnifiedImplementsConstrain element, TArg arg);
		void Visit(UnifiedReferenceConstrain element, TArg arg);
		void Visit(UnifiedSuperConstrain element, TArg arg);
		void Visit(UnifiedValueConstrain element, TArg arg);
		void Visit(UnifiedSuperIdentifier element, TArg arg);
		void Visit(UnifiedThisIdentifier element, TArg arg);
		void Visit(UnifiedLabelIdentifier element, TArg arg);
		void Visit(UnifiedSizeof element, TArg arg);
		void Visit(UnifiedTypeof element, TArg arg);
		void Visit(UnifiedVariableIdentifier element, TArg arg);
		void Visit(UnifiedTypeIdentifier element, TArg arg);
		void Visit(UnifiedRegularExpressionLiteral element, TArg arg);
		void Visit(UnifiedPropertyDefinition element, TArg arg);
		void Visit(UnifiedPropertyDefinitionPart element, TArg arg);
		void Visit(UnifiedSelectQuery element, TArg arg);
		void Visit(UnifiedWhereQuery element, TArg arg);
		void Visit(UnifiedLetQuery element, TArg arg);
		void Visit(UnifiedOrderByQuery element, TArg arg);
		void Visit(UnifiedJoinQuery element, TArg arg);
		void Visit(UnifiedGroupByQuery element, TArg arg);
		void Visit(UnifiedOrderByKeyCollection element, TArg arg);
		void Visit(UnifiedOrderByKey element, TArg arg);
		void Visit(UnifiedLinqExpression element, TArg arg);
		void Visit(UnifiedDefault element, TArg arg);
		void Visit(UnifiedValueIdentifier element, TArg arg);
		void Visit(UnifiedEventDefinition element, TArg arg);
		void Visit(UnifiedFromQuery element, TArg arg);
		void Visit(UnifiedProc element, TArg arg);
		void Visit(UnifiedEigenClassDefinition element, TArg arg);
		void Visit(UnifiedEigenConstrain element, TArg arg);
		void Visit(UnifiedRange element, TArg arg);
		void Visit(UnifiedRedo element, TArg arg);
		void Visit(UnifiedRetry element, TArg arg);
		void Visit(UnifiedSymbolLiteral element, TArg arg);
		void Visit(UnifiedDefined element, TArg arg);
		void Visit(UnifiedAlias element, TArg arg);
		void Visit(UnifiedUncheckedBlock element, TArg arg);
		void Visit(UnifiedCheckedBlock element, TArg arg);
		void Visit(UnifiedCommentCollection element, TArg arg);

		void Visit<TElement>(UnifiedSet<TElement> element, TArg arg)
				where TElement : UnifiedElement;

		void Visit(UnifiedEventDefinitionPart element, TArg arg);
		void Visit(UnifiedDelegateDefinition element, TArg arg);
	}

	public interface IUnifiedVisitor<in TArg, out TResult> {
		TResult Visit(UnifiedBinaryOperator element, TArg arg);
		TResult Visit(UnifiedUnaryOperator element, TArg arg);
		TResult Visit(UnifiedArgument element, TArg arg);
		TResult Visit(UnifiedArgumentCollection element, TArg arg);
		TResult Visit(UnifiedBinaryExpression element, TArg arg);
		TResult Visit(UnifiedBlock element, TArg arg);
		TResult Visit(UnifiedCall element, TArg arg);
		TResult Visit(UnifiedFunctionDefinition element, TArg arg);
		TResult Visit(UnifiedIf element, TArg arg);
		TResult Visit(UnifiedParameter element, TArg arg);
		TResult Visit(UnifiedParameterCollection element, TArg arg);
		TResult Visit(UnifiedModifier element, TArg arg);
		TResult Visit(UnifiedModifierCollection element, TArg arg);
		TResult Visit(UnifiedImport element, TArg arg);
		TResult Visit(UnifiedProgram element, TArg arg);
		TResult Visit(UnifiedNew element, TArg arg);
		TResult Visit(UnifiedFor element, TArg arg);
		TResult Visit(UnifiedForeach element, TArg arg);
		TResult Visit(UnifiedUnaryExpression element, TArg arg);
		TResult Visit(UnifiedProperty element, TArg arg);
		TResult Visit(UnifiedExpressionCollection element, TArg arg);
		TResult Visit(UnifiedWhile element, TArg arg);
		TResult Visit(UnifiedDoWhile element, TArg arg);
		TResult Visit(UnifiedIndexer element, TArg arg);
		TResult Visit(UnifiedGenericArgument element, TArg arg);
		TResult Visit(UnifiedGenericArgumentCollection element, TArg arg);
		TResult Visit(UnifiedSwitch element, TArg arg);
		TResult Visit(UnifiedCaseCollection element, TArg arg);
		TResult Visit(UnifiedCase element, TArg arg);
		TResult Visit(UnifiedCatch element, TArg arg);
		TResult Visit(UnifiedTypeCollection element, TArg arg);
		TResult Visit(UnifiedCatchCollection element, TArg arg);
		TResult Visit(UnifiedTry element, TArg arg);
		TResult Visit(UnifiedCast element, TArg arg);
		TResult Visit(UnifiedGenericParameterCollection element, TArg arg);
		TResult Visit(UnifiedTypeConstrainCollection element, TArg arg);
		TResult Visit(UnifiedGenericParameter element, TArg arg);
		TResult Visit(UnifiedTernaryExpression element, TArg arg);
		TResult Visit(UnifiedIdentifierCollection element, TArg arg);
		TResult Visit(UnifiedLabel element, TArg arg);
		TResult Visit(UnifiedBooleanLiteral element, TArg arg);
		TResult Visit(UnifiedFractionLiteral element, TArg arg);
		TResult Visit(UnifiedBigIntLiteral element, TArg arg);
		TResult Visit(UnifiedInt8Literal element, TArg arg);
		TResult Visit(UnifiedInt16Literal element, TArg arg);
		TResult Visit(UnifiedInt31Literal element, TArg arg);
		TResult Visit(UnifiedInt32Literal element, TArg arg);
		TResult Visit(UnifiedInt64Literal element, TArg arg);
		TResult Visit(UnifiedUInt8Literal element, TArg arg);
		TResult Visit(UnifiedUInt16Literal element, TArg arg);
		TResult Visit(UnifiedUInt31Literal element, TArg arg);
		TResult Visit(UnifiedUInt32Literal element, TArg arg);
		TResult Visit(UnifiedUInt64Literal element, TArg arg);
		TResult Visit(UnifiedStringLiteral element, TArg arg);
		TResult Visit(UnifiedNullLiteral element, TArg arg);
		TResult Visit(UnifiedUsing element, TArg arg);
		TResult Visit(UnifiedListComprehension element, TArg arg);
		TResult Visit(UnifiedListLiteral element, TArg arg);
		TResult Visit(UnifiedKeyValue element, TArg arg);
		TResult Visit(UnifiedMapComprehension element, TArg arg);
		TResult Visit(UnifiedMapLiteral element, TArg arg);
		TResult Visit(UnifiedSlice element, TArg arg);
		TResult Visit(UnifiedComment element, TArg arg);
		TResult Visit(UnifiedAnnotation element, TArg arg);
		TResult Visit(UnifiedAnnotationCollection element, TArg arg);
		TResult Visit(UnifiedVariableDefinitionList element, TArg arg);
		TResult Visit(UnifiedVariableDefinition element, TArg arg);
		TResult Visit(UnifiedArrayType element, TArg arg);
		TResult Visit(UnifiedGenericType element, TArg arg);
		TResult Visit(UnifiedBasicType element, TArg arg);
		TResult Visit(UnifiedCharLiteral element, TArg arg);
		TResult Visit(UnifiedIterableLiteral element, TArg arg);
		TResult Visit(UnifiedArrayLiteral element, TArg arg);
		TResult Visit(UnifiedSetLiteral element, TArg arg);
		TResult Visit(UnifiedTupleLiteral element, TArg arg);
		TResult Visit(UnifiedIterableComprehension element, TArg arg);
		TResult Visit(UnifiedSetComprehension element, TArg arg);
		TResult Visit(UnifiedInterfaceDefinition element, TArg arg);
		TResult Visit(UnifiedClassDefinition element, TArg arg);
		TResult Visit(UnifiedStructDefinition element, TArg arg);
		TResult Visit(UnifiedEnumDefinition element, TArg arg);
		TResult Visit(UnifiedModuleDefinition element, TArg arg);
		TResult Visit(UnifiedUnionDefinition element, TArg arg);
		TResult Visit(UnifiedAnnotationDefinition element, TArg arg);
		TResult Visit(UnifiedNamespaceDefinition element, TArg arg);
		TResult Visit(UnifiedBreak element, TArg arg);
		TResult Visit(UnifiedContinue element, TArg arg);
		TResult Visit(UnifiedReturn element, TArg arg);
		TResult Visit(UnifiedGoto element, TArg arg);
		TResult Visit(UnifiedYieldReturn element, TArg arg);
		TResult Visit(UnifiedYieldBreak element, TArg arg);
		TResult Visit(UnifiedDelete element, TArg arg);
		TResult Visit(UnifiedThrow element, TArg arg);
		TResult Visit(UnifiedAssert element, TArg arg);
		TResult Visit(UnifiedExec element, TArg arg);
		TResult Visit(UnifiedStringConversion element, TArg arg);
		TResult Visit(UnifiedPass element, TArg arg);
		TResult Visit(UnifiedPrint element, TArg arg);
		TResult Visit(UnifiedPrintChevron element, TArg arg);
		TResult Visit(UnifiedWith element, TArg arg);
		TResult Visit(UnifiedFix element, TArg arg);
		TResult Visit(UnifiedSynchronized element, TArg arg);
		TResult Visit(UnifiedConstType element, TArg arg);
		TResult Visit(UnifiedPointerType element, TArg arg);
		TResult Visit(UnifiedUnionType element, TArg arg);
		TResult Visit(UnifiedVolatileType element, TArg arg);
		TResult Visit(UnifiedStructType element, TArg arg);
		TResult Visit(UnifiedReferenceType element, TArg arg);
		TResult Visit(UnifiedConstructor element, TArg arg);
		TResult Visit(UnifiedStaticInitializer element, TArg arg);
		TResult Visit(UnifiedInstanceInitializer element, TArg arg);
		TResult Visit(UnifiedLambda element, TArg arg);
		TResult Visit(UnifiedConstructorConstrain element, TArg arg);
		TResult Visit(UnifiedExtendConstrain element, TArg arg);
		TResult Visit(UnifiedImplementsConstrain element, TArg arg);
		TResult Visit(UnifiedReferenceConstrain element, TArg arg);
		TResult Visit(UnifiedSuperConstrain element, TArg arg);
		TResult Visit(UnifiedValueConstrain element, TArg arg);
		TResult Visit(UnifiedSuperIdentifier element, TArg arg);
		TResult Visit(UnifiedThisIdentifier element, TArg arg);
		TResult Visit(UnifiedLabelIdentifier element, TArg arg);
		TResult Visit(UnifiedSizeof element, TArg arg);
		TResult Visit(UnifiedTypeof element, TArg arg);
		TResult Visit(UnifiedVariableIdentifier element, TArg arg);
		TResult Visit(UnifiedTypeIdentifier element, TArg arg);
		TResult Visit(UnifiedRegularExpressionLiteral element, TArg arg);
		TResult Visit(UnifiedPropertyDefinition element, TArg arg);
		TResult Visit(UnifiedPropertyDefinitionPart element, TArg arg);
		TResult Visit(UnifiedSelectQuery element, TArg arg);
		TResult Visit(UnifiedWhereQuery element, TArg arg);
		TResult Visit(UnifiedLetQuery element, TArg arg);
		TResult Visit(UnifiedOrderByQuery element, TArg arg);
		TResult Visit(UnifiedJoinQuery element, TArg arg);
		TResult Visit(UnifiedGroupByQuery element, TArg arg);
		TResult Visit(UnifiedOrderByKeyCollection element, TArg arg);
		TResult Visit(UnifiedOrderByKey element, TArg arg);
		TResult Visit(UnifiedLinqExpression element, TArg arg);
		TResult Visit(UnifiedDefault element, TArg arg);
		TResult Visit(UnifiedValueIdentifier element, TArg arg);
		TResult Visit(UnifiedEventDefinition element, TArg arg);
		TResult Visit(UnifiedFromQuery element, TArg arg);
		TResult Visit(UnifiedProc element, TArg arg);
		TResult Visit(UnifiedEigenClassDefinition element, TArg arg);
		TResult Visit(UnifiedEigenConstrain element, TArg arg);
		TResult Visit(UnifiedRange element, TArg arg);
		TResult Visit(UnifiedRedo element, TArg arg);
		TResult Visit(UnifiedRetry element, TArg arg);
		TResult Visit(UnifiedSymbolLiteral element, TArg arg);
		TResult Visit(UnifiedDefined element, TArg arg);
		TResult Visit(UnifiedAlias element, TArg arg);
		TResult Visit(UnifiedUncheckedBlock element, TArg arg);
		TResult Visit(UnifiedCheckedBlock element, TArg arg);
		TResult Visit(UnifiedCommentCollection element, TArg arg);

		TResult Visit<TElement>(UnifiedSet<TElement> element, TArg arg)
				where TElement : UnifiedElement;

		TResult Visit(UnifiedEventDefinitionPart element, TArg arg);
		TResult Visit(UnifiedDelegateDefinition element, TArg arg);
	}
}