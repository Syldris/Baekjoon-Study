#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split(' ');
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int sqrtN = (int)Math.Sqrt(n);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int[] sorted = arr.Distinct().ToArray();
        Array.Sort(sorted);

        Dictionary<int, int> dict = new();
        int rank = 0;

        for (int i = 0; i < sorted.Length; i++)
        {
            dict[sorted[i]] = ++rank;
        }

        int bucketSize = n / sqrtN + 1;
        List<(int start, int end, int index)>[] bucket = new List<(int, int, int)>[bucketSize];
        for (int i = 0; i < bucketSize; i++)
            bucket[i] = new();

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int start = line[0];
            int end = line[1];

            // 시작점을 sqrtN으로 나눠서 각 버킷에 담음. 시작점 쿼리마다 sqrtN 범위이내 움직임. MSqrtN
            bucket[start / sqrtN].Add((start, end, i));
        }

        // 끝점은 버킷마다 단조증가 / 단조감소 로 버킷마다 N. 버킷갯수 sqrtN 이니 NsqrtN
        for (int i = 0; i < bucketSize; i++)
        {
            if (i % 2 == 0) // 오름차순
                bucket[i].Sort((a, b) => a.end.CompareTo(b.end));
            else            // 내림차순
                bucket[i].Sort((a, b) => b.end.CompareTo(a.end));
        }

        long[] tree = new long[rank + 1];
        long[] result = new long[m];

        long value = 0;
        int left = 1;
        int right = 1;
        Move(1, true, true); // 1~1 시작.

        for (int i = 0; i < bucketSize; i++)
        {
            foreach ((int start, int end, int index) in bucket[i])
            {
                while (left > start) // start <- left 확장
                {
                    left--;
                    value += Move(left, true, true);
                }
                while (right < end) // right -> end 확장 
                {
                    right++;
                    value += Move(right, true, false);
                }
                while (left < start) // left -> start 축소
                {
                    value += Move(left, false, true);
                    left++;
                }
                while (right > end) // end <- right 축소
                {
                    value += Move(right, false, false);
                    right--;
                }

                result[index] = value;
            }
        }

        for (int i = 0; i < m; i++)
        {
            sw.WriteLine(result[i]);
        }

        long Move(int index, bool add, bool before) // 인덱스, 값 추가제거 여부, 값 찾는 범위 
        {
            int x = dict[arr[index - 1]]; // 값 순서
            long value = 0;

            if (before)
            {
                value = Query(1, x - 1); // 나보다 작은 원소 카운트
            }
            else
            {
                value = Query(x + 1, rank); // 나보다 큰 원소 카운트
            }

            Update(x, add);

            return add ? value : -value;
        }

        void Update(int x, bool add)
        {
            while (x <= rank)
            {
                tree[x] += add ? 1 : -1;
                x += x & -x;
            }
        }

        long Sum(int x)
        {
            long value = 0;
            while (x > 0)
            {
                value += tree[x];
                x -= x & -x;
            }
            return value;
        }

        long Query(int left, int right)
        {
            return Sum(right) - Sum(left - 1);
        }
    }
}