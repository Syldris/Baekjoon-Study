#nullable disable
using System.Text;

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        char[] arr = new char[n];
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
            arr[i] = sr.ReadLine()[0];
        }

        int start = 0, end = n - 1;
        int value = 0;
        while (start <= end)
        {
            if (arr[start] < arr[end])
            {
                sb.Append(arr[start]);
                start++;
            }
            else if(arr[start] > arr[end])
            {
                sb.Append(arr[end]);
                end--;
            }
            else
            {
                int i = start + 1, j = end - 1;
                while (i <= j)
                {
                    if(arr[i] < arr[j])
                    {
                        sb.Append(arr[start]);
                        start++;
                        break;
                    }
                    else if (arr[i] > arr[j])
                    {
                        sb.Append(arr[end]);
                        end--;
                        break;
                    }
                    i++;
                    j--;
                }
                if(i > j)
                {
                    sb.Append(arr[start]);
                    start++;
                }
            }
            value++;
            if (value == 80)
            {
                sb.AppendLine();
                value = 0;
            }
        }
        sw.Write(sb);
    }
}