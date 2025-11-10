#nullable disable
using System;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        (int k, int work)[] arr = new (int k, int l)[n];

        int[] minhp = new int[200001];
        Array.Fill(minhp, 200001);
        for (int i = 0; i < n; i++)
        {
            string[] input = sr.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);

            if (a - b < 0)
            {
                sw.WriteLine(-1);
                return;
            }
            minhp[a] = Math.Min(minhp[a], a - b);

            arr[i] = (a, b);
        }
        arr = arr.OrderBy(x => x.k).ThenByDescending(x => x.work).ToArray();

        for (int i = arr.Max().k - 1; i >= 0; i--)
        {
            minhp[i] = Math.Min(minhp[i], minhp[i + 1]);
        }

        int day = 0;
        int health = 0;
        int iq = 0;
        long result = 0;

        foreach ((int k, int work) in arr)
        {
            int point = k - day;
            int healthpoint = Math.Min(minhp[k] - health, point);
            int neediq = point - healthpoint;

            health += healthpoint;
            iq += neediq;
            result += health;
            day = k;
        }

        sw.Write(result);
    }
}
