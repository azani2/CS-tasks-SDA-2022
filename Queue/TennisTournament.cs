/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 19.4.2021 г.
 * Time: 16:00
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace tenis
{
	class TennisTournamentData
	{
		Queue<int> players;
		Queue<string> results;
		SortedList<int, string> plStats;
		public TennisTournamentData()
		{
			players = new Queue<int>(new int[] {3, 11, 2, 14, 9, 1, 10, 8, 4, 7, 15, 13, 16, 6, 12, 5 });
			results = new Queue<string>(new String[] {"2:1", "2:0", "0:2", "1:2", "2:0", "1:2", "0:2", "2:1", "0:2", "2:0", "1:2", "2:1", "0:2", "1:2", "2:1" });
			plStats = new SortedList<int, string>();
			for (int i = 0; i < 16; i++) {
				plStats.Add(i+1, "");
			}
		}
		public void PrintRounds()
		{
			string[] round = {"Първи", "Втори", "Трети"};
			foreach(string str in round) {
				Console.WriteLine("{0} кръг", str);
				OneRound();
			}
			int winner = players.Dequeue();
			Console.WriteLine("Победител в турнира е №" + winner);
			plStats[winner] += " печели турнира";
		}
		void OneRound()
		{
			Queue<int> nextRound = new Queue<int>();
			while(players.Count!=0) {
				int pl1 = players.Dequeue();
				int pl2 = players.Dequeue();
				string res = results.Dequeue();
				int winnerI = res.IndexOf('2');
				int winner = 0, loser = 0;
				if(winnerI == 0) {
					winner = pl1;
					loser = pl2;
				} else {
					winner = pl2;
					loser = pl1;
				}
				nextRound.Enqueue(winner);
				plStats[winner] += " победа";
				plStats[loser] += " загуба";;
				Console.WriteLine("№{0} - №{1}, победител е №{2}", pl1, pl2, winner);
			}
			players = new Queue<int>(nextRound);
		}
		public void PrintStats()
		{
			Console.WriteLine("\nСтатистика по участници");
			foreach(int stat in plStats.Keys) {
				Console.WriteLine("№{0} - {1}", stat, plStats[stat]);
			}
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			TennisTournamentData t1 = new TennisTournamentData();
			t1.PrintRounds();
			t1.PrintStats();
			
			
			Console.ReadKey(true);
		}
	}
}