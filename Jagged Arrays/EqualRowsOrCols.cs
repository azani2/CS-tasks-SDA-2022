/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 17.3.2021 г.
 * Time: 8:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace equalRowsOrCols
{
	class Program
	{
		public static void FillArray(int[,] arr)
		{
			Random rnd = new Random();
			for (int i = 0; i < arr.GetLength(0); i++) {
				for (int j = 0; j < arr.GetLength(1); j++) {
					arr[i, j] = rnd.Next(0, 2);
				}
			}
		}
		public static void PrintTableMode(int[,] arr)
		{
			for (int i = 0; i < arr.GetLength(0); i++) {
				for (int j = 0; j < arr.GetLength(1); j++) {
					Console.Write("{0, 3}", arr[i, j]);
				}
				Console.WriteLine();
			}
		}
		public static void FindEqualRows(int[,] arr) 
		{
			for (int i = 0; i < arr.GetLength(0) - 1; i++) {
				bool match = true;
				for (int j = 0; j < arr.GetLength(1); j++) {
					if (arr[i, j] != arr[i + 1, j]) {
						match = false;
						break;
					}
					n++;
				}
				if (match) {
					Console.WriteLine("Rows {0} and {1} are equal!", i + 1, i + 2);
					return;
				}
			}
			Console.WriteLine("There are no equal adjacent rows!");
		}
		public static void FindEqualColumns(int[,] arr) 
		{
			for (int i = 0; i < arr.GetLength(1); i++) {
				bool match = true;
				for (int j = 0; j < arr.GetLength(0); j++) {
					if (arr[i, j] != arr[i, j + 1]) {
						match = false;
						break;
					}
				}
				if (match) {
					Console.WriteLine("Columns {0} and {1} are equal!", i + 1, i + 2);
					return;
				}
			}
			Console.WriteLine("There are no equal adjacent columns!");
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Number of rows:");
			int rows = int.Parse(Console.ReadLine());
			Console.WriteLine("Number of columns:");
			int cols = int.Parse(Console.ReadLine());
			int[,] arr = new int[rows, cols];
			FillArray(arr);
			Console.WriteLine("Array numbers");
			PrintTableMode(arr);
			FindEqualRows(arr);
			FindEqualColumns(arr);
			
			Console.ReadKey(true);
		}
	}
}