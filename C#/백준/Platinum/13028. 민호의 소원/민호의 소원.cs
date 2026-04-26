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

        int[] count = new int[100001]; // x가 나온 횟수.

        int value = 0; // 3번 이상 등장하는 수의 종류.

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
                result[index] = value;
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
                count[x]++; // x횟수 1번 추가

                if (count[x] == 3) // 3번 이상 등장했으니 종류 +1
                    value++;

            }
            else
            {
                if (count[x] == 3) // 3번 등장한 수가 제거 되니 종류-1
                    value--;

                count[x]--; // x횟수 1번 제거 
            }
        }
    }
}