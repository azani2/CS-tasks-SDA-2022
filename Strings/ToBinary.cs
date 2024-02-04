/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 25.2.2021 г.
 * Time: 12:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace bintoletters
{
	class Program
	{
		public static void BinToLetters(string bin)
		{
			string letters = "abcdefghijklmnopqrstuvwxyz";
			string normal = "";
			int zeroes = 0;
			for(int i=0; i < bin.Length; i++) {
				if(bin[i] == '0') {
					zeroes++;
				} else {
					normal += letters[zeroes];
					zeroes = 0;
				}
			}
			Console.WriteLine(normal);
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Въведете двоичен запис:");
			string bin = Console.ReadLine();
			Console.WriteLine("Представяне с бкви:");
			BinToLetters(bin);
			
			Console.ReadKey(true);
		}
	}
}