#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        List<int> result = new List<int>(n);

        for (int i = 0; i < n; i++)
        {
            int pos = result.Count - arr[i]; // 대기줄 - 내가 앞으로 갈수있는 번호
            result.Insert(pos, i + 1);

        }

        sw.Write(string.Join(' ', result));
    }
}