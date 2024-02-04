/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 2.6.2021 г.
 * Time: 18:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace izpitvane1
{
	class Program
	{
		static int[] permut;
		static int n, m, count = 0;
		static bool[] used;
		
		public  static void GetData()
		{
			Console.Write("n = ");
			n = int.Parse(Console.ReadLine());
			Console.Write("m = ");
			m = int.Parse(Console.ReadLine());
			permut = new int[n];
			used = new bool[n+1];
		}
		static void Check()
		{
			int sum = permut[0] + permut[1] + permut[2] + permut[4];
			if (sum > m && sum < 2*m) {
				count++;
			}
		}
		public static void GenPermut(int k)
		{
			if (k == n) {
				Check();
				return;
			}
			for (int i = 1; i <= n; i++) {
				if (!used[i]) {
					permut[k] = i;
					used[i] = true;
					GenPermut(k+1);
					used[i] = false;
				}
			}
		}
		public static void Main(string[] args)
		{
			GetData();
			GenPermut(0);
			Console.WriteLine("Total of {0} valid permutations", count);
			
			Console.ReadKey(true);
		}
	}
}