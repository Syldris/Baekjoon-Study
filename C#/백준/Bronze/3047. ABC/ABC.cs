#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] arr = sr.ReadLine().Split(' ').Select(int.Parse).ToArray();
        Array.Sort(arr);
        string line = sr.ReadLine();
        foreach (var item in line)
        {
            if (item == 'A')
            {
                sw.Write($"{arr[0]} ");
            }
            else if (item == 'B')
            {
                sw.Write($"{arr[1]} ");
            }
            else
            {
                sw.Write($"{arr[2]} ");
            }
        }
    }
}
