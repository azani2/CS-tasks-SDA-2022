/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 1.4.2021 г.
 * Time: 13:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace hiddenNumber
{
	class HiddenNumber
	{
		Stack<char> operations;
		Stack<int> arguments;
		int res;
		public HiddenNumber()
		{
			operations = new Stack<char>();
			arguments = new Stack<int>();
		}
		public void ReadStack()
		{
			Console.WriteLine("Намисли си едно число!");
			char op = '0';
			int arg = 0;
			while (op != '=') {
				Console.Write("Въведете +, -, * или =   ");
				op = Convert.ToChar(Console.ReadLine());
				Console.Write("Въведете цяло число:     ");
				arg = int.Parse(Console.ReadLine());
				operations.Push(op);
				arguments.Push(arg);
			}
		}
		public void CalcInitialNumber()
		{
			char op = '0';
			int arg = 0;
			while (arguments.Count > 0) {
				arg = arguments.Pop();
				op = operations.Pop();
				switch (op) {
					case '=':
						res = arg; break;
					case '+':
						res -= arg; break;
					case '-':
						res += arg; break;
					case '*':
						res /= arg; break;
					default:
						Console.WriteLine("Error"); return;
				}
			}
			Console.WriteLine("\nЛипсващото число е: {0}", res);
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			HiddenNumber hN = new HiddenNumber();
			hN.ReadStack();
			hN.CalcInitialNumber();
			
			Console.ReadKey(true);
		}
	}
}