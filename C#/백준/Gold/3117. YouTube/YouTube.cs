#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 17);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int v = int.Parse(input[1]);
        int m = int.Parse(input[2]) - 1;

        int logM = (int)Math.Floor(Math.Log(m, 2)) + 1;

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] viedo = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int[,] parent = new int[v + 1, logM];
        for (int i = 1; i <= v; i++)
        {
            parent[i, 0] = viedo[i - 1];
        }

        for (int k = 1; k < logM; k++)
        {
            for (int i = 1; i <= v; i++)
            {
                parent[i, k] = parent[parent[i, k - 1], k - 1];
            }
        }

        List<int> list = new List<int>();
        for (int i = 0; i < n; i++)
        {
            int value = arr[i];
            for (int j = 0; j < logM; j++)
            {
                bool bit = ((m >> j) & 1) == 1;
                if (bit)
                {
                    value = parent[value, j];
                }
            }
            list.Add(value);
        }

        sw.Write(string.Join(' ', list));
    }
}