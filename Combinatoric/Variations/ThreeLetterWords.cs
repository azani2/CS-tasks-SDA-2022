/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 10.5.2021 г.
 * Time: 16:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace dumi3l
{
	class Program
	{
		static int[] v;
		static char[] letters;
		static int k, n;
		static bool[] used;
		
		static void GetData()
		{
			Console.Write("Enter a word (short): ");
			letters = Console.ReadLine().ToCharArray();
			Array.Sort(letters);
			n = 4;
			k = 3;
			v = new int[k];
			used = new bool[n+1];
			for (int i = 0; i < k; i++) {
				v[i] = i+1;
			}
		}
			
		static void Print()
		{
			foreach(int n1 in v) {
				Console.Write(letters[n1-1]);
			}
			Console.Write(", ");
		}
		static void Variations()
		{
			while(true) {
				Print();
				int a = v[k-1] + 1;
				while (Array.IndexOf(v, a) >= 0) a++;
				if(a <= n) v[k-1] = a;
				else {
					int i = k-1;
					while(v[i-1] > v[i]) { i--; if( i == 0) return;}
					do { v[i-1]++; } while (Array.IndexOf(v, v[i-1], 0, i-1) >= 0);
					for (int p = 1; p < n; p++) {
						if (Array.IndexOf(v, p, 0, i) < 0) {
							v[i] = p; i++;
							if (i == k) {
								break;
							}
						}
					}
				}
			}
		}
		public static void Main(string[] args)
		{
			GetData();
			Variations();
			
			Console.ReadKey(true);
		}
	}
}