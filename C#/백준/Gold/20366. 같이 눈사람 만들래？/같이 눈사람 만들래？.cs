#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int minvalue = int.MaxValue;
        Array.Sort(arr);
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                    continue;
                int value = arr[i] + arr[j];

                int start = 0, end = n- 1;

                while (start < end)
                {
                    if (start == i || start == j)
                    {
                        start++;
                        continue;
                    }
                    if (end == i || end == j)
                    {
                        end--;
                        continue;
                    }
                    int curValue = arr[end] + arr[start];

                    minvalue = Math.Min(minvalue, Math.Abs(value - curValue));

                    if(curValue > value)
                    {
                        end--;
                    }
                    else if (curValue < value)
                    {
                        start++;
                    }
                    else
                    {
                        sw.Write(0);
                        return;
                    }
                }
            }
        }
        sw.Write(minvalue);
    }
}