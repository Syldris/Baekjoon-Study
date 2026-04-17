#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int n = int.Parse(sr.ReadLine());
        int sqrtN = (int)Math.Sqrt(n);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int m = int.Parse(sr.ReadLine());

        int bucketsize = (n / sqrtN) + 1;
        List<(int index, int start, int end)>[] bucket = new List<(int, int, int)>[bucketsize];

        for (int i = 0; i < bucketsize; i++)
        {
            bucket[i] = new();
        }

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            // 끝점이 단조 증가 or 감소되게끔 정렬하면 버킷 1개당 N 버킷은 logN개니 끝점 NlogN
            // 시작점은 버킷범위안이므로 최대 logN번만 움직임. 쿼리 갯수 M개일때 MlogN
            // 고로 시작점 MlogN + 끝점 NlogN + 정렬 NlogN 이다.

            int start = line[0];
            int end = line[1];

            bucket[start / sqrtN].Add((i, start, end)); // 시작점을 logN으로 나눠서 버킷안에다 담음.
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

        int max = 0;

        int[] count = new int[100001]; // x가 몇개있는지.
        int[] freq = new int[100001]; // A개 있는수가 몇종류인지.

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

                while (left > start) // start <= left 확장
                {
                    left--;
                    Move(left, true);
                }

                while (right > end) // end <= right 축소
                {
                    Move(right, false);
                    right--;
                }

                while (left < start) // left => start 축소
                {
                    Move(left, false);
                    left++;
                }

                result[index] = max;
            }
        }

        void Move(int index, bool add)
        {
            int number = arr[index - 1]; // 1index => 0index

            if (add)
            {
                freq[count[number]]--; // x개 있는수 종류 -1

                count[number]++;

                freq[count[number]]++; // x+1개 있는 수 종류 +1

                if (count[number] > max) // 최빈수 갱신
                    max = count[number];
            }
            else
            {
                freq[count[number]]--; // x개 있는수 종류 -1

                count[number]--;

                freq[count[number]]++; // x-1개 있는 수 종류 +1

                if (freq[max] == 0)
                    max--;
            }
        }

        for (int i = 0; i < m; i++)
        {
            sw.WriteLine(result[i]);
        }
    }
}