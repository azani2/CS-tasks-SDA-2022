/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 24.2.2021 г.
 * Time: 9:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace listofdates
{
	public class Date
	{
		public string monthYear;
		public int day;
		public Date(string my, int d)
		{
			monthYear = my;
			day = d;
		}
		
		public override string ToString()
		{
			return string.Format("{0, 10}{1, 8}", monthYear, day);
		}
	}
	public class ByDate : IComparer
	{
		int MonthNum(string monthName)
		{
			string[] months = new string[12] {"Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"};
			for (int i = 0; i < 12; i++) {
				if(monthName == months[i]) return i;
			}
			return -1;
		}
		public int Compare(Object x, Object y)
		{
			Date d1 = (Date)x;
			Date d2 = (Date)y;
			int dayX = d1.day;
			int dayY = d2.day;
			string yearX = d1.monthYear.Substring(d1.monthYear.Length - 4);
			int yX = int.Parse(yearX);
			string yearY = d2.monthYear.Substring(d2.monthYear.Length - 4);
			int yY = int.Parse(yearY);
			int monthX = MonthNum(d1.monthYear.Substring(0, 3));
			int monthY = MonthNum(d2.monthYear.Substring(0, 3));
			
			if(yX == yY) {
				if (monthX == monthY) {
					return dayX.CompareTo(dayY);
				} else {
					return monthX.CompareTo(monthY);
				}
			} else {
				return (-1)*yX.CompareTo(yY);
			}
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			Date[] dates = new Date[] {
				new Date("Dec 2000", 25),
				new Date("Feb 2000", 25),
				new Date("Jan 2000", 25),
				new Date("Apr 2005", 1),
				new Date("Apr 2005", 14),
				new Date("May 2005", 8),
				new Date("May 2006", 12),
				new Date("Jan 2015", 12),
				new Date("Feb 2016", 2),
				new Date("Feb 2017", 2),
				new Date("Feb 2015", 1),
				new Date("Aug 2020", 10),
				new Date("Oct 2020", 10),
				new Date("Jan 2020", 15),
				new Date("Oct 2019", 15)
			};
			Console.WriteLine("Original list of dates:");
			
			foreach (Date d in dates) {
				Console.WriteLine(d.ToString());
			}
			
			Console.WriteLine("Sorted list of dates:");
			
			Array.Sort(dates, new ByDate());
			
			foreach (Date d in dates) {
				Console.WriteLine(d.ToString());
			}
			
			Console.ReadKey(true);
		}
	}
}