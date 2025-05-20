using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        long a = long.Parse(inputs[0]);
        long b = long.Parse(inputs[1]);
        sw.Write(a * b / 2);
    }
}