﻿#region License

// Copyright (C) 2011 The Unicoen Project
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

namespace Unicoen.Core.Model {
	public abstract class UnifiedWrapType : UnifiedType {
		private UnifiedType _type;

		/// <summary>
		///   修飾しているベースとなる型を取得します．
		/// </summary>
		public UnifiedType Type {
			get { return _type; }
			set { _type = SetChild(value, _type); }
		}

		/// <summary>
		///   型の名前を表します．
		///   e.g. Javaにおける<c>Package.ClassA instance = null;</c>の<c>Package.ClassA</c>(UnifiedPropertyで表現される)
		/// </summary>
		public override IUnifiedExpression NameExpression {
			get { return Type.NameExpression; }
			set { Type.NameExpression = value; }
		}
	}
}