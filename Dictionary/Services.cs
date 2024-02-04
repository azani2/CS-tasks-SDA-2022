/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 2.6.2021 г.
 * Time: 18:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace serviz
{
	class Service
	{
		Dictionary <string, string> serv;
		public Service()
		{
			serv = new Dictionary<string, string>(100) {
				{ "В 2825", "ремонт на съединител" },
				{ "В 2835", "смяна на масла и филтри" },
				{ "В 4644", "реглаж" },
				{ "В 4744", "ремонт на съединител" },
				{ "С 5500", "цялостно боядисване" },
				{ "В 6985", "реглаж" },
				{ "В 6660", "реглаж" }
			};
			
		}
		public void ShowServices()
		{
			if (serv.Count == 0) {
				Console.WriteLine("Все още не са извършвани сервизни услуги.");
				return;
			}
			Console.WriteLine("Списък: рег. номер - услуга:");
			foreach (var kvp in serv) {
				Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
			}
			Console.WriteLine("Брой ремонтирани автомобили: " + serv.Count);
		}
		public void SearchOrAdd()
		{
			Console.Write(">>> ");
			string reg = Console.ReadLine();
			do {
				if (serv.ContainsKey(reg)) {
					Console.WriteLine("Рег. номер: {0} – вид услуга: {1}", reg, serv[reg]);
				} else {
					Console.Write("Добавете автомобил: \n>>> ");
					reg = Console.ReadLine();
					Console.Write(">>> ");
					string service = Console.ReadLine();
					serv.Add(reg, service);
					Console.WriteLine("Рег. номер: {0} – вид услуга: {1}\nБрой ремонтирани автомобили: {2}", reg, service, serv.Count);
				}
				Console.Write(">>> ");
				reg = Console.ReadLine();
			} while (reg != "");
		}
		
	}
	class Program
	{
		public static void Main(string[] args)
		{
			Service s1 = new Service();
			s1.ShowServices();
			s1.SearchOrAdd();
			
			
			Console.ReadKey(true);
		}
	}
}