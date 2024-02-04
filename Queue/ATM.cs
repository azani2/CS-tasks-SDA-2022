/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 12.4.2021 г.
 * Time: 16:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace banknotes
{
	class Program
	{
		static Queue<int> parts = new Queue<int>();
		static int[] nominals = {100, 50, 20, 10, 5, 2, 1};
		static void Fill(int num)
		{
			int c;
			for (int i = 0; i < nominals.Length; i++) {
				c = num / nominals[i];
				parts.Enqueue(c);
				num %= nominals[i];
			}
		}
		public static void Main(string[] args)
		{
			Console.Write("Въведете сума: ");
			int sum = int.Parse(Console.ReadLine());
			Fill(sum);
			
			Console.WriteLine("Изчислена сума в номинални стойности:");
			for (int i = 0; i < nominals.Length; i++) {
				if (parts.Peek() != 0) {
					Console.WriteLine("{0} {1} * {2}", parts.Dequeue(), i < 5 ? "банкноти" : "монети", nominals[i]);
				} else parts.Dequeue();
			}
			Console.ReadKey(true);
		}
	}
}