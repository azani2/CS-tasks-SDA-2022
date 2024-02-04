/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 14.6.2021 г.
 * Time: 16:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace grzd1var2
{
	public abstract class Graph
	{
		public int Vertices { get; private set; }
		public int Edges { get; private set; }
		public Dictionary<int, HashSet<int>> AdjList { get; private set; }

		protected Graph(int numOfV, int numOfE)
		{
			Vertices = numOfV;
			Edges = numOfE;
			AdjList = new Dictionary<int, HashSet<int>>(Vertices);
			for (int v = 1; v <= Vertices; v++) 
			{
				AdjList[v] = new HashSet<int>();
			}
		}
		protected abstract void FillTheList(int[,] edgesList);
	}
	
	public static class GraphData
	{
		public static int[,] GetEdgesListByConsole(out int numOfVertices, out int numOfEdges)
		{
			Console.Write("Vertices: ");
			numOfVertices = int.Parse(Console.ReadLine());
			Console.Write("Edges: ");
			numOfEdges = int.Parse(Console.ReadLine());
			int [,] edges = new int[numOfEdges,2];
			for (int i = 0; i < edges.GetLength(0); i++) {
				Console.Write("Edge: ");
				string[] temp = Console.ReadLine().Split(' ');
				edges[i, 0] = int.Parse(temp[0]);
				edges[i, 1] = int.Parse(temp[1]);
			}
			return edges;
		}
		public static int[,] GetEdgesListByFile(string fileName, out int numOfVertices, out int numOfEdges)
		{
			System.IO.StreamReader file = new System.IO.StreamReader(fileName);
			numOfVertices = int.Parse(file.ReadLine());
			numOfEdges = int.Parse(file.ReadLine());
			int [,] edges = new int[numOfEdges,2];
			for (int i = 0; i < edges.GetLength(0); i++) {
				string[] temp = file.ReadLine().Split(' ');
				edges[i, 0] = int.Parse(temp[0]);
				edges[i, 1] = int.Parse(temp[1]);
			}
			return edges;
		}
	}
	
	public class UndirectedGraph : Graph
	{

		public UndirectedGraph(int numOfV, int numOfE, int[,] edgesList) 
			: base(numOfV, numOfE)
		{
			
			FillTheList(edgesList);
		}
		
		protected override void FillTheList(int[,] edgesList)
		{
			for (int i = 0; i < Edges; i++) 
			{
				int st = edgesList[i,0];
				int fn = edgesList[i,1];
				AdjList[st].Add(fn);
				AdjList[fn].Add(st);
			}
		}
	}
	
	class Program
	{
		static UndirectedGraph undGrph;
		static HashSet<int> visited = new HashSet<int>();
		static HashSet<int> visitedTotal = new HashSet<int>();//for both
		//static List<HashSet<int>> listOfComps = new List<HashSet<int>>();//za DFS
		
		public static void BFS_FindComps(int startV)
		{
			Queue<int> neighbours = new Queue<int>(undGrph.Vertices);
			HashSet<int> visited = new HashSet<int>();
			
			neighbours.Enqueue(startV);
			visited.Add(startV);
			
			while (neighbours.Count > 0) 
			{
				int v = neighbours.Dequeue();
				foreach (int nv in undGrph.AdjList[v]) 
				{
					if(!visited.Contains(nv))
					{
						visited.Add(nv);
						visitedTotal.Add(nv);
						neighbours.Enqueue(nv);
					}
				}
			}
			Console.Write("Component: { ");
			foreach (int e in visited) {
				if (e != 0) {
					Console.Write("{0} ", e);
				}
			}
			Console.WriteLine("}");
			
		}
		
		public static void DFS_FindComps(int startV)
		{
			visited.Add(startV); 
			visitedTotal.Add(startV);
			foreach (int nextV in undGrph.AdjList[startV]) 
			{
				if(!visited.Contains(nextV)) 
				{
					DFS_FindComps(nextV);
				}
			}
			if (visited.Count!=0) {
				Console.Write("Component: { ");
				foreach (int e in visited) {
					if (e != 0) {
						Console.Write("{0} ", e);
					}
				}
				Console.WriteLine("}"); visited.Clear();
			}
			
			//listOfComps.Add(visited);
		}
		
		public static void Main(string[] args)
		{
			int nV, nE;
			int[,] edges = GraphData.GetEdgesListByConsole(out nV, out nE);
			undGrph = new UndirectedGraph(nV, nE, edges);
			int counter = 0;
			for (int i = 1; i <= nV; i++) {
				if(!visitedTotal.Contains(i)) {
					DFS_FindComps(i); counter ++;
				}
			}
			Console.WriteLine("total of {0} connected component/s", counter/*listOfComps.Count*/);
			//for (int i = 0; i < listOfComps.Count; i++) {
			//	Console.WriteLine("Component {0}:  {1} ", i+1, String.Join(", ", listOfComps[i]));
			//}
			
			Console.ReadKey(true);
		}
	}
}