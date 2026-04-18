#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int c = int.Parse(input[1]);

        int logN = (int)Math.Sqrt(n);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int m = int.Parse(sr.ReadLine());

        int bucketsize = (n / logN) + 1;
        List<(int index, int start, int end)>[] bucket = new List<(int, int, int)>[bucketsize];

        for (int i = 0; i < bucketsize; i++)
        {
            bucket[i] = new();
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            // 끝점이 단조 증가 or 감소되게끔 정렬하면 버킷 1개당 N 버킷은 SqrtN개니 끝점 NSqrtN
            // 시작점은 버킷범위안이므로 최대 SqrtN번만 움직임. 쿼리 갯수 M개일때 MSqrtN
            // 고로 시작점 M SqrtN + 끝점 N SqrtN + 정렬 NlogN 이다.

            int start = line[0];
            int end = line[1];

            bucket[start / logN].Add((i, start, end)); // 시작점을 SqrtN으로 나눠서 버킷안에다 담음.
        }

        for (int i = 0; i < bucketsize; i++)
        {
            if (i % 2 == 0)
                bucket[i].Sort((a, b) => a.end.CompareTo(b.end)); // 끝점 기준 오름차순 (단조 증가)
            else
                bucket[i].Sort((a, b) => b.end.CompareTo(a.end)); // 내림차순. (단조 감소)
        }

        int[] result = new int[m];

        int left = 1;
        int right = 1;

        int[] count = new int[c + 1];

        Move(1, true);

        for (int i = 0; i < bucketsize; i++)
        {
            foreach ((int index, int start, int end) in bucket[i])
            {
                int len = end - start + 1;

                while (right < end) // right => end 확장
                {
                    right++;
                    Move(right, true);
                }

                while (right > end) // end <= right 축소
                {
                    Move(right, false);
                    right--;
                }

                while (left > start) // start <= left 확장
                {
                    left--;
                    Move(left, true);
                }

                while (left < start) // left => start 축소
                {
                    Move(left, false);
                    left++;
                }


                int value = -1;
                for (int k = 1; k <= c; k++)
                {
                    if (count[k] * 2 > len)
                    {
                        value = k;
                        break;
                    }
                }

                result[index] = value;
            }
        }

        void Move(int index, bool add)
        {
            int number = arr[index - 1]; // 1index => 0index

            if (add)
                count[number]++;
            else
                count[number]--;
        }


        for (int i = 0; i < m; i++)
        {
            if (result[i] != -1)
                sw.WriteLine($"yes {result[i]}");
            else
                sw.WriteLine("no");
        }
    }
}