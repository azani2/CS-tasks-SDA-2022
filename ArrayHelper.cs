/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 15.2.2021 г.
 * Time: 16:32
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace arrHelper
{
	class ArrHelper
	{
		public static void ReadArr(int[] a)
		{
			Console.WriteLine("Въведете {0} цели числа (Enter след всяко число):", a.Length);
			for (int i = 0; i < a.Length; i++) {
				a[i]=int.Parse(Console.ReadLine());
			}
		}
		public static void ReadArrSplit(int[] a)
		{
			string[] strArr = Console.ReadLine().Split(' ');
			for (int i = 0; i < a.Length; i++) {
				a[i] = int.Parse(strArr[i]);
			}
		}
		public static int MinArr(int[] a)
		{
			int min = a[0];
			for (int i = 1; i < a.Length; i++) {
				if (min > a[i]) {
					min = a[i];
				}
			}
			return min;
		}
		public static int Search(int x, int[] a)
		{
			for (int i = 0; i < a.Length; i++) {
				if (a[i] == x) {
					return i+1;
				}
			}
			return -1;
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			int[] arr = new int[10];
			ArrHelper.ReadArr(arr);
			Console.WriteLine("Минимален елемент: " + ArrHelper.MinArr(arr));
			Console.Write("k = ");
			int k = int.Parse(Console.ReadLine());
			Console.WriteLine("Поредният номер на първото срещане на числото {0} е {1}", k, ArrHelper.Search(k, arr));
			arr = new int[11];
			Console.WriteLine("Въведете 11 цели числа (с един интервал разстояние):");
			ArrHelper.ReadArrSplit(arr);
			Console.WriteLine("Минимален елемент: " + ArrHelper.MinArr(arr));
			
			Console.ReadKey(true);
		}
	}
}