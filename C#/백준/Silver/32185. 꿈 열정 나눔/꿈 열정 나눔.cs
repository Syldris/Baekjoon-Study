#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int[] setting = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int value = setting[0] + setting[1] + setting[2];

        (int value, int num)[] arr = new (int, int)[n];
        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            arr[i] = (line[0] + line[1] + line[2], i + 1);
        }

        Array.Sort(arr, (a, b) => b.CompareTo(a));

        List<int> list = new List<int>();
        list.Add(0);

        for (int i = 0; i < n; i++)
        {
            if (list.Count >= m) break;

            if (arr[i].value <= value)
            {
                list.Add(arr[i].num);
            }
        }

        sw.Write(string.Join(' ', list));
    }
}