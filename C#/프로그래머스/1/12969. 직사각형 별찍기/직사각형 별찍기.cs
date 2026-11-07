using System;

public class Example
{
    public static void Main()
    {
        string[] s = Console.ReadLine().Split(' ');

        int m = int.Parse(s[0]);
        int n = int.Parse(s[1]);

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(new string('*', m));
        }
    }
}