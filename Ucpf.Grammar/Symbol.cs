﻿using System.Collections.Generic;

namespace Ucpf.Grammar
{
	public class Symbol : ISymbol
	{
		private readonly string _name;

		public string Name
		{
			get { return _name; }
		}

		public Symbol(string name)
		{
			_name = name;
		}

		public int GetCount(int maxRepeat)
		{
			return 1;
		}

		public IEnumerable<Symbol> Expand(int index, int maxRepeat)
		{
			yield return this;
		}

		public override string ToString()
		{
			return _name;
		}
	}
}

