/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 17.2.2021 г.
 * Time: 18:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace citiesList
{
	public class City
	{
		public  string cityName;
		public  string country;
		public  int population;

		public City(string ct, string ctr, int pop)
		{
			cityName = ct;
			country = ctr;
			population = pop;
		}
		public override string ToString()
		{
			return string.Format("{0, 12}{1, 18}{2, 12}", this.cityName, this.country, this.population);
		}
	}
	public class ByCityName : IComparer
	{
		public int Compare(Object x, Object y)
		{
			City c1 = (City)x;
			City c2 = (City)y;
			if( c1.cityName.CompareTo(c2.cityName) == 0) {
				return c1.country.CompareTo(c2.country);
			}
			return c1.cityName.CompareTo(c2.cityName);
		}
	}
	public class ByPopulation : IComparer
	{
		public int Compare(Object x, Object y)
		{
			City c1 = (City)x;
			City c2 = (City)y;
			if (c1.population == c2.population) {
				return c1.cityName.CompareTo(c2.cityName);
			}
			return (-1)*c1.population.CompareTo(c2.population);
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			City[] cities = new City[] {
				new City("Бяла", "България", 2034),
				new City("Оксфорд", "Канада", 1190),
				new City("Бангор", "Уелс", 13725), 
				new City("Оксфорд", "Англия", 152450),
				new City("Бангор", "САЩ", 31903),  
				new City("Оксфорд", "Нова Зеландия", 2370),
				new City("Бяла", "България", 7459),
				new City("Бангор", "Сев. Ирландия", 61011),
				new City("Лахор", "Пакистан", 12000000),
				new City("Москва", "Русия", 12000000),
				new City("Шънджън", "Китай", 12000000),
				new City("Бенгалуру", "Индия", 12000000),
				new City("Аврен", "България", 2345)
			};
			Console.WriteLine("Наличен е списък с данни за градове");
			foreach(City c in cities) {
				Console.WriteLine(c.ToString());
			}
			Console.WriteLine("Въведете 1) за подреждане по ред на имената или 2) за подреждане по население");
			Console.Write("Вашият избор: ");
			int choice = int.Parse(Console.ReadLine());
			
			IComparer sorter;
			if (choice == 1) {
					sorter = new ByCityName();
			} else {
				sorter = new ByPopulation();
			}
			
			Array.Sort(cities, sorter);
			foreach(City c in cities) {
				Console.WriteLine(c.ToString());
			}
			
			Console.ReadKey(true);
		}
	}
}