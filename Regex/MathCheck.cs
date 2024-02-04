/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 10.3.2021 г.
 * Time: 11:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Text.RegularExpressions;

namespace matchCheck
{
	class StringMatch
	{
		public static bool IsOneAThenB(string str)
		{
			Regex pattern = new Regex("^ab+$");
			return pattern.IsMatch(str);
		}
		public static bool IsOneAThreeB(string str)
		{
			Regex pattern = new Regex("^ab{3}$");
			return pattern.IsMatch(str);
		}
		public static bool IsTwoATwoOrThreeB(string str)
		{
			Regex pattern = new Regex("^a{1,2}b{2,3}$");
			return pattern.IsMatch(str);
		}
		public static bool IsAThenSthThenB(string str)
		{
			Regex pattern = new Regex("^a(.)*b$");
			return pattern.IsMatch(str);
		}
		public static bool IsLettersUnderscoreLetters(string str)
		{
			Regex pattern = new Regex("^[a-z]+_{1}([a-z]+)$");
			return pattern.IsMatch(str);
		}
		public static bool IsOneUpperThenLower(string str)
		{
			Regex pattern = new Regex("^[A-Z]([a-z]+)$");
			return pattern.IsMatch(str);
		}
		public static bool StartsWithAWord(string str)
		{
			Regex pattern = new Regex("^[A-Z]([a-z]+)");
			return pattern.IsMatch(str);
		}
		public static bool EndsWithAwordAndP(string str)
		{
			Regex pattern = new Regex("[a-z]+[?.!]$");
			return pattern.IsMatch(str);
		}
		public static bool IsWordWithZ(string str)
		{
			Regex pattern = new Regex("(^[Z]([a-z]+)$)||(^[A-Z]([a-z]*)z([a-z]*)$)");
			return (pattern.IsMatch(str));
		}
		public static bool IsWordWithZWithin(string str)
		{
			Regex pattern = new Regex("^[A-Z]([a-z]*)z([a-z]*)$");
			return pattern.IsMatch(str);
		}
		public static bool IsBGFirstName(string str)
		{
			Regex pattern = new Regex("^[А-Я]([а-я]+)$");
			return pattern.IsMatch(str);
		}
		public static bool IsBGFirstNameAdvanced(string str)
		{
			Regex pattern = new Regex("^[А-Я]([а-я]+)[ -][А-Я]([а-я]+)$");
			return pattern.IsMatch(str);
		}
		public static bool IsTime24(string str)
		{
			Regex pattern = new Regex("^[0-2]\\d:[0-5]\\d$");
			return pattern.IsMatch(str);
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Въведете текст за проверка");
			string str = Console.ReadLine();
			Console.Write("Изберете метод за проверка: ");
			int method = int.Parse(Console.ReadLine());
			bool[] methods = new bool[13] {
				StringMatch.IsOneAThenB(str), StringMatch.IsOneAThreeB(str),
				StringMatch.IsTwoATwoOrThreeB(str), StringMatch.IsAThenSthThenB(str),
				StringMatch.IsLettersUnderscoreLetters(str), StringMatch.IsOneUpperThenLower(str),
				StringMatch.StartsWithAWord(str), StringMatch.EndsWithAwordAndP(str),
				StringMatch.IsWordWithZ(str), StringMatch.IsWordWithZWithin(str),
				StringMatch.IsBGFirstName(str), StringMatch.IsBGFirstNameAdvanced(str),
				StringMatch.IsTime24(str)
			};
			
			for (int i = 0; i < methods.Length; i++) {
				if (method == (i+1)) {
					if(methods[i]) Console.WriteLine("да");
					else Console.WriteLine("не");
				}
			}
			
			Console.ReadKey(true);
		}
	}
}