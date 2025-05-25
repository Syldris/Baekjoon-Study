#nullable disable
using System.Collections;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] inputs = sr.ReadLine().Split().Select(int.Parse).ToArray();
        Array.Sort(inputs);
        int a = Math.Min(inputs[0], inputs[1]);
        int b = Math.Min(inputs[2], inputs[3]);
        sw.Write(a * b);
    }
}