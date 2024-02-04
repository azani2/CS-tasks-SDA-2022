/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 22.3.2021 г.
 * Time: 9:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace snakeLike
{
	class Program
	{
		public static void FillArray(int[,] arr)
		{
			for (int i = 0; i < arr.GetLength(0); i++) {
				for (int j = 0; j < arr.GetLength(1); j++) {
					arr[i, j] = (i+1)*10 + j + 1;
				}
			}
		}
		public static void PrintTableMode(int[,] arr)
		{
			Console.WriteLine("Array numbers");
			for (int i = 0; i < arr.GetLength(0); i++) {
				for (int j = 0; j < arr.GetLength(1); j++) {
					Console.Write("{0, 4}", arr[i, j]);
				}
				Console.WriteLine();
			}
		}
		public static void SnakeLikeInARow(int[,] arr) 
		{
			List<int> numbers = new List<int>();
			int rows = arr.GetLength(0);
			int cols = arr.GetLength(1);
			
			for (int i = 0; i < rows; i++) {
				for (int j = 0; j < cols; j++) {
					if ( i % 2 != 0) {
						numbers.Add(arr[i, cols - j - 1]);
					} else {
						numbers.Add(arr[i, j]);
					}
				}
			}
			Console.WriteLine("Snake mode :)\n{0}", string.Join("  ", numbers));
		}
		public static void SpiralLikeInARow(int[,] arr) 
		{
			List<int> numbers = new List<int>();
			int rows = arr.GetLength(0);
			int cols = arr.GetLength(1);
			int count = rows*cols;
			int r = 0, c = 0; 
			
			while (r < rows && c < cols) {
				for (int i = c; i < cols; i++) {
					numbers.Add(arr[r, i]);
				}
				r++;
				
				for (int i = r; i < rows; i++) {
					numbers.Add(arr[i, cols-1]);
				}
				cols--;
				
				if (r < rows) {
					for (int i = cols - 1; i >= c; i--) {
						numbers.Add(arr[rows - 1, i]);
					}
					rows--;
				}
				
				if (c < cols) {
					for (int i = rows - 1; i >= r; i--) {
						numbers.Add(arr[i, c]);
					}
					c++;
				}
			}
			Console.WriteLine("Spiral mode :)");
			Console.WriteLine(string.Join("  ", numbers));
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Number of rows: ");
			int r = int.Parse(Console.ReadLine());
			Console.WriteLine("Number of columns: ");
			int c = int.Parse(Console.ReadLine());
			int[,] arr = new int[r, c];
			FillArray(arr);
			PrintTableMode(arr);
			SnakeLikeInARow(arr);
			SpiralLikeInARow(arr);
			
			Console.ReadKey(true);
		}
	}
}