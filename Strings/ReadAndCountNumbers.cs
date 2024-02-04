/*
 * Created by SharpDevelop.
 * User: mega
 * Date: 25.2.2021 г.
 * Time: 12:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace countnums
{
	class Program
	{
		public static int ReadAndCountNumbers(string fileName)
		{
			int n = 0;
			string txt = System.IO.File.ReadAllText(fileName);
			Console.WriteLine("File content:\n{0}", txt);
			char[] separators = {' ',',', '.', '-', '!', '?', ':', ';', '[', ']', '(', ')'};
			string[] words = txt.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			foreach(string w in words) {
				int result = 0;
				bool isNum = int.TryParse(w, out result);
				if (isNum) {
					int toNum = Convert.ToInt32(w);
					n++;
				}
			}
			return n;
		}
		public static void Main(string[] args)
		{
			Console.Write("File: ");
			string fName = Console.ReadLine();
			Console.WriteLine("Numbers found: {0}", ReadAndCountNumbers(fName));
			
			
			Console.ReadKey(true);
		}
	}
}