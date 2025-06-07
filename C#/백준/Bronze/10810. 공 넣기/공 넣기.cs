#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] inputs = sr.ReadLine().Split();
        int n = int.Parse(inputs[0]);
        int m = int.Parse(inputs[1]);
        int[] ints = new int[n+1];
        for (int i = 0; i < m; i++)
        {
            int[] line = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int start = line[0];
            int end = line[1];
            int num = line[2];
            for (int j = start; j <= end; j++)
            {
                ints[j] = num;
            }
        }
        for (int i = 1; i <= n; i++)
        {
            sw.Write($"{ints[i]} ");
        }
    }
}