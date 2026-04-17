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
        int bucketSize = (n / sqrtN) + 1;

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        long[] result = new long[m];

        List<(int start, int end, int index)>[] bucket = new List<(int, int, int)>[bucketSize + 1];
        for (int i = 0; i <= bucketSize; i++)
            bucket[i] = new();


        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int start = line[0];
            int end = line[1];

            bucket[start / sqrtN].Add((start, end, i)); // 시작점 기준 정렬
        }

        for (int i = 0; i <= bucketSize; i++)
        {
            if (i % 2 == 0) // 지그재그 정렬
                bucket[i].Sort((a, b) => a.end.CompareTo(b.end)); // 내림차순 1 2 3
            else
                bucket[i].Sort((a, b) => b.end.CompareTo(a.end)); // 오름차순 3 2 1
        }

        int[] count = new int[1000001]; // 1~100만

        int left = 1;
        int right = 1;
        long value = UpdateValue(1, true); // 1을 기본값으로.

        for (int i = 0; i <= bucketSize; i++)
        {
            foreach ((int start, int end, int index) in bucket[i])
            {
                while (left > start) // 시작점이 <=으로 가니 증가
                {
                    left--;
                    value += UpdateValue(left, true);
                }

                while (left < start) // 시작점을 =>으로 가니 감소
                {
                    value += UpdateValue(left, false);
                    left++;
                }

                while (right < end) // 끝점이 =>으로 가니 증가
                {
                    right++;
                    value += UpdateValue(right, true);
                }

                while (right > end) // 끝점이 <=으로 가니 감소
                {
                    value += UpdateValue(right, false);
                    right--;
                }

                result[index] = value;
            }
        }

        for (int i = 0; i < m; i++)
        {
            sw.WriteLine(result[i]);
        }

        long UpdateValue(int index, bool add)
        {
            int number = arr[index - 1]; // 1index => 0index
            long prevValue = (long)count[number] * count[number] * number;

            if (add)
                count[number]++;
            else
                count[number]--;

            long curValue = (long)count[number] * count[number] * number;
            return curValue - prevValue; // 현재 - 이전 으로 차이만큼 리턴
        }
    }
}