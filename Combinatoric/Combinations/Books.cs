/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 12.5.2021 г.
 * Time: 17:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace booksCombs
{
	class Program
	{
		static int[] c;
		static int k, n;
		static List<string> allBooks;
		
		static void GetData()
		{
			Console.Write("Enter the number of books: ");
			n = int.Parse(Console.ReadLine());
			Console.Write("Enter the number of books to collect: ");
			k = int.Parse(Console.ReadLine());
			c = new int[k];
			for (int i = 0; i < k; i++) { c[i] = i + 1; }
			
			allBooks = new List<string> { "Beloved", "Brave New World", "Buddenbrooks", "Crime and Punishment", "Dracula",
				"Frankenstein", "I Capture The Castle", "In Cold Blood", "Jane Eyre", "Moby-Dick",
				"Nineteen Eighty-Four", "One Flew Over the Cuckoo's Nest", "One Hundred Years of Solitude", "Persuasion", "Pride and Prejudice",
				"Tess of the d'Urbervilles", "The Call of the Wild", "The Chrysalids", "The Code of the Woosters", "The Death of the Heart",
				"The Go-Between", "The Grapes of Wrath", "The Great Gatsby", "The Lion, the Witch and the Wardrobe", "The Lord of the Rings",
				"The Master and Margarita", "The Secret History", "To Kill a Mockingbird", "To the Lighthouse", "Wide Sargasso Sea"
				};
			allBooks.RemoveRange(k, n-k);
			
		}
		static void GenComb()
		{
			n++;
			while (c[k-1] < n)
			{
				Print();
				int t = k-1;
				while (t!=0 && c[t] == n-k + t) t--;
				c[t]++;
				for(int i = t+1; i < k; i++) c[i] = c[i-1] + 1;
			}
		}
		static void Print()
		{
			/*foreach(int i in c) {
				Console.Write(i);
			}
			Console.WriteLine();*/
			foreach(int i in c) {
				Console.Write("{0}, ", allBooks[i]);
			}
			Console.WriteLine();
		}
		public static void Main(string[] args)
		{
			GetData();
			Console.WriteLine("Combinations of books:");
			Console.WriteLine(new String('-', 60));
			GenComb();
			
			
			Console.ReadKey(true);
		}
	}
}