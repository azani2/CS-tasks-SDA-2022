/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 15.2.2021 г.
 * Time: 16:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace easySorting
{
	class Program
	{
		public static void BubbleSortDesc(int[] numbers)
		{
			for (int i = numbers.Length; i > 0; i--) {
				for (int j = 0; j < i-1; j++) {
					if (numbers[j] < numbers[j+1]) {
						int temp = numbers[j];
						numbers[j] = numbers[j+1];
						numbers[j+1] = temp;
					}
				}
			}
			Console.WriteLine("След сортиране с метода на мехурчето:\n{0}", string.Join(", ", numbers));
		}
		public static void SelectionSortLastDigit(int[] numbers)
		{
			for(int i = 0; i < numbers.Length; i++) {
				for (int j = i+1; j < numbers.Length; j++) {
					if (numbers[i]%10 > numbers[j]%10) {
						int temp = numbers[i];
						numbers[i] = numbers[j];
						numbers[j] = temp;
					} else if(numbers[i]%10 == numbers[j]%10) {
						if (numbers[i] > numbers[j]) {
							int temp = numbers[i];
							numbers[i] = numbers[j];
							numbers[j] = temp;
						}
					}
				}
			}
			Console.WriteLine("След сортиране с метода на пряката селекция:\n" + string.Join(", ", numbers));
		}
		public static void Main(string[] args)
		{
			Random rnd = new Random();
			int[] arr1 = new int[15];
			for (int i = 0; i < arr1.Length; i++) {
				arr1[i] = rnd.Next(1, 101);
			}
			Console.WriteLine("Преди сортиране: \n" + string.Join(", ", arr1));
			BubbleSortDesc(arr1);
			SelectionSortLastDigit(arr1);
			
			Console.ReadKey(true);
		}
	}
}