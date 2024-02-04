/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 13.5.2021 г.
 * Time: 12:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace stalbove
{
	class Program
	{
		static int[] v;
		static int k, n;
		static string[] colors = new string[] {"white", "yellow", "green", "blue", "salmon", "gray", "purple", "orange", "beige", "siena"};
		static string[] adjacent;
		
		static void GetData()
		{
			n = colors.Length;
			Console.Write("Lighting posts to paint: ");
			k = int.Parse(Console.ReadLine());
			Console.WriteLine("Colors to be ised for adjacent posts:");
			adjacent = Console.ReadLine().ToLower().Split(' ');
			v = new int[k];
			for (int i = 0; i < k; i++) { v[i] = i + 1; }
		}
		
		static void GenVar()
		{
			while(true)
			{
				Print();
				int a = v[k-1] + 1;
				while (Array.IndexOf(v, a) >= 0) a++;
				if (a <= n) v[k-1] = a;
				else {
					int i = k-1;
					while (v[i-1] > v[i]) {i--; if(i==0) {return;}}
					do { v[i-1]++; } while(Array.IndexOf(v, v[i-1], 0, i-1) >= 0);
					for (int p = 1; p <= n; p++) {
						if (Array.IndexOf(v, p, 0, i) < 0) {
							v[i] = p; i++;
							if (i == k) break;
						}
					}
				}
			}
			
		}
		
		static void Print() 
		{
			int adj1 = Array.IndexOf(colors, adjacent[0]) + 1;
			int adj2 = Array.IndexOf(colors, adjacent[1]) + 1;
			int ind1 = Array.IndexOf(v, adj1);
			int ind2 = Array.IndexOf(v, adj2);
			if(Math.Abs(ind1 - ind2)!= 1 || ind1 == -1 || ind2 == -1) {
				return;
			}
			foreach( int i in v) {
				Console.Write(colors[i-1] + " ");
			}
			Console.WriteLine();
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Colors list:");
			Array.Sort(colors);
			Console.WriteLine(string.Join("; ", colors));
			GetData();
			Console.WriteLine(new String('-', 50));
			GenVar();
			
			Console.ReadKey(true);
		}
	}
}