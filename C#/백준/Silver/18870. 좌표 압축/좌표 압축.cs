#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int[] sorted = arr.Distinct().ToArray();
        Array.Sort(sorted);

        Dictionary<int, int> dict = new(sorted.Length);
        int rank = 0;

        foreach (var item in sorted)
        {
            dict[item] = rank++;
        }

        for (int i = 0; i < n; i++)
        {
            int index = arr[i];
            arr[i] = dict[index];
        }

        sw.Write(String.Join(' ', arr));
    }
}