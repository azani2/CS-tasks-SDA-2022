/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 29.3.2021 г.
 * Time: 9:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace banka
{
	class ByIntHighestToLowest : IComparer<int>
	{
		public int Compare(int a, int b)
		{
			return a-b;
		}
	}
	class SmallBankOffice
	{
		SortedList<int, string> customerByPriority;
		static int nextCustNum;
		public SmallBankOffice()
		{
			customerByPriority = new SortedList<int, string>(new ByIntHighestToLowest());
			nextCustNum = 1;
		}
		void PrintCustomers()
		{
			if (customerByPriority.Count == 0) {
				Console.WriteLine("В момента няма чaкащи клиенти!");
				return;
			}
			Console.WriteLine("Изчакващи клиенти: {0} с кодове: {1}", customerByPriority.Count, string.Join("/", customerByPriority.Values));
		}
		void AddCustomer()
		{
			Random rnd = new Random();
			int d = DateTime.Now.Hour*3600 + DateTime.Now.Minute*60 + DateTime.Now.Second;
			int n = rnd.Next(1, 5);
			int priority = n*100000 - d;
			const string iStoleThat = "ДКСЗ";
			char c = iStoleThat[n-1];
			string clientCode = nextCustNum.ToString() + " " + c;
			customerByPriority.Add(priority, clientCode);
			nextCustNum++;
			Console.Write("Добавен е нов клиент с код {0}\t", clientCode);
			PrintCustomers();
		}
		void NextCustomer()
		{
			if (customerByPriority.Count == 0) {
				Console.WriteLine("В момента няма чaкащи клиенти!");
				return;
			}
			Console.Write("Обслужва се клиент с код: {0}\t", customerByPriority[customerByPriority.Keys[0]]);
			customerByPriority.RemoveAt(0);
			PrintCustomers();
		}
		public void WorkDay()
		{
			Console.WriteLine("Начало на работния ден!");
			Random rnd = new Random();
			int counter = 0;
			while (true) {
				int r = rnd.Next(1, 11);
				if (r < 5) {
					NextCustomer();
				} else {
					AddCustomer();
					counter++;
				}
				if(Console.ReadKey(true).Key == ConsoleKey.Spacebar) {
					break;
				}
			}
			Console.WriteLine("Обслужени клиенти през деня: {0}", counter);
			Console.WriteLine("Край на работния ден!");
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			SmallBankOffice sbo = new SmallBankOffice();
			sbo.WorkDay();
			
			Console.ReadKey(true);
		}
	}
}