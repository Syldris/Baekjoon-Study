#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int min = arr.Min();
        int max = arr.Max();

        if (min == max)
        {
            sw.Write(1);
            return;
        }

        int result = int.MaxValue;

        for (int i = 0; i < n; i++)
        {
            if (arr[i] == min || arr[i] == max)
            {
                int start = i, end = i + 1;

                while (start < end && end < n)
                {
                    // 최소 최대 | 최대 최소 일때 경우검사
                    if ((arr[start] == min && arr[end] == max) || (arr[start] == max && arr[end] == min))
                    {
                        result = Math.Min(result, end - start + 1);
                        break;
                    }

                    end++;
                }

                if (end < n)
                {
                    while (start < end)
                    {
                        // 최소 최대 | 최대 최소 일때 경우검사
                        if ((arr[start] == min && arr[end] == max) || (arr[start] == max && arr[end] == min))
                        {
                            result = Math.Min(result, end - start + 1);
                        }
                        start++; // start end 잡았을때 start 올리면서 검사
                    }
                }

                i = end - 1; // start~end 사이까진 조사 끝. end~? 조사
            }
        }

        sw.Write(result);

    }
}