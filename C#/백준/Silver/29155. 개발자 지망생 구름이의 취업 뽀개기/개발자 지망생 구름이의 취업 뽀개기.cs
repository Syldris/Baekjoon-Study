#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        List<int>[] list = new List<int>[5];
        for (int i = 0; i < 5; i++)
        {
            list[i] = new List<int>();
        }
        
        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            int k = int.Parse(line[0]);
            int t = int.Parse(line[1]);
            list[k-1].Add(t);
        }

        int result = 0;
        for (int i = 0; i < 5; i++)
        {
            int value = arr[i];
            if (value != 0)
            {
                list[i].Sort();
                if (i != 4)
                {
                    result += 60;
                }
            }

            for (int j = 0; j < value; j++)
            {
                result += list[i][j];
                if (j > 0)
                {
                    result += list[i][j] - list[i][j - 1];
                }
            }
        }
        sw.Write(result);
    }
}