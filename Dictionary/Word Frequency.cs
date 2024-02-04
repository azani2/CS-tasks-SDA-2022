/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 17.5.2021 г.
 * Time: 16:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace textdict
{
	class Program
	{
		public static void Main(string[] args)
		{
			string enteredText = "", e = "";
			do {
				enteredText += e;
				Console.Write(">>>");
				e = Console.ReadLine();
			} while(e!="");
			
			SortedDictionary<string, int> sortedWords = new SortedDictionary<string, int>();
			char[] separators = new char[] {' ', '.', ',', '-', '?', '!', '"'};
			string[] words = enteredText.Split(separators);
			foreach(string word in words) {
				if(!sortedWords.ContainsKey(word)) {
					sortedWords.Add(word, 1);
				} else {
					sortedWords[word]++;
				}
			}
			
			Console.WriteLine("Използвани думи");
			
			foreach(KeyValuePair<string, int> p in sortedWords) {
				Console.WriteLine("Думата '{0}' се среща  {1} път/и", p.Key, p.Value);
			}
			
			Console.ReadKey(true);
		}
	}
}