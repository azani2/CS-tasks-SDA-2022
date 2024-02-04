/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 5.5.2021 г.
 * Time: 17:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace volleyball
{
	class Program
	{
		public static void Swap(int[] p, int i, int j) 
		{
			int t = p[i];
			p[i] = p[j];
			p[j] = t;
		}
		public static void Reverse(int[] p, int i, int j)
		{
			while(i<j) {
				Swap(p, i++, j--);
			}
		}
		public static void ReadTeams(string[] teams, string[] choosen, int[] newArr)
		{
			for (int i = 0; i < newArr.Length; i++) {
				newArr[i] = Array.IndexOf(teams, choosen[i]);
			}
		}
		public static string TeamsToText(string[] teams, string numbers)
		{
			string res = "";
			for (int i = 0; i < numbers.Length; i++) {
				res+= teams[numbers[i]] + " ";
			}
			return res;
		}
		public static void Main(string[] args)
		{
			List<string> allP = new List<string>();
			Console.WriteLine("All participant teams abbreviations:");
			string[] teams = Console.ReadLine().ToUpper().Split(' ');
			int[] tms = new int[teams.Length];
			for (int i = 0; i < tms.Length; i++) {
				tms[i] = i;
			}
			
			Console.WriteLine("Teams after sixth place: ");
			string[] belowSixth = Console.ReadLine().ToUpper().Split(' ');
			int[] below6th = new int[belowSixth.Length];
			ReadTeams(teams, belowSixth, below6th);
			
			Console.WriteLine("Teams after third place: ");
			string[] belowThird = Console.ReadLine().ToUpper().Split(' ');
			int[] below3rd = new int[belowThird.Length];
			ReadTeams(teams, belowThird, below3rd);
			
			Console.WriteLine("Not to win the tournament");
			string[] belowFirst = Console.ReadLine().ToUpper().Split(' ');
			int[] not1st = new int[belowFirst.Length];
			ReadTeams(teams, belowFirst, not1st);
			
			while(true) {
				bool ok = true;
				string pS = string.Join("", tms);
				foreach(int l in below3rd) {
					if(pS.Substring(0, 6).Contains(l.ToString())) { ok = false; }
				}
				foreach(int l in below3rd) {
					if(pS.Substring(0, 3).Contains(l.ToString())) { ok = false; }
				}
				foreach(int l in not1st) {
					if(pS.Substring(0, 1).Contains(l.ToString())) { ok = false; }
				}
				if (ok) {
					allP.Add(pS);
				}
				
				int i = tms.Length - 1;
				while (tms[i-1] >= tms[i]) {
					i--; if(i == 0) { return; }
				}
				int j = tms.Length - 1;
				while (j > i && tms[j] <= tms[i-1]) j--;
				Swap(tms, i-1, j);
				Reverse(tms, i, tms.Length - 1);
			}
			
			Console.WriteLine("Total of {0} possible classements" , allP.Count);
			Console.WriteLine("Example of possible classement");
			Random rnd = new Random();
			Console.WriteLine(TeamsToText(teams, allP[rnd.Next(0, allP.Count)]));
			Console.ReadKey(true);
		}
	}
}