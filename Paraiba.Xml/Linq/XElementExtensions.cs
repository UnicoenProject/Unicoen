﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Paraiba.Xml.Linq {
	public static class XElementExtensions {
		/// <summary>
		///   指定したnameのXElementを保持しているか取得します。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static bool Contains(this XElement element, string name) {
			return element.Element(name) != null;
		}

		/// <summary>
		/// XElement.Name.LocalNameプロパティの戻り値を取得します。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		[Pure]
		public static string Name(this XElement element) {
			return element.Name.LocalName;
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().Last()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement PreviousElement(this XElement element) {
			return element.LastElementBeforeSelf();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf(name).Last()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement PreviousElement(this XElement element, string name) {
			return element.LastElementBeforeSelf(name);
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement PreviousElementOrDefault(this XElement element) {
			return element.LastElementBeforeSelfOrDefault();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf(name).LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement PreviousElementOrDefault(this XElement element, string name) {
			return element.LastElementBeforeSelfOrDefault(name);
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().Reverse()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<XElement> PreviousElements(this XElement element) {
			var node = element.PreviousNode;
			while (node != null) {
				element = node as XElement;
				if (element != null)
					yield return element;
				node = node.PreviousNode;
			}
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf(name).Reverse()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static IEnumerable<XElement> PreviousElements(this XElement element, string name) {
			var node = element.PreviousNode;
			while (node != null) {
				element = node as XElement;
				if (element != null && element.Name.LocalName == name)
					yield return element;
				node = node.PreviousNode;
			}
		}

		/// <summary>
		/// 自分を含めたXElement.ElementsBeforeSelf().Reverse()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<XElement> PreviousElementsAndSelf(this XElement element) {
			yield return element;
			foreach (var elem in element.PreviousElements()) {
				yield return elem;
			}
		}

		/// <summary>
		/// 自分を含めたXElement.ElementsBeforeSelf(name).Reverse()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static IEnumerable<XElement> PreviousElementsAndSelf(this XElement element, string name) {
			return element.PreviousElementsAndSelf()
				.Where(e => e.Name.LocalName == name);
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement NextElement(this XElement element) {
			return element.FirstElementAfterSelf();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf(name).First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement NextElement(this XElement element, string name) {
			return element.FirstElementAfterSelf(name);
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement NextElementOrDefault(this XElement element) {
			return element.FirstElementAfterSelfOrDefault();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf(name).FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement NextElementOrDefault(this XElement element, string name) {
			return element.FirstElementAfterSelfOrDefault(name);
		}

		/// <summary>
		/// XElement.ElementsAfterSelf()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<XElement> NextElements(this XElement element) {
			return element.ElementsAfterSelf();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf(name)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static IEnumerable<XElement> NextElements(this XElement element, string name) {
			return element.ElementsAfterSelf(name);
		}

		/// <summary>
		/// 自分を含めたXElement.ElementsAfterSelf()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static IEnumerable<XElement> NextElementsAndSelf(this XElement element) {
			yield return element;
			foreach (var elem in element.NextElements()) {
				yield return elem;
			}
		}

		/// <summary>
		/// 自分を含めたXElement.ElementsAfterSelf(name)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static IEnumerable<XElement> NextElementsAndSelf(this XElement element, string name) {
			return element.NextElementsAndSelf()
				.Where(e => e.Name.LocalName == name);
		}

		/// <summary>
		/// XElement.Elements().First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement FirstElement(this XElement element) {
			return element.Elements().First();
		}

		/// <summary>
		/// XElement.Elements(name).First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement FirstElement(this XElement element, string name) {
			return element.Elements(name).First();
		}

		/// <summary>
		/// XElement.Elements().FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement FirstElementOrDefault(this XElement element) {
			return element.Elements().FirstOrDefault();
		}

		/// <summary>
		/// XElement.Elements(name).FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement FirstElementOrDefault(this XElement element, string name) {
			return element.Elements(name).FirstOrDefault();
		}

		/// <summary>
		/// XElement.Elements().Last()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement LastElement(this XElement element) {
			return element.Elements().Last();
		}

		/// <summary>
		/// XElement.Elements(name).Last()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement LastElement(this XElement element, string name) {
			return element.Elements(name).Last();
		}

		/// <summary>
		/// XElement.Elements().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement LastElementOrDefault(this XElement element) {
			return element.Elements().LastOrDefault();
		}

		/// <summary>
		/// XElement.Elements(name).LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement LastElementOrDefault(this XElement element, string name) {
			return element.Elements(name).LastOrDefault();
		}

		/// <summary>
		/// XElement.Elements().ElementAt(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElement(this XElement element, int index) {
			return element.Elements().ElementAt(index);
		}

		/// <summary>
		/// XElement.Elements(name).ElementAt(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElement(this XElement element, string name, int index) {
			return element.Elements(name).ElementAt(index);
		}

		/// <summary>
		/// XElement.Elements().ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementOrDefault(this XElement element, int index) {
			return element.Elements().ElementAtOrDefault(index);
		}

		/// <summary>
		/// XElement.Elements(name).ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementOrDefault(this XElement element, string name, int index) {
			return element.Elements(name).ElementAtOrDefault(index);
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement FirstElementBeforeSelf(this XElement element) {
			return element.ElementsBeforeSelf().First();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf(name).First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement FirstElementBeforeSelf(this XElement element, string name) {
			return element.ElementsBeforeSelf(name).First();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement FirstElementBeforeSelfOrDefault(this XElement element) {
			return element.ElementsBeforeSelf().FirstOrDefault();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf(name).FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement FirstElementBeforeSelfOrDefault(this XElement element, string name) {
			return element.ElementsBeforeSelf().FirstOrDefault();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().Last()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement LastElementBeforeSelf(this XElement element) {
			return element.ElementsBeforeSelf().Last();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf(name).Last()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement LastElementBeforeSelf(this XElement element, string name) {
			return element.ElementsBeforeSelf(name).Last();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement LastElementBeforeSelfOrDefault(this XElement element) {
			return element.ElementsBeforeSelf().LastOrDefault();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf(name).LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement LastElementBeforeSelfOrDefault(this XElement element, string name) {
			return element.ElementsBeforeSelf(name).LastOrDefault();
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().ElementAt(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementBeforeSelf(this XElement element, int index) {
			return element.ElementsBeforeSelf().ElementAt(index);
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf(name).ElementAt(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementBeforeSelf(this XElement element, string name, int index) {
			return element.ElementsBeforeSelf(name).ElementAt(index);
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf().ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementBeforeSelfOrDefault(this XElement element, int index) {
			return element.ElementsBeforeSelf().ElementAtOrDefault(index);
		}

		/// <summary>
		/// XElement.ElementsBeforeSelf(name).ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementBeforeSelfOrDefault(this XElement element, string name, int index) {
			return element.ElementsBeforeSelf(name).ElementAtOrDefault(index);
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement FirstElementAfterSelf(this XElement element) {
			return element.ElementsAfterSelf().First();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf(name).First()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement FirstElementAfterSelf(this XElement element, string name) {
			return element.ElementsAfterSelf(name).First();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement FirstElementAfterSelfOrDefault(this XElement element) {
			return element.ElementsAfterSelf().FirstOrDefault();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf(name).FirstOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement FirstElementAfterSelfOrDefault(this XElement element, string name) {
			return element.ElementsAfterSelf(name).FirstOrDefault();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().Last()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement LastElementAfterSelf(this XElement element) {
			return element.ElementsAfterSelf().Last();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf(name).Last()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement LastElementAfterSelf(this XElement element, string name) {
			return element.ElementsAfterSelf(name).Last();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <returns></returns>
		public static XElement LastElementAfterSelfOrDefault(this XElement element) {
			return element.ElementsAfterSelf().LastOrDefault();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf(name).LastOrDefault()です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		public static XElement LastElementAfterSelfOrDefault(this XElement element, string name) {
			return element.ElementsAfterSelf(name).LastOrDefault();
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().ElementAt(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementAfterSelf(this XElement element, int index) {
			return element.ElementsAfterSelf().ElementAt(index);
		}

		/// <summary>
		/// XElement.ElementsAfterSelf(name).ElementAt(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementAfterSelf(this XElement element, string name, int index) {
			return element.ElementsAfterSelf(name).ElementAt(index);
		}

		/// <summary>
		/// XElement.ElementsAfterSelf().ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementAfterSelfOrDefault(this XElement element, int index) {
			return element.ElementsAfterSelf().ElementAtOrDefault(index);
		}

		/// <summary>
		/// XElement.ElementsAfterSelf(name).ElementAtOrDefault(index)です。
		/// </summary>
		/// <param name = "element"></param>
		/// <param name="name"></param>
		/// <param name="index"></param>
		/// <returns></returns>
		public static XElement NthElementAfterSelfOrDefault(this XElement element, string name, int index) {
			return element.ElementsAfterSelf(name).ElementAtOrDefault(index);
		}
	}
}
