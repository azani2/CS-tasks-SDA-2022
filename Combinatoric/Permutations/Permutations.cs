/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 31.5.2021 г.
 * Time: 16:16
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace upr
{
	class Program
	{
		static int n;
		static bool[] used;
		static int[] permut;
		static int c = 0;
		static int kk, mm;
		public static void PermRec(int k)
		{
			if (k == n) {
				PrintP();
				return;
			}
			for (int m = 1; m <= n; m++) {
				if (!used[m]) {
					
					used[m] = true;
					permut[k] = m;
					PermRec(k+1);
					used[m] = false;
				}
			}
		}
		static void PrintP()
		{
			bool ok = true;
			for (int i = 0; i <= n - kk - 1; i+=kk) {
				if (Math.Abs(permut[i] - permut[i+kk]) > mm) {
					ok = false;
				}
			}
			if (ok) {
				foreach (int e in permut) {
					Console.Write(e + " ");
				} 
				Console.WriteLine();
				c++;
			}
		}
		public static void Main(string[] args)
		{

			Console.Write("Въведете стойност за n: ");
			n = int.Parse(Console.ReadLine());
			Console.Write("Въведете стойност за m: ");
			mm = int.Parse(Console.ReadLine());
			Console.Write("Въведете стойност за k: ");
			kk = int.Parse(Console.ReadLine());
			Console.WriteLine("Резултат:");
			permut = new int[n];
			used = new bool[n+1];
			PermRec(0);
			Console.Write("Брой пермутации: " + c);
			
			
			Console.ReadKey(true);
		}
	}
}