/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 7.6.2021 г.
 * Time: 17:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace busses
{
	public class Graph
	{
		int vertices, edges;
		Dictionary<int, HashSet<int>> adjList;
		bool directed;
		public Graph(int v, int e, bool isDirected, int[,] edgesList)
		{
			vertices = v;
			edges = e;
			directed = isDirected;
			adjList = new Dictionary<int, HashSet<int>>(v);
			for (int i = 0; i < edges; i++) 
			{
				int st = edgesList[i,0];
				int fn = edgesList[i,1];
				if (!adjList.ContainsKey(st)) 
				{
					adjList[st] = new HashSet<int>();
				}
				adjList[st].Add(fn);
				if(!directed)
				{
					if (!adjList.ContainsKey(fn)) 
					{
						adjList[fn] = new HashSet<int>();
					}
					adjList[fn].Add(st);
				}
			}
		}
		public Dictionary<int, HashSet<int>> AdjList
		{
			get { return adjList;}
		}
		public int Vertices
		{
			get{ return vertices;}
		}
		public int Edges
		{
			get{ return edges;}
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Брой градове: ");
			int v = int.Parse(Console.ReadLine());
			Console.Write("Брой автобусни линии: ");
			int e = int.Parse(Console.ReadLine());
			int[,] eL = new int[e, 2];
			
			for (int i = 0; i < e; i++) {
				Console.Write("Линия: ");
				string[] input = Console.ReadLine().Split(' ');
				eL[i, 0] = int.Parse(input[0]);
				eL[i, 1] = int.Parse(input[1]);
			}
			
			Graph g1 = new Graph(v, e, false, eL);
			Console.WriteLine("\nБрой автобусни линии по градове:");
			for (int i = 0; i < v; i++) {
				Console.WriteLine("Град {0} - {1} линии", i+1, g1.AdjList[i].Count);
			}
			Console.WriteLine();
			
			int even = 0;
			for (int i = 0; i < v; i++) {
				if (g1.AdjList[i].Count%2=0) {
					even++;
				}
			}
			string yN = "";
			if (even == 0 || even == 2) {
				yN = "Нe";
			}
			Console.WriteLine("{0}възможна е обиколка на всички градове без повторения!\n", yN);
			Console.ReadKey(true);
		}
	}
}