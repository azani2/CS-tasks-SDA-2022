/*
 * Created by SharpDevelop.
 * User: 2000-2
 * Date: 24.2.2021 г.
 * Time: 18:30 ч.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace busnumbers
{
	class Program
	{
		public static bool IsBusNumber(string str)
		{
			string letters = "ABCEHKMOPTXY";
			if (str.Length != 6 || 
				   letters.IndexOf(str[0]) == -1 || 
				   letters.IndexOf(str[4]) == -1 || 
				   letters.IndexOf(str[5]) == -1 )
			{
				return false;
			}
			try {
					int n = int.Parse(str.Substring(1, 3));
			} catch {
					return false;
			}
			return true;
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Въведете автобусен номер или 'край' за край:");
			string s = "";
			s = Console.ReadLine();
			do {
				if (IsBusNumber(s)) {
					Console.WriteLine("Да");
				} else {
					 Console.WriteLine("Не");
				}
				s = Console.ReadLine();
			} while(s.ToLower() != "край");
			
				
			Console.ReadKey(true);
		}
	}
}