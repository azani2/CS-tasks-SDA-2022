/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 3.6.2021 г.
 * Time: 13:37
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace grp
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Directed or undirected graph (d/u): ");
			string du = Console.ReadLine();
			Console.Write("Number of verticles: ");
			int v = int.Parse(Console.ReadLine());
			Console.Write("Number of edges: ");
			int e = int.Parse(Console.ReadLine());
			int[,] m = new int[v,v];
			string[] adj;
			
			
			for (int i = 0; i < e; i++) {
				Console.Write("Edge: ");
				adj = Console.ReadLine().Split(' ');
				if (du == "d") {
					m[int.Parse(adj[0])-1, int.Parse(adj[1])-1] = 1;
				}
				else {
					m[int.Parse(adj[0])-1, int.Parse(adj[1])-1] = 1;
					m[int.Parse(adj[1])-1, int.Parse(adj[0])-1] = 1;
				}
			}
			
			Console.WriteLine("Adjacency matrix");
			
			for (int i = 0; i < v; i++) {
				for (int j = 0; j < v; j++) {
					Console.Write("  {0}", m[i, j]);
				}
				Console.WriteLine();
			}
			Console.ReadKey(true);
		}
	}
}