/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 26.5.2021 г.
 * Time: 17:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO;

namespace movies
{
	class Hashing
	{
		public int counter;
		string[] hTable;
		
		public Hashing() {
			hTable = new string[1001];
		}
		
		int HashT(string s)
		{
			char[] c = s.ToCharArray();
			long sum = 0;
			for (int i = 0; i < c.Length; i++) {
				sum += (37*sum + c[i]) % hTable.Length;
			}
			sum = sum % hTable.Length;
			if (sum < 0) {
				sum += hTable.Length;
			}
			return (int) sum;
		}
		
		void ShowDistr()
		{
			Console.WriteLine("Обработени стойности");
			Console.WriteLine(new String('-', 60));
			Console.WriteLine("№\t\t Име");
			Console.WriteLine(new String('-', 60));
			for (int i = 0; i < hTable.Length; i++) {
				if (hTable[i] != null) {
					Console.WriteLine("{0}\t\t{1}", i, hTable[i]);
				}
			}
			Console.WriteLine("Брой обработени стойности: {0}", counter);
		}
		
		bool ContainsValue(string s)
		{
			if (Array.BinarySearch(hTable, s) != -1) {
				return true;
			}
			return false;
		}
		
		public void Run()
		{
			string[] someNames = File.ReadAllLines("d1.txt");
			for (int i = 0; i < someNames.Length; i++) {
				if (hTable[HashT(someNames[i])] == null) {
					counter++;
				}
				hTable[HashT(someNames[i])] = someNames[i];
			}
			ShowDistr();
		}
		
		public void SearchText()
		{
			Console.WriteLine("Въведете текст за търсене:");
			string name = Console.ReadLine();
			if (ContainsValue(name)) {
				Console.WriteLine("филмът {0} е намерен в хеш таблицата.", name);
			} else Console.WriteLine("филмът {0} НЕ е намерен в хеш таблицата.", name);
		}
		
	}
	class Program
	{
		public static void Main(string[] args)
		{
			Hashing h1 = new Hashing();
			h1.Run();
			Console.WriteLine("Изберете действие:");
			Console.WriteLine("(1) Търси (2) Излез");
			string choice = Console.ReadLine();
			do {
				h1.SearchText();
				Console.WriteLine("Изберете действие:");
				Console.WriteLine("(1) Търси (2) Излез");
				choice = Console.ReadLine();
			} while (choice == "1");
			Console.WriteLine("\n Успешно излязохте от програмата...");
			
			
			
			Console.ReadKey(true);
		}
	}
}