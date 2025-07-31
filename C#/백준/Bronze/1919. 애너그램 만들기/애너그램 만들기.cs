#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string input1 = sr.ReadLine();
        string input2 = sr.ReadLine();

        int[] value1 = new int[26];
        int[] value2 = new int[26];
        foreach (char c in input1)
        {
            value1[c -'a']++;
        }
        foreach (char c in input2)
        {
            value2[c -'a']++;
        }

        int result = 0;
        for (int i = 0; i < 26; i++)
        {
            if (value1[i] != value2[i])
            {
                result += Math.Abs(value1[i] - value2[i]);
            }
        }
        sw.Write(result);
    }
}
