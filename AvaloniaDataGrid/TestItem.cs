using System;
using System.Collections.Generic;

namespace AvaloniaDataGrid
{
	public class TestItem
	{
		public int Index { get; set; } = 0;

		public int Num0 { get; set; } = 0;
		public int Num1 { get; set; } = 1;
		public int Num2 { get; set; } = 2;

		public override string ToString()
		{
			return Index.ToString();
		}
	}
}
