/*
 * Created by SharpDevelop.
 * User: User
 * Date: 10.2.2021 г.
 * Time: 18:43 ч.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace sqrRoots
{
	class Program
	{
		static double Sum1(int n)
		{
			if(n==1) {return 1;}
			else {
				return Math.Sqrt(n+Sum1(n-1));
			}
		}
		static double Sum2(int n)
		{
			double result = 0;
			for (int i = 1; i <= n; i++) {
				result = Math.Sqrt(i + result);
			}
			return result;
		}
		public static void Main(string[] args)
		{
			Console.Write("n = ");
			int n = int.Parse(Console.ReadLine());
			Console.WriteLine("Recursion: {0}", Sum1(n));
			Console.WriteLine("Iteration: {0}", Sum2(n));
			
			Console.ReadKey(true);
		}
	}
}