/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 1.3.2021 г.
 * Time: 16:31
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace betweenfirstandlast
{
	class Program
	{
		public static string ExtractString(char c, string str)
		{
			if(str.IndexOf(c) == -1 || str.IndexOf(c) == str.LastIndexOf(c)) {
				return "";
			} 
			int iFirst = str.IndexOf(c);
			str = str.Substring(iFirst+1);
			int iSecond = str.IndexOf(c);
			string result = str.Substring(0, iSecond);
			return result;
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Въведете произволен символен низ:");
			string entered = Console.ReadLine();
			Console.Write("Въведете символ:");
			char symbol = Convert.ToChar(Console.ReadLine());
			Console.WriteLine("Резултат: \n{0}", ExtractString(symbol, entered));
			
			Console.ReadKey(true);
		}
	}
}