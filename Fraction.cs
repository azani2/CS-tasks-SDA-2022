/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 24.3.2021 г.
 * Time: 20:48
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace drobi
{
	class Fraction 
	{
		public int num, denom;
		public Fraction()
		{
			num = 0;
			denom = 1;
		}
		public Fraction(int n)
		{
			num = n;
			denom = 1;
		}
		public Fraction(Fraction b)
		{
			num = b.num;
			denom = b.denom;
		}
		public Fraction(int n, int d)
		{
			if (d == 0) throw new ArgumentException("Знаменателят не може да бъде равен на 0!");
			num = n;
			denom = d;
			if (denom < 0) {
				num *= -1;
				denom *= -1;
			}
		}
		public static int GCD(int a, int b)
		{
			if (a < 0) a *= -1;
			if (b < 0) b *= -1;
			if (a == b || b == 0) return 1;
			int ost = a % b;
			while (ost != 0) {
				a = b;
				b = ost;
				ost = a % b;
			}
			return b;
		}
		public void Add(Fraction b)
		{
			//изравняване на знаменателите
			int nod = Fraction.GCD(this.denom, b.denom);
			int od = (this.denom / nod) * b.denom;
			//събиране
			this.num = this.num * (od / this.denom) + b.num * (od / b.denom);
			this.denom = od;
			//съкращаване
			nod = Fraction.GCD(this.num, this.denom);
			if (nod > 1) {
				this.num /= nod;
				this.denom /= nod;
			}
		}
		public void Sub(Fraction b)
		{
			this.Add(new Fraction(-1*b.num, b.denom));
		}
		public void Mult(Fraction b) 
		{
			this.num *= b.num;
			this.denom *= b.denom;
			int nod = Fraction.GCD(this.num, this.denom);
			if (nod > 1) {
				this.num /= nod;
				this.denom /= nod;
			}
		}
		public void Div(Fraction b)
		{
			if (b.num == 0) throw new DivideByZeroException();
			this.Mult(new Fraction(b.denom, b.num));
		}
		public override string ToString()
		{
			if (num == 0) return "0";
			if (denom == 1) return num.ToString();
			return string.Format("{0}/{1}", num, denom);
		}
		public static Fraction operator + (Fraction f1, Fraction f2)
		{
			Fraction f = new Fraction(f1);
			f.Add(f2);
			return f;
		}
		public static Fraction operator - (Fraction f1, Fraction f2)
		{
			Fraction f = new Fraction(f1);
			f.Sub(f2);
			return f;
		}
		public static Fraction operator * (Fraction f1, Fraction f2)
		{
			Fraction f = new Fraction(f1);
			f.Mult(f2);
			return f;
		}
		public static Fraction operator / (Fraction f1, Fraction f2)
		{
			Fraction f = new Fraction(f1);
			f.Div(f2);
			return f;
		}
		
	}
	class Program
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Въведете първата дроб");
			Console.Write("Числител: ");
			int num1 = int.Parse(Console.ReadLine());
			Console.Write("Знаменател: ");
			int denom1 = int.Parse(Console.ReadLine());
			Console.WriteLine("Въведете втората дроб");
			Console.Write("Числител: ");
			int num2 = int.Parse(Console.ReadLine());
			Console.Write("Знаменател: ");
			int denom2 = int.Parse(Console.ReadLine());
			Fraction f1 = new Fraction(num1, denom1);
			Fraction f2 = new Fraction(num2, denom2);
			
			Console.WriteLine("{0} + {1} = {2}", f1.ToString(), f2.ToString(), (f1 + f2).ToString());
			Console.WriteLine("{0} - {1} = {2}", f1.ToString(), f2.ToString(), (f1 - f2).ToString());
			Console.WriteLine("{0} * {1} = {2}", f1.ToString(), f2.ToString(), (f1 * f2).ToString());
			Console.WriteLine("{0} / {1} = {2}", f1.ToString(), f2.ToString(), (f1 / f2).ToString());
			
			Console.ReadKey(true);
			
			Console.Clear();
			Console.WriteLine("Въведете естествени числа А и В (А < В)");
			Console.Write("A: ");
			int a = int.Parse(Console.ReadLine());
			Console.Write("B: ");
			int b = int.Parse(Console.ReadLine());
			int temp = a + 1;
			f1 = new Fraction(1, a);
			f2 = new Fraction(1, temp);
			
			Console.Write("{0} ", f1.ToString());
			while (temp <= b) {
				Console.Write("+ {0}", f2.ToString());
				f1 += f2;
				temp++;
				f2 = new Fraction(1, temp);
			}
			Console.Write(" = {0}", f1.ToString());
			
			Console.ReadKey(true);
			
		}
	}
}