#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] arrA = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] arrB = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        HashSet<int> hash = new();
        for (int i = 0; i < m; i++)
        {
            hash.Add(arrB[i]);
        }

        List<int> result = new List<int>();
        for (int i = 0; i < n; i++)
        {
            if (!hash.Contains(arrA[i]))
            {
                result.Add(arrA[i]);
            }
        }
        result.Sort();

        sw.WriteLine(result.Count);
        sw.Write(string.Join(' ', result));
    }
}