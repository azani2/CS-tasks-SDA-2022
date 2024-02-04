/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 1.4.2021 г.
 * Time: 12:54
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace sameBrackets
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Console.WriteLine("Enter an  expression: ");
			string expr = Console.ReadLine();
			Stack<char> brackets = new Stack<char>();
			bool ok = true;
			List<char> leftBr = new List<char> {'(', '[', '{'};
			List<char> rightBr = new List<char> {')', ']', '}'};
			
			for (int i = 0; i < expr.Length; i++) {
				char c = expr[i];
				
				if (leftBr.Contains(c)) {
					brackets.Push(c);
				} else if (rightBr.Contains(c)) {
					if (brackets.Count == 0) {
						ok = false; break;
					}
					char alt = leftBr[rightBr.IndexOf(c)];
					if (brackets.Pop() != alt) {
						ok = false; break;
					}
				}
			}
			if (brackets.Count != 0) ok = false;
			if (ok) {
				Console.WriteLine("Yes");
			} else Console.WriteLine("No");
			
			Console.ReadKey(true);
		}
	}
}