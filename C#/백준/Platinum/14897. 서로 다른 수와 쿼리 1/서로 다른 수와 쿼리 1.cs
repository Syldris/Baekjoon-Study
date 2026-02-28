#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 21);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 21);

        int n = int.Parse(sr.ReadLine());
        int sqrtN = (int)Math.Sqrt(n);

        int bucketSize = (n / sqrtN) + 1;
        List<(int start, int end, int index)>[] bucket = new List<(int start, int end, int index)>[bucketSize];
        for (int i = 0; i < bucketSize; i++)
            bucket[i] = new();

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        (int value, int index)[] sorted = new (int, int)[n];
        for (int i = 0; i < n; i++)
            sorted[i] = (arr[i], i); // 값, 순서 
        Array.Sort(sorted);

        int rank = 0;
        for (int i = 0; i < n; i++)
        {
            if (i > 0 && sorted[i].value > sorted[i - 1].value) // 이전값보다 크면 증가
                rank++;

            arr[sorted[i].index] = rank;
        }

        int q = int.Parse(sr.ReadLine());

        for (int i = 0; i < q; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            line[0]--; // 1-index => 0-index
            line[1]--;

            bucket[line[0] / sqrtN].Add((line[0], line[1], i)); // 시작점을 기준으로 버킷 잡아야 한다.
        }

        for (int i = 0; i < bucketSize; i++)
        {
            if ((i & 1) == 0) bucket[i].Sort((a, b) => a.end.CompareTo(b.end)); // 끝점이 단조증가 하게끔.
            else bucket[i].Sort((a, b) => b.end.CompareTo(a.end)); // 지그재그로 줄어들게끔
        }

        int[] result = new int[q];

        int value = 1; // [0,0] 구간 시작.
        int startPoint = 0, endPoint = 0;

        int[] count = new int[n];
        count[arr[0]]++; // 시작값은 추가

        for (int i = 0; i < bucketSize; i++)
        {
            foreach ((int start, int end, int index) in bucket[i])
            {
                while (startPoint > start) // 시작점이 <- 으로 움직이니 확장.
                {
                    startPoint--;
                    value += Push(startPoint, true);
                }
                while (endPoint < end) // 끝점이 -> 으로 움직이니 확장.
                {
                    endPoint++;
                    value += Push(endPoint, true);
                }
                while (startPoint < start) // 시작점이 -> 으로 움직이니 축소.
                {
                    value += Push(startPoint, false);
                    startPoint++;
                }
                while (endPoint > end) // 끝점이 <- 으로 움직이니 축소.
                {
                    value += Push(endPoint, false);
                    endPoint--;
                }

                result[index] = value;
            }
        }

        for (int i = 0; i < q; i++)
        {
            sw.WriteLine(result[i]);
        }

        int Push(int pos, bool add)
        {
            int target = arr[pos];

            if (add) // 추가하는 쪽
            {
                if (count[target]++ == 0) // 0개였던 수 증가하면 다른수 갯수 +1
                    return 1;
                else
                    return 0;
            }
            else // 제거 하는쪽
            {
                if (--count[target] == 0) // 제거하고 갯수 0이면 다른수 갯수 -1
                    return -1;
                else
                    return 0;
            }
        }
    }
}