/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 19.4.2021 г.
 * Time: 16:44
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace jrec
{
	class Decoding
	{
		Stack<char> st;
		string mess;
		string ans;
		public Decoding(string message)
		{
			st = new Stack<char>();
			mess = message;
			ans = "";
		}
		public void Decode()
		{
			st.Push(mess[0]);
			for (int i = 1; i < mess.Length; i++) {
				if(st.Count != 0 && st.Peek() == mess[i]) {
						st.Pop();
				} else st.Push(mess[i]);
			}
		}
		public void Print() 
		{
			Console.WriteLine("Декодирано послание:");
			while(st.Count!=0) {
				ans += st.Pop();
			}
			for (int i = ans.Length-1; i >= 0; i--) {
				Console.Write(ans[i]);
			}
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Въведете послание:");
			string mssg = Console.ReadLine();
			Decoding d1 = new Decoding(mssg);
			d1.Decode();
			d1.Print();
			
			
			Console.ReadKey(true);
		}
	}
}