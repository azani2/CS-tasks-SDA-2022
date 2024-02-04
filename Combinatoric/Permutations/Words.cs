/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 28.4.2021 г.
 * Time: 18:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace dummm
{
	class Program
	{ 
		public static void Swap(char[] p, int i, int j) {
			char t = p[i];
			p[i] = p[j];
			p[j] = t;
		}
		public static void Reverse(char[] p, int i, int j) {
			while(i < j) {
				Swap(p, i++, j--);
			}
		}
		public static void Main(string[] args)
		{
			Console.Write("Enter a word: ");
			char[] word = Console.ReadLine().ToCharArray();
			Array.Sort(word);
			Console.WriteLine("Possible anagrams:");
			while(true)
			{
				Console.WriteLine(string.Join("", word));
				int i = word.Length - 1;
				while ((int)word[i-1] >= (int)word[i]) {
					i--;
					if(i == 0) return;
				}
				int j = word.Length - 1;
				while (j > i && (int)word[j] <= (int)word[i-1]) { j--; }
				Swap(word, i-1, j);
				Reverse(word, i, word.Length-1);
			}
			Console.ReadKey(true);
		}
	}
}