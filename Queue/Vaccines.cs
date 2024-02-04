/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 14.4.2021 г.
 * Time: 17:29
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace vaccines
{
	class Vaccination
	{
		private Queue<string> toBeVaccinated;
		public Vaccination()
		{
			toBeVaccinated = new Queue<string>(new String[] {"ББН/57", "ААК/66", "РВД/79", "ИРИ/69", "РТВ/70", "ЕКТ/76", "ВЕР/59", "ОАБ/39", "БОК/67", "ТМА/80", "ВЛК/88", "ГРН/47"});
		}
		public void PrintData()
		{
			Console.WriteLine("Записани/изчакващи ваксинация: {0}", toBeVaccinated.Count);
			if(toBeVaccinated.Count > 0) {
				Console.WriteLine(string.Join("; ", toBeVaccinated));
			} else Console.WriteLine("Няма");
		}
		public void QueueOfAgedOver(int limit)
		{
			Console.WriteLine("Записани/изчакващи: хора на възраст над {0} години", limit);
			int all = toBeVaccinated.Count, all2 = all;
			while (all > 0) {
				string current = toBeVaccinated.Dequeue();
				all--;
				if (int.Parse(current.Substring(current.IndexOf('/') + 1)) > limit) {
					Console.Write(current + "; ");
				} else {
					toBeVaccinated.Enqueue(current);
				}
			}
			if (all2 == toBeVaccinated.Count) {
				Console.WriteLine("Няма");
			} else Console.WriteLine("");
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			Vaccination v1 = new Vaccination();
			v1.PrintData();
			Console.Write("Въведете максимална възраст: ");
			int limit = int.Parse(Console.ReadLine());
			v1.QueueOfAgedOver(limit);
			v1.PrintData();
			Console.ReadKey(true);
		}
	}
}