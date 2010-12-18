﻿using System;
using System.Xml.Linq;
using Ucpf.CodeModel;

namespace Ucpf.Languages.JavaScript.CodeModel {

	public class JSUnaryOperator {

		//constructor
		public JSUnaryOperator(string sign, UnaryOperatorType type) {
			Sign = sign;
			Type = type;
		}

		//field
		public string Sign { get; private set; }
		public UnaryOperatorType Type { get; private set; }

		//function
		public static JSUnaryOperator CreatePrefixOperator(XElement node) {
			string name = node.Value;
			UnaryOperatorType type;

			if ( name == "++") {
				type = UnaryOperatorType.PrefixIncrement;
			}
			else {
				throw new InvalidOperationException();
			}

			return new JSUnaryOperator(name, type);
		}

		public static JSUnaryOperator CreatePostfixOperator(XElement node) {
			string name = node.Value;
			UnaryOperatorType type;

			if ( name == "++") {
				type = UnaryOperatorType.PostfixIncrement;
			}
			else {
				throw new InvalidOperationException();
			}

			return new JSUnaryOperator(name, type);
		}

		public void Accept(JSCodeModelToCode conv) {
			conv.Generate(this);
		}

	}
}