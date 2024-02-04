/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 10.3.2021 г.
 * Time: 10:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text.RegularExpressions;

namespace lib
{
	class LibraryCatalog
	{
		string signature;
		public LibraryCatalog(string sig)
		{
			signature = sig;
		}
		bool IsSignature()
		{
			Regex pattern = new Regex(@"^[ПЧИКДБРС][1-9]\d{3}[А-Я]\d{2}$");
			return pattern.IsMatch(signature);
		}
		public void BookDescription()
		{
			string sector = signature.Substring(0, 1);
			string year = signature.Substring(1, 4);
			string author = signature.Substring(signature.Length - 3);
			if(IsSignature()) {
				Console.WriteLine("Книгата е в наличност");
				Console.WriteLine(new String('-', 30));
				Console.WriteLine("Сектор:\t\t\t{0}\nГодина на издаване:\t{1}\nАвторски знак:\t\t{2}", sector, year, author);
			} else Console.WriteLine("Невалидна сигнатура!");
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			
			Console.Write("Въведете сигнатура: ");
			string sig = Console.ReadLine();
			LibraryCatalog n = new LibraryCatalog(sig);
			n.BookDescription();
			
			Console.ReadKey(true);
		}
	}
}