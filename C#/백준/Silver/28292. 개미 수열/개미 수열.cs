#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        if(n > 10)
        {
            sw.Write(3);
            return;
        }


        StringBuilder sb = new StringBuilder();
        string[] arr = new string[11];
        arr[1] = "1";

        for (int i = 2; i <= 10; i++)
        {
            char prev = arr[i - 1][0];
            int count = 0;

            foreach (char c in arr[i - 1])
            {
                if (c == prev)
                {
                    count++;
                }
                else
                {
                    sb.Append(prev);
                    sb.Append(count);
                    prev = c;
                    count = 1;
                }
            }

            sb.Append(prev);
            sb.Append(count);

            arr[i] = sb.ToString();
            sb.Clear();
        }

        int max = 0;
        foreach (var item in arr[n])
        {
            int num = item - '0';
            max = Math.Max(max, num);
        }
        sw.Write(max);
    }
}