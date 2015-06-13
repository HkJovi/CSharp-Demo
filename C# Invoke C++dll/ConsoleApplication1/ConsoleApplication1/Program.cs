using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ConsoleApplication1
{
	class Program
	{
		[DllImport("HX1.dll")]
		public static extern int fun1(int x, int y);
		[DllImport("HX1.dll")]
		public static extern IntPtr fun2();

		static void Main(string[] args)
		{
			int a = fun1(2, 5);
			string s = Marshal.PtrToStringAnsi(fun2());
			Console.WriteLine(a.ToString());
			Console.WriteLine(s);
			Console.ReadKey();
		}
	}
}
