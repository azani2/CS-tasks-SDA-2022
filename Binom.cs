/*
 * Created by SharpDevelop.
 * User: User
 * Date: 10.2.2021 г.
 * Time: 18:15 ч.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace sportTot
{
	class Program
	{
		static long Binom(int n, int k)
		{
			if(n <= 0 || k <= 0 || n <= k) {return 1;}
			else {
				return Binom(n-1, k) + Binom(n-1, k-1);
			}
		}
		public static void Main(string[] args)
		{
			Console.Write("n = ");
			int n = int.Parse(Console.ReadLine());
			Console.Write("k = ");
			int k = int.Parse(Console.ReadLine());
			Console.WriteLine("C({0}, {1}) = {2}", n, k, Binom(n, k));
			
			Console.ReadKey(true);
		}
	}
}