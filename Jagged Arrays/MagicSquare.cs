/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 18.3.2021 г.
 * Time: 13:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace magicSquare
{
	class Program
	{
		public static void FillArray(int[,] arr)
		{
			int rows = arr.GetLength(0);
			Console.WriteLine("Попълнете таблицата {0} x {0}", rows);
			
			for (int i = 0; i < rows; i++) {
				Console.WriteLine("Ред №{0}", i + 1);
				for (int j = 0; j < rows; j++) {
					Console.Write("Елемент №{0}: ", j + 1);
				arr[i, j] = int.Parse(Console.ReadLine());
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
		public static void CheckIsMagic(int[,] arr)
		{
			int[] sums = new int[8];
			int rows = arr.GetLength(0);
			for (int i = 0; i < rows; i ++) {
				sums[0] += arr[i, i];
				sums[1] += arr[i, rows - 1- i];
			}
			for (int i = 0; i < rows; i++) {
				for (int j = 0; j < rows; j++) {
					sums[i + 2] += arr[i, j];
				}
			}
			for (int i = 0; i < rows; i++) {
				for (int j = 0; j < rows; j++) {
					sums[i + 5] += arr[j, i];
				}
			}
			for (int i = 0; i < sums.Length - 1; i ++) {
				if (sums[i] != sums[i+1]) {
					Console.WriteLine("Това не е магически квадрат :(");
					return;
				}
			}
			Console.WriteLine("Tова е магически квадрат със сбор {0}", sums[0]);
		}
		public static void Main(string[] args)
		{
			
			int[,] square = new int[3,3];
			FillArray(square);
			PrintTableMode(square);
				CheckIsMagic(square);
			
			Console.ReadKey(true);
		}
	}
}