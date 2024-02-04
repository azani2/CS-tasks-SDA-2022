/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 15.3.2021 г.
 * Time: 10:06
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ColRowSearch
{
	class Program
	{
		public static void FillArray(int[,] arr, int min, int max)
		{
			Random rnd = new Random();
			for (int i = 0; i < arr.GetLength(0); i++) {
				for (int j = 0; j < arr.GetLength(1); j++) {
					arr[i, j] = rnd.Next(min, max);
				}
			}
		}
		public static void PrintTableMode(int[,] arr)
		{
			for (int i = 0; i < arr.GetLength(0); i++) {
				for (int j = 0; j < arr.GetLength(1); j++) {
					Console.Write("{0, 6}", arr[i, j]);
				}
				Console.WriteLine();
			}
		}
		public static void ShowRowNumber(int[,] arr)
		{
			int even = 0, max = 0, row = 0;
			for (int i = 0; i < arr.GetLength(0); i++) {
				for (int j = 0; j < arr.GetLength(1); j++) {
					if (arr[i, j] % 2 == 0) {
						even++;
					}
				}
				if (i == 0) { max = even; row = 1 + i; }
				else {
					if (even > max) { max = even; row = 1 + i; }
				}
				even = 0;
			}
			Console.WriteLine("Row No.{0} contains {1} even numbers", row, max);
		}
		public static void ShowColNumber(int[,] arr)
		{
			int odd = 0, min = 0, col = 0;
			for (int i = 0; i < arr.GetLength(1); i++) {
				for (int j = 0; j < arr.GetLength(0); j++) {
					if (arr[j, i] % 2 == 1) {
						odd++;
					}
				}
				if (i == 0) { min = odd; col = 1 + i; }
				else {
					if (odd < min) { min = odd; col = 1 + i; }
				}
				odd = 0;
			}
			Console.WriteLine("Col No.{0} contains {1} odd numbers", col, min);
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Number of rows:");
			int rows = int.Parse(Console.ReadLine());
			Console.WriteLine("Number of columns:");
			int cols = int.Parse(Console.ReadLine());
			int[,] arr = new int[rows, cols];
			FillArray(arr, 0, 100);
			Console.WriteLine("Array numbers");
			PrintTableMode(arr);
			ShowRowNumber(arr);
			ShowColNumber(arr);
			
			Console.ReadKey(true);
		}
	}
}