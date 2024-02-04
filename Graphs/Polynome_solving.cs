/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 21.2.2021 г.
 * Time: 14:53
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace polinom
{
	class Program
	{
		public static double CalcPolynom(double a, double b, double c, double d, double x)
		{
			double p;
			return p = a*Math.Pow(x, 3) + b*Math.Pow(x, 2) + c*Math.Pow(x, 1) + d;
		}
		public static double Calc(double a, double b, double c, double d, out double p)
		{
			int start = -1000, end = 1000;
			double ans = 0, z = 1;
			p = 0;
			for (int i = 1; i <= 20; i++)
			{
				if (i > 1) { start = 0; end = 9; }
				while (start <= end)
				{
					int middle = (start + end) / 2;
					p = CalcPolynom(a, b, c, d, (ans + middle)/z);
					if (p == 0) return ans + middle/z;
					if (p < 0) start = middle + 1;
					else end = middle - 1;
				}
				ans = ans + end / z;
				z *= 10;
			}
			return ans;
		}
		public static void Main(string[] args)
		{
			Console.WriteLine("Въведете коефициенти за полинома ах^3 + bx^2 + cx + d на отделни редове");
			Console.Write("a = ");
			double a = double.Parse(Console.ReadLine());
			Console.Write("b = ");
			double b = double.Parse(Console.ReadLine());
			Console.Write("c = ");
			double c = double.Parse(Console.ReadLine());
			Console.Write("d = ");
			double d = double.Parse(Console.ReadLine());
			double p = 0;
			Console.WriteLine("Приблизителен корен: " + Calc(a, b, c, d, out p));
			Console.WriteLine("Стойност на полинома: " + p);
			
			
			
			
			Console.ReadKey(true);
		}
	}
}