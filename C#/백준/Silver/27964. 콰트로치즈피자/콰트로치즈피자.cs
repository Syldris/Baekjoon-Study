#nullable disable
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        string[] arr = sr.ReadLine().Split();

        int value = 0;
        HashSet<string> hash = new();
        for (int i = 0; i < n; i++)
        {
            if (arr[i].Length >= 6 && arr[i][^6..] == "Cheese" && !hash.Contains(arr[i]))
            {
                hash.Add(arr[i]);
                value++;
                if (value >= 4)
                {
                    sw.Write("yummy");
                    return;
                }
            }
        }
        sw.Write("sad");
    }
}