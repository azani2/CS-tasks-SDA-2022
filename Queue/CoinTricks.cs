/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 15.4.2021 г.
 * Time: 12:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace coins
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.Write("Въведете начален брой монети: ");
			int start = int.Parse(Console.ReadLine());
			Console.Write("Въведете краен брой монети: ");
			int end = int.Parse(Console.ReadLine());
			
			int guess = 0;
			Stack<int> guesses = new Stack<int>();
			Stack<int> tricks = new Stack<int>(); //0 - mult. by 2, 1 - make 1, 2 - destroy 1
			
			while (guess != start) {
				if (end > start) {
					if (end % 2 != 0) {
						end--;
						guess = end;
						guesses.Push(guess);
						tricks.Push(1);
					} else {
						int divby2 = guess/2;
						if (divby2 < start && (start - divby2) > (end - start)) {
							end--;
							guess = end;
							guesses.Push(guess);
							tricks.Push(1);
						} else {
							end = divby2;
							guess = end;
							guesses.Push(guess);
							tricks.Push(0);
						}
					}
				} else {
					end++;
					guess = end;
					guesses.Push(guess);
					tricks.Push(2);
				}
			}
			Console.WriteLine("Необходими са най-малко {0} трика", tricks.Count);
			while(guesses.Count != 0) {
				int currentTrick = tricks.Pop();
				int currentGuess = guesses.Pop();
				switch (currentTrick) {
					case 0: 
						Console.WriteLine("Удвояват се монетите => {0} -> {1}", currentGuess, currentGuess*2);
						break;
					case 1: 
						Console.WriteLine("Създава се 1 монета => {0} -> {1}", currentGuess, currentGuess+1);
						break;
					case 2: 
						Console.WriteLine("Унищожава се 1 монета => {0} -> {1}", currentGuess, currentGuess-1);
						break;
				}
			}
			
			
			Console.ReadKey(true);
		}
	}
}