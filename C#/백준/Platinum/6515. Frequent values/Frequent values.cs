#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        while (true)
        {
            string text = sr.ReadLine();
            if (text == "0")
                break;

            string[] input = text.Split();
            int n = int.Parse(input[0]);
            int m = int.Parse(input[1]);

            int sqrtN = (int)Math.Sqrt(n);

            int[] arr = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += 100000; // -10만 ~ 10만을 0~20만 으로 
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

            int[] count = new int[200001]; // x가 나온 횟수.
            int[] freg = new int[200001]; // x번 나온 수의 종류.

            int left = 1;
            int right = 1;
            long max = 0;

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
                    result[index] = max;
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

                    if (count[x] > max) // max 갱신. 
                        max = count[x];
                }
                else
                {
                    freg[count[x]]--; // A번 종류에 x가 제거
                    count[x]--; // x횟수 1번 제거 
                    freg[count[x]]++; // A-1번 종류에 x가 추가

                    if (freg[max] == 0) // x 제거후 max번 남아있는 수가 0종류라면 max 다운.
                        max--;
                }
            }
        }
    }
}