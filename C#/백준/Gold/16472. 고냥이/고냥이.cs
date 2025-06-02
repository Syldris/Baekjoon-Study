#nullable disable
using System.Numerics;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        string input = sr.ReadLine();
        int maxValue = 0;

        int start = 0, end = 0;
        int alphabetCount = 0;
        int[] count = new int[26];
        while (end < input.Length)
        {
            int index = input[end] - 'a';
            if (count[index] == 0)
                alphabetCount++;
            count[index]++;
            while (alphabetCount > n)
            {
                int startIndex = input[start] - 'a';
                count[startIndex]--;
                if (count[startIndex] == 0)
                {
                    alphabetCount--;
                }
                start++;
            }
            maxValue = Math.Max(maxValue, end - start + 1);
            end++;
        }
        sw.Write(maxValue);
    }
}