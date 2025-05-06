using System;
using System.Text;
using System.IO;
public class Program
{
    static void Main()
    {
        int[] a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] b = Console.ReadLine().Split().Select(int.Parse).ToArray();

        int totala = 0;
        int totalb = 0;

        for (int i = 0; i < 4; i++)
        {
            totala += a[i];
            totalb += b[i];
        }

        Console.WriteLine(totala > totalb ? totala : totalb);
    }
}
