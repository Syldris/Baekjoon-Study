#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        sw.WriteLine("int a;");
        sw.WriteLine("int *ptr = &a;");
        if (n >= 2)
            sw.WriteLine("int **ptr2 = &ptr;");

        for (int i = 3; i <= n; i++)
        {
            sw.WriteLine($"int {new string('*', i)}ptr{i} = &ptr{i - 1};");
        }
    }
}