using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
class Program
{
    static void Main()
    {
        int t = int.Parse(Console.ReadLine());
        StringBuilder sb  = new StringBuilder();
        for (int i = 1; i <= t; i++)
        {
            string[] inputs = Console.ReadLine().Split();
            int a = int.Parse(inputs[0]);
            int b = int.Parse(inputs[1]);
            sb.AppendLine($"Case {i}: {a + b}");
        }
        Console.WriteLine(sb);
    }
}