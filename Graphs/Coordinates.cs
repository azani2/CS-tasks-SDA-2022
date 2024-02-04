/*
 * Created by SharpDevelop.
 * User: Dell
 * Date: 1.3.2021 г.
 * Time: 16:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace coordinates
{
	public class Point3D
	{
		public int x, y, z;
		public Point3D(int x, int y, int z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}
		public override string ToString()
		{
			return string.Format("Point( {0}; {1}; {2})", x, y, z);
		}
	}
	public class ByCoordSum : IComparer
	{
		public int GetSum(Point3D p) {
			return p.x + p.y + p.z;
		}
		public int Compare(object x, object y) {
			Point3D p1 = (Point3D)x;
			Point3D p2 = (Point3D)y;
			int x1 = p1.x;
			int x2 = p2.x;
			int y1 = p1.y;
			int y2 = p2.y;
			int sum1 = GetSum(p1);
			int sum2 = GetSum(p2);
			
			if(sum1 == sum2) {
				return x1.CompareTo(x2);
			} else return sum1.CompareTo(sum2);
		}
	}
	class Program
	{
		public static void Main(string[] args)
		{
			Point3D[] points = new Point3D[] {
			new Point3D(1, 2, 3), new Point3D(3, 2, 1), new Point3D(2, 2, 2),
			new Point3D(3, 1, 2), new Point3D(3, 3, 0), new Point3D(2, -2, 4),
			new Point3D(5, 2, 3), new Point3D(3, 2, 5), new Point3D(0, 0, 0),
			new Point3D(1, 2, 7), new Point3D(6, 0, 0), new Point3D(0, 6, 0),
			new Point3D(0, 5, 5), new Point3D(1, 0, 9), new Point3D(4, 5, 1)};
			
			Console.WriteLine("Original list of 3D points");
			foreach(Point3D p in points) {
				Console.WriteLine(p.ToString());
			}
			
			Array.Sort(points, new ByCoordSum());
			
			Console.WriteLine("\nSorted list of 3D points");
			foreach(Point3D p in points) {
				Console.WriteLine(p.ToString());
			}
			
			Console.ReadKey(true);
		}
	}
}