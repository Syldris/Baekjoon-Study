#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int one = 0;
        int two = 0;
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == 1)
                one++;
            else
                two++;
        }

        one = one - two;

        if (one < 0 || one % 3 != 0)
        {
            sw.Write("No");
        }
        else
        {
            sw.Write("Yes");
        }

    }
}