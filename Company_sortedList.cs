/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 25.3.2021 г.
 * Time: 13:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace zaplataBG
{
	class Comp
	{
		SortedList<double, string> salarySector;
		public Comp()
		{
			salarySector = new SortedList<double, string>();
			salarySector.Add(44600, "Компютри");
			salarySector.Add(41650, "Принтери");
			salarySector.Add(38900, "Компютри");
			salarySector.Add(34500, "Компютри");
			salarySector.Add(47500, "Компютри");
			salarySector.Add(33000, "Принтери");
			salarySector.Add(36100, "Принтери");
			salarySector.Add(31200, "Компютри");
			salarySector.Add(37500, "Принтери");
		}
		public void PrintSortedTable()
		{
			Console.WriteLine("\nПълна справка за заплатите по сектори\n");
			Console.WriteLine("Годишна заплата\tСектор");
			Console.WriteLine(new String('-', 37));
			foreach(KeyValuePair<double, string> pair in salarySector) {
				Console.WriteLine("{0,15}{1,22}", pair.Key, pair.Value);
			}
		}
		public void FilterBetween(double minSal, double maxSal)
		{
			Console.WriteLine("\nСправка в интервал между {0} и {1}\n", minSal, maxSal);
			Console.WriteLine("Годишна заплата\tСектор");
			Console.WriteLine(new String('-', 37));
			foreach(KeyValuePair<double, string> pair in salarySector) {
				if (pair.Key <= maxSal && pair.Key >= minSal) {					
					Console.WriteLine("{0,15}{1,22}", pair.Key, pair.Value);
				}
			}
		}
		double CalcAvg() 
		{
			double sum = 0;
			foreach(KeyValuePair<double, string> pair in salarySector) {
				sum += pair.Key;
			}
			sum /= salarySector.Count;
			return sum;
		}
		public void FilterMoreWith(double val)
		{
			double avg = CalcAvg();
			Console.WriteLine("\nСправка за заплатите с  над {0} от {1} (средна заплата)\n", val, avg.ToString("f2"));
			Console.WriteLine(new String('-', 37));
			foreach(KeyValuePair<double, string> pair in salarySector) {
				if (pair.Key >= val + avg) {					
					Console.WriteLine("{0,15}{1,22}", pair.Key, pair.Value);
				}
			}
		}
		public void FilterPrinters()
		{
			Console.WriteLine("\nСправка за заплатите в сектор 'Принтери'\n");
			Console.WriteLine(new String('-', 37));
			foreach(KeyValuePair<double, string> pair in salarySector) {
				if (pair.Value == "Принтери") {					
					Console.WriteLine("{0,15}{1,22}", pair.Key, pair.Value);
				}
			}
		}
		public void FilterComps()
		{
			Console.WriteLine("\nСправка за заплатите в сектор 'Компютри'\n");
			Console.WriteLine(new String('-', 37));
			foreach(KeyValuePair<double, string> pair in salarySector) {
				if (pair.Value == "Компютри") {					
					Console.WriteLine("{0,15}{1,22}", pair.Key, pair.Value);
				}
			}
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			
			Comp c1 = new Comp();
			
			Console.WriteLine("Потребителско меню:\n1) Справка за всички заплати (сортирани в нарастващ ред)");
			Console.WriteLine("2) Справка в интервал (от ... до ...)");
			Console.WriteLine("3) Справка за заплатите, надвишаващи с определена сума \n средната годишна заплата на всички служители");
			Console.WriteLine("4) Справка за заплатите в сектор 'Принтери'");
			Console.WriteLine("5) Справка за заплатите в сектор 'Компютри'");
			
			Console.Write("\nВашият избор: ");
			int choice = int.Parse(Console.ReadLine());
			switch (choice) {
				case 1 :
					c1.PrintSortedTable();
					break;
				case 2:
					Console.Write("Въведете минимума на заплатата: ");
					double min = double.Parse(Console.ReadLine());
					Console.Write("Въведете максмума на заплатата: ");
					double max = double.Parse(Console.ReadLine());
					c1.FilterBetween(min, max);
					break;
				case 3:
					Console.Write("Въведете сума (лв.): ");
					double sum = double.Parse(Console.ReadLine());
					c1.FilterMoreWith(sum);
					break;
				case 4:
					c1.FilterPrinters();
					break;
				case 5:
					c1.FilterComps();
					break;
				default:
					Console.Write("...");
					break;
			}
			
			Console.ReadKey(true);
		}
	}
}