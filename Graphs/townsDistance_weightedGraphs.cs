/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 24.6.2021 г.
 * Time: 13:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace disst2
{
	public abstract class WGraph
	{
		public int Vertices { get; private set; }
		public int Edges { get; private set; }
		public Dictionary<int, Dictionary<int,int>> AdjWList { get; private set; }
		//за разлика от непретеглените графи, където за всеки връх да се записваше само множество(HashSet) от съседните върхове
		//сега за всеки връх се записва Dictionary от двойките връх-съсед на текущия и дължина на реброто до него
		//така пак има списък на съседи (наследници), но освен това се помнят и дължините 9теглата) на ребрата
		
		protected WGraph(int numOfV, int numOfE)
		{
			Vertices = numOfV;
			Edges = numOfE;
			AdjWList = new Dictionary<int, Dictionary<int,int>>(Vertices);
			for (int v = 1; v <= Vertices; v++) 
			{
				AdjWList[v] = new Dictionary<int, int>();
			}
		}
		protected abstract void FillTheList(int[,] edgesList);
	}
	
	public class UndirectedWGraph : WGraph
	{
		public UndirectedWGraph(int numOfV, int numOfE, int[,] edgesList) 
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
				AdjWList[st].Add(fn, edgesList[i,2]);
				AdjWList[fn].Add(st, edgesList[i,2]);
			}
		}
	}
	
	public static class WGraphData
	{
		public static int[,] GetWeightedEdgesListByFile(string fileName, out int numOfVertices, out int numOfEdges)
		{
			System.IO.StreamReader file = new System.IO.StreamReader(fileName);
			numOfVertices = int.Parse(file.ReadLine());
			numOfEdges = int.Parse(file.ReadLine());
			int [,] edges = new int[numOfEdges,3];
			for (int i = 0; i < edges.GetLength(0); i++) {
				string[] temp = file.ReadLine().Split(' ');
				edges[i, 0] = int.Parse(temp[0]);
				edges[i, 1] = int.Parse(temp[1]);
				edges[i, 2] = int.Parse(temp[2]);
			}
			return edges;
		}
	}
	
	class Program
	{
		static WGraph wg;
		
		static int GetNextClosestVertex(int[] distance, HashSet<int> visited)
		{
			int d = int.MaxValue, nextV = 0;
			for(int vertex = 1; vertex <= wg.Vertices; vertex++) 
			{
				if(!visited.Contains(vertex))
				{
					if(distance[vertex] < d) 
					{
						d = distance[vertex];
						nextV = vertex;
					}
				}
			}
			return nextV;
		}
		
		static void Dijkstra(int startV, int endV)
		{
			int[] distance = new int[wg.Vertices + 1];
			for (int i = 0; i < distance.Length; i++) distance[i] = int.MaxValue;
			HashSet<int> visited = new HashSet<int>();
			
			distance[startV] = 0;
			
			while (visited.Count < wg.Vertices) 
			{
				int currentVertex = GetNextClosestVertex(distance, visited);
				if(currentVertex == 0) break;
				foreach (int v in wg.AdjWList[currentVertex].Keys) 
				{
					if(!visited.Contains(v))
					{
						int altDist = distance[currentVertex] + wg.AdjWList[currentVertex][v];
						if (distance[v] > altDist) distance[v] = altDist;
					}
				}
				visited.Add(currentVertex);
			}
			PrintDistances(startV, endV, distance);
		}
		
		static void PrintDistances(int startV, int endV, int[] distance)
		{
			for (int v = 1; v <= wg.Vertices; v++) 
			{
				if(v!= endV) continue;
				Console.Write("Path: {0}->{1} ", startV,v);
				if(distance[v] == int.MaxValue) Console.WriteLine("does not exist!");
				else Console.WriteLine("  Distance: {0}",distance[v]);
			}
			
		}
		
		public static void Main(string[] args)
		{
			int nv,ne;
			int[,] edges = WGraphData.GetWeightedEdgesListByFile("roadsData1.txt", out nv, out ne);
			wg = new UndirectedWGraph(nv, ne, edges);
			Console.WriteLine("Minimal distances:");
			Dijkstra(1, 2);
			Dijkstra(1, 4);
			
			
			
			Console.ReadKey(true);
		}
	}
}