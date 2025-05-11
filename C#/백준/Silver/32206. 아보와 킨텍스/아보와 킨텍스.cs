using System;
public class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string text = Console.ReadLine();
        Console.WriteLine((n + 1) * 26 - n);
    }
}
