#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        int sqrtN = (int)Math.Sqrt(n);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);

        int bucketSize = n / sqrtN + 1;
        List<(int start, int end, int index)>[] bucket = new List<(int start, int end, int index)>[bucketSize];

        for (int i = 0; i < bucketSize; i++)
            bucket[i] = new();

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            int start = line[0];
            int end = line[1];

            // 시작점을 sqrtN기준으로 나눠서 버킷에 담음. 시작점 움직임은 쿼리마다 sqrtN수준. M * SqrtN
            bucket[start / sqrtN].Add((start, end, i));
        }

        // 버킷마다 끝점을 단조증가 / 감소 끝점 움직임은 버킷마다 N수준. sqrtN * N
        for (int i = 0; i < bucketSize; i++)
        {
            if (i % 2 == 0) // 끝점 오름차순
                bucket[i].Sort((a, b) => a.end.CompareTo(b.end));
            else            // 끝점 내림차순
                bucket[i].Sort((a, b) => b.end.CompareTo(a.end));
        }


        long[] result = new long[m];
        int[] tree = new int[n + 1]; // 팬윅트리. x에 대해 등장횟수를 기록. 

        int left = 1;
        int right = 1;
        long value = 0;

        value += Move(1, true, true); // 1~1 시작.

        for (int i = 0; i < bucketSize; i++)
        {
            foreach ((int start, int end, int index) in bucket[i])
            {
                while (left > start) // start <- left 확장
                {
                    left--; // 확장시에는 이동후 값 추가
                    value += Move(left, true, false); // 가장 왼쪽에 있으니 나보다 작은 오른쪽의 값 찾기.
                }
                while (right < end) // right -> end 확장
                {
                    right++;
                    value += Move(right, true, true); // 가장 오른쪽에 있으니 나보다 큰 값 찾기.
                }
                while (left < start) // left -> start 축소
                {
                    value += Move(left, false, false);
                    left++; // 축소시에는 먼저 범위에서 값 제거후 이동
                }
                while (right > end) // end <- right 축소
                {
                    value += Move(right, false, true);
                    right--;
                }
                result[index] = value;
            }
        }

        for (int i = 0; i < m; i++)
        {
            sw.WriteLine(result[i]);
        }

        int Move(int index, bool add, bool isUpper)
        {
            int x = arr[index - 1];
            int value = 0;

            if (isUpper)
            {
                value += Query(x + 1, n); // 나보다 큰값
            }
            else
            {
                value += Query(1, x - 1); // 나보다 작은값
            }

            Update(x, add);

            return add ? value : -value;
        }

        // LSB: 최하위비트 가장 오른쪽의 1. x&-x을 하면 남는다.
        // 0010 1110 -x = 비트반전후 +1

        void Update(int x, bool add)
        {
            while (x <= n)
            {
                tree[x] += add ? 1 : -1;
                x += x & -x; // LSB 반복 업뎃으로 1을 왼쪽 밀면서 업뎃.
            }
        }

        int Sum(int x)
        {
            int value = 0;
            while (x > 0)
            {
                value += tree[x];
                x -= x & -x; // LSB을 1개씩 POP하면서 1~x까지의 업데이트를 전부 가져오기.
            }
            return value;
        }

        // left~right 의 값은 누적합처럼 구하면 된다. 1~right에서 left미만값은 제외해서 left~right
        int Query(int left, int right)
        {
            return Sum(right) - Sum(left - 1);
        }
    }
}