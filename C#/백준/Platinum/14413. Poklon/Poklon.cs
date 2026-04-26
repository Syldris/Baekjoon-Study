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

        int[] arrIndex = new int[n];
        for (int i = 0; i < n; i++)
            arrIndex[i] = i;

        // 0 ~ n-1 까지 arr를 기준 정렬
        Array.Sort(arrIndex, (a, b) => arr[a].CompareTo(arr[b]));

        int rank = 0;
        int prev = 0;
        for (int i = 0; i < n; i++)
        {
            int index = arrIndex[i];
            if (arr[index] > prev) // 이전 수랑 비교해서 클때만 rank증가
                rank++;

            arr[index] = rank;
            prev = arr[index];
        }


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

        int[] count = new int[500001]; // x가 나온 횟수.
        int[] freg = new int[500001]; // A번 나온 수의 종류.

        int left = 1;
        int right = 1;

        Move(1, true); // 1~1 시작.

        for (int i = 0; i < bucketSize; i++)
        {
            foreach ((int start, int end, int index) in bucket[i])
            {
                while (left > start) // start <- left 확장
                {
                    left--; // 확장시에는 이동후 값 추가
                    Move(left, true);
                }
                while (right < end) // right -> end 확장
                {
                    right++;
                    Move(right, true);
                }
                while (left < start) // left -> start 축소
                {
                    Move(left, false);
                    left++; // 축소시에는 먼저 범위에서 값 제거후 이동
                }
                while (right > end) // end <- right 축소
                {
                    Move(right, false);
                    right--;
                }
                result[index] = freg[2]; // 2번 나온수의 종류.
            }
        }

        for (int i = 0; i < m; i++)
        {
            sw.WriteLine(result[i]);
        }

        void Move(int index, bool add)
        {
            int x = arr[index - 1];

            if (add)
            {
                freg[count[x]]--; // A번 종류에 x가 제거
                count[x]++; // x횟수 1번 제거
                freg[count[x]]++; // A+1번 종류에 x가 추가
            }
            else
            {
                freg[count[x]]--; // A번 종류에 x가 제거
                count[x]--; // x횟수 1번 제거 
                freg[count[x]]++; // A-1번 종류에 x가 추가
            }
        }
    }
}