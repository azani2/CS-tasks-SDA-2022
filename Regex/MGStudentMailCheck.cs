/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 11.3.2021 г.
 * Time: 11:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text.RegularExpressions;

namespace mgemails
{
	class Program
	{
		public static bool IsMGStudentEmail(string str)
		{
			Regex pattern = new Regex(@"^[a-z]{2}[a-z]*\.[a-z]{3}[a-z]*-2[1-8][abvgde]|zh@mgberon\.com$");
			//^[a-z]{2}[a-z]*\.[a-z]{3}[a-z]*-2(([15]([abvgdez]|zh)) | ([2-4]([abvgde]|zh)) | ([6-8][abv]))@mgberon\.com$
			return pattern.IsMatch(str);
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Въведете електронна поща:");
			string mail = Console.ReadLine();
			if(IsMGStudentEmail(mail)) Console.WriteLine("Валидна служебна поща!");
			else Console.WriteLine("Невалидна служебна поща!");
			
			Console.ReadKey(true);
		}
	}
}