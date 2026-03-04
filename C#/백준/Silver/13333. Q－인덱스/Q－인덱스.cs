#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        Array.Sort(arr, (a, b) => b.CompareTo(a));

        for (int k = n; k >= 0; k--)
        {
            int value = 0;
            for (int i = 0; i < n; i++)
            {
                if (arr[i] >= k)
                {
                    value++;
                    if(value >= k)
                    {
                        sw.Write(k);
                        return;
                    }
                }
                else
                    break;
            }
        }

    }
}