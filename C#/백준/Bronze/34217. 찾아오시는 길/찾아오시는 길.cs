#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        string[] input2 = sr.ReadLine().Split();

        int a = int.Parse(input[0]);
        int b = int.Parse(input[1]);
        int c = int.Parse(input2[0]);
        int d = int.Parse(input2[1]);
        sw.Write(a + c < b + d ? "Hanyang Univ." : a + c > b + d ? "Yongdap" : "Either");
    }
}