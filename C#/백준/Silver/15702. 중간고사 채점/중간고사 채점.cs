#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int[] scores = new int[100001];
        Array.Fill(scores, -1);
        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split();
            int num = int.Parse(line[0]);
            scores[num] = 0;
            for (int j = 1; j <= n; j++)
            {
                if (line[j] == "O")
                    scores[num] += arr[j - 1];
            }
        }

        int index = 0;
        int max = -1;

        for (int i = 1; i <= 100000; i++)
        {
            if (scores[i] > max)
            {
                index = i;
                max = scores[i];
            }
        }

        sw.Write($"{index} {max}");
    }
}