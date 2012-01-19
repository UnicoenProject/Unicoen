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

using System.Diagnostics;
using Unicoen.Processor;

namespace Unicoen.Model {
    /// <summary>
    ///   try文を表します。 e.g. Javaにおける <c>try { ... } catch(Exception e) { ... }</c>
    /// </summary>
    public class UnifiedTry : UnifiedElement, IUnifiedExpression {
        private UnifiedBlock _body;
        private UnifiedCatchCollection _catches;
        private UnifiedBlock _elseBody;
        private UnifiedBlock _finallyBody;
        private UnifiedTry() {}

        /// <summary>
        ///   catch節の集合を取得もしくは設定します． e.g. Javaにおける <c>try { ... } catch(Exception e) { ... }</c> の <c>catch(Exception e) { ... }</c>
        /// </summary>
        public UnifiedCatchCollection Catches {
            get { return _catches; }
            set { _catches = SetChild(value, _catches); }
        }

        /// <summary>
        ///   ブロックを取得もしくは設定します．
        /// </summary>
        public UnifiedBlock Body {
            get { return _body; }
            set { _body = SetChild(value, _body); }
        }

        /// <summary>
        ///   else節のブロックを取得もしくは設定します． e.g. Pythonにおける <c>try: ...  else: ... finally: ...</c> の <c>else: ...</c>
        /// </summary>
        public UnifiedBlock ElseBody {
            get { return _elseBody; }
            set { _elseBody = SetChild(value, _elseBody); }
        }

        /// <summary>
        ///   finally節のブロックを取得もしくは設定します． e.g. Javaにおける <c>try{...}catch(Exception e){...}finally{...}</c> の <c>finally{...}</c>
        /// </summary>
        public UnifiedBlock FinallyBody {
            get { return _finallyBody; }
            set { _finallyBody = SetChild(value, _finallyBody); }
        }

        #region IUnifiedExpression Members

        [DebuggerStepThrough]
        public override void Accept(IUnifiedVisitor visitor) {
            visitor.Visit(this);
        }

        [DebuggerStepThrough]
        public override void Accept<TArg>(
                IUnifiedVisitor<TArg> visitor,
                TArg arg) {
            visitor.Visit(this, arg);
        }

        [DebuggerStepThrough]
        public override TResult Accept<TArg, TResult>(
                IUnifiedVisitor<TArg, TResult> visitor, TArg arg) {
            return visitor.Visit(this, arg);
        }

        #endregion

        public static UnifiedTry Create(
                UnifiedBlock body = null,
                UnifiedCatchCollection catches = null,
                UnifiedBlock elseBody = null,
                UnifiedBlock finallyBody = null) {
            return new UnifiedTry {
                    Body = body,
                    Catches = catches,
                    ElseBody = elseBody,
                    FinallyBody = finallyBody,
            };
        }
    }
}