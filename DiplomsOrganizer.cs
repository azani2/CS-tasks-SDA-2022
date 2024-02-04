/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 22.2.2021 г.
 * Time: 16:50
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace grrrr
{
	class Program
	{
		public static int NumOfDiplomas(int width, int height, int n)
		{
			int left = Math.Min(width, height);
			int right = Math.Max(width, height)*n;
			while(left<right) {
				int middle = (left+right)/2;
				if(n <= (middle/width)*(middle/height)) right = middle;
				else left = middle + 1;
			}
			return left;
		}
		public static void Main(string[] args)
		{
			Console.Write("Dioloma width: ");
			int width = int.Parse(Console.ReadLine());
			Console.Write("Dioloma height: ");
			int height = int.Parse(Console.ReadLine());
			Console.Write("Number of diplomas:");
			int n = int.Parse(Console.ReadLine());
			Console.WriteLine("Board size = {0}x{0}", NumOfDiplomas(width, height, n));
			
			Console.ReadKey(true);
		}
	}
}