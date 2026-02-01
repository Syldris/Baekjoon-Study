#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int[] arrA = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] arrB = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        Dictionary<int, int> dict = new();
        for (int i = 0; i < n; i++)
        {
            int number = arrA[i];
            dict.Add(number, i);
        }

        (int num, int diff)[] rank = new (int, int)[n];
        int maxDiff = 0;

        for (int i = 0; i < n; i++)
        {
            int number = arrB[i];
            int diff = dict[number] - i;

            rank[i] = (number, diff);
            maxDiff = Math.Max(maxDiff, diff);
        }

        List<int> list = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (rank[i].diff == maxDiff)
            {
                list.Add(rank[i].num);
            }
        }

        sw.Write(string.Join(' ', list));
    }
}