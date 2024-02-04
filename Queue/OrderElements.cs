/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 14.4.2021 г.
 * Time: 17:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace podrejdane
{
	class Program
	{
		public static void Main(string[] args)
		{
			Random rnd = new Random();
			Console.Write("Въведете броя на числата: ");
			int count = int.Parse(Console.ReadLine());
			
			Queue<int> zeroes = new Queue<int>(), even = new Queue<int>(),
			odd = new Queue<int>(), all = new Queue<int>(count);
			
			for (int i = 0; i < count; i++) {
				int current = rnd.Next(1, 101);
				Console.Write(current + " ");
				if(current % 10 == 0) { zeroes.Enqueue(current); }
				else if (current % 2 == 0) {  even.Enqueue(current);}
				else odd.Enqueue(current);
			}
			int cZ = zeroes.Count, cE = even.Count, cO = odd.Count;
			while(cZ > 0) {
				cZ--;
				all.Enqueue(zeroes.Dequeue());
			}
			while(cE > 0) {
				cE--;
				all.Enqueue(even.Dequeue());
			}
			while(cO > 0) {
				cO--;
				all.Enqueue(odd.Dequeue());
			}
			Console.WriteLine("\nОтпечатване на новата редица:\n" + string.Join(" ", all));
			
			Console.ReadKey(true);
		}
	}
}