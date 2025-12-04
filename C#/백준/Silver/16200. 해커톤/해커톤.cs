#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        Array.Sort(arr);

        int index = 0;
        int result = 0;
        for (int i = 0; i < n; i += index)
        {
            index = arr[i];
            result++;
        }

        sw.Write(result);
    }
}