#nullable disable
using System;
class Program
{
    public struct Point
    {
        public long x;
        public long y;
        public Point(long x, long y)
        {
            this.x = x;
            this.y = y;
        }
    }

    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        Point[] points = new Point[n];

        for (int i = 0; i < n; i++)
        {
            string[] input = sr.ReadLine().Split();
            int x = int.Parse(input[0]);
            int y = int.Parse(input[1]);
            points[i] = new Point(x, y);
        }

        int pivot = 0;
        for (int i = 1; i < n; i++)
        {
            if (points[i].y < points[pivot].y || points[i].y == points[pivot].y && points[i].x < points[pivot].x)
            {
                pivot = i;
            }
        }

        (points[0], points[pivot]) = (points[pivot], points[0]);

        Point Sub(Point a, Point b) => new Point(a.x - b.x, a.y - b.y);
        long Cross(Point a, Point b) => a.x * b.y - a.y * b.x;

        Array.Sort(points, 1, n - 1, Comparer<Point>.Create((a, b) =>
        {
            Point va = Sub(a, points[0]);
            Point vb = Sub(b, points[0]);
            long cross = Cross(va, vb);

            if (cross != 0) return cross > 0 ? -1 : 1;

            long distA = va.x * va.x + va.y * va.y;
            long distB = vb.x * vb.x + vb.y * vb.y;

            return distA.CompareTo(distB);
        }));

        Stack<Point> stack = new Stack<Point>();
        stack.Push(points[0]);
        stack.Push(points[1]);
        for (int i = 2; i < n; i++)
        {
            while (stack.Count >= 2)
            {
                Point top = stack.Pop();
                Point peek = stack.Peek();

                Point dist1 = Sub(top, peek);
                Point dist2 = Sub(points[i], top);

                long cross = Cross(dist1, dist2);

                if (cross > 0)
                {
                    stack.Push(top);
                    break;
                }
            }
            stack.Push(points[i]);
        }
        sw.Write(stack.Count);
    }
}
