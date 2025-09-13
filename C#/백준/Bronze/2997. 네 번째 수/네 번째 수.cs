#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
        Array.Sort(input);
        int a = input[0];
        int b = input[1];
        int c = input[2];
        if (input[2] - input[1] == input[1] - input[0])
        {
            sw.Write(input[2] + input[2] - input[1]);
        }
        else if (input[1] - input[0] < input[2] - input[1]) 
        {
            sw.Write(input[1] + input[1] - input[0]);
        }
        else
        {
            sw.Write(input[0] + input[2] - input[1]);
        }
    }
}
