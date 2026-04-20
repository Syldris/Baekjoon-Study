#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int sqrtN = (int)Math.Sqrt(n);
        int bucketSize = (n / sqrtN) + 1;

        List<(int start, int end, int index)>[] bucket = new List<(int start, int end, int index)>[bucketSize];
        for (int i = 0; i < bucketSize; i++)
            bucket[i] = new();

        const int Range = 100000;
        long[] tree = new long[Range + 1];

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int m = int.Parse(sr.ReadLine());

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            // 시작점 기준으로 버킷을 잡음.
            // 끝점은 단조 증가/감소 함으로 버킷당 N만큼 버킷은 SqrtN개 있음.으로 NSqrtN
            // 시작점도 움직이는 범위가 SqrtN번이내로 쿼리마다 SqrtN이니 MSqrtN

            bucket[line[0] / sqrtN].Add((line[0], line[1], i));
        }

        // 지그재그 방식으로 움직임 최소화하게끔 끝점 정렬.
        for (int i = 0; i < bucketSize; i++)
        {
            if (i % 2 == 0) // 끝점 단조증가
                bucket[i].Sort((a, b) => a.end.CompareTo(b.end));

            else // 끝점 단조 감소
                bucket[i].Sort((a, b) => b.end.CompareTo(a.end));
        }
        long[] result = new long[m];

        int left = 1;
        int right = 1;
        long value = 0;

        Move(1, true); // 1~1 상태로 시작하니 1 적용하고 시작.

        for (int i = 0; i < bucketSize; i++)
        {
            foreach ((int start, int end, int index) in bucket[i])
            {
                while (left > start) // start <-- left 으로 확장.
                {
                    left--;
                    Move(left, true);
                }
                while (right < end) // right --> end 으로 확장.
                {
                    right++;
                    Move(right, true);
                }
                while (left < start) // left --> start 으로 축소
                {
                    Move(left, false);
                    left++;
                }
                while (right > end) // end <-- right 으로 축소.
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
                // x-k~ x+k 까지의 수 찾기.
                int left = Math.Max(x - k, 1); // left가 음수가 되지않게 1~ 을 보장.
                int right = Math.Min(x + k, Range);// right가 최대 범위 넘지않게 ~100000 을 보장 (세그 범위 초과 방지)

                value += Query(left, right);
                Update(x, true); // 자기 자신은 계산하면 안되니 계산후 추가.
            }
            else
            {
                // 제거 할때도 본인 주변 수 갯수 찾아서 쌍의 갯수 제거.
                Update(x, false); // 자기 자신은 계산하면 안되니 먼저 제거.

                int left = Math.Max(x - k, 1);
                int right = Math.Min(x + k, Range);

                value -= Query(left, right);
            }
        }

        /* 펜윅트리.
         가장 오른쪽에 있는 1을 정보로 사용.
         1100 같은경우 1'1'00 은 1001 1010 1100 등의 정보를 가지고있음.

         x & -x 는 항상 가장 오른쪽 이진수 1을 가르킨다.
         0110 일때  뒤집으면 1001 그리고 +1로 1010
         +1하는 이유는 0000 = 0 이지만 1111 = -1 부터 시작하기에.
         0010 이면 2지만 1101 은 -3상태인것이다. 그러므로 -2는 1110 인것.
         
         다시 돌아와서 가장 오른쪽에있는 1을 기준으로 왼쪽은 뒤집혀서 0과 1이 서로 반대이므로 & 성립X
         가장 오른쪽 1의 오른쪽은 처음상태일때 00상태. 뒤집히면서 11 이 되고 다시 +1로 00 이되며 0&0.
         가장 오른쪽 1은 시작시 1 뒤집히면서 0이되지만 오른쪽에 1111상태에서 +1을 받으며 다시 1이되어 1&1로 혼자 유효.
        */

        /* 업데이트 시에는
         01001 같은경우 가장 오른쪽 1이 1이므로 LSB 는 1이며
        더해주면서 01001 => 01010 => 01100 => 10000
        항상 가장 오른쪽에 있는 1을 더해주면서 정보를 저장한다.
        이렇게 하면 가장 오른쪽에 있는 1은 자신보다 오른쪽에 있는 정보를 모두 흡수한상태.
        나중에 10100 같은경우 
        10'1'00 은 10001~10100 까지 업데이트 '1'0100 은 00001 부터 10000까지 업데이트 흡수. 
        10001~ 이상은 LSB업데이트하며 11000 등으로 넘어가져
        100000 에서 담당하니 10000이랑은 겹침X
         */
        void Update(int index, bool add)
        {
            while (index <= Range)
            {
                tree[index] += add ? 1 : -1;
                index += index & -index; // LSB 업데이트. 
            }
        }

        /* 반대로 쿼리시에는 가장 오른쪽에 있는 1부터 pop하면서
           10100 같은경우 위와 적은대로 업데이트 내역을 가장 오른쪽 1이 정보담음.
           
         가장 오른쪽 1이 LSB인데 LSB 을 연속으로 빼면서 오른쪽부터 왼쪽으로 차곡차곡 비트를 끄면서 합을 누적 계산한다.
        */
        long Sum(int index)
        {
            long value = 0;
            while (index > 0)
            {
                value += tree[index];
                index -= index & -index; // LSB 업데이트.
            }
            return value;
        }

        /* 펜윅트리 특성상 22 같은거 주면 모든 1을 POP하면서 
         1~22 까지의 업데이트 내역을 전부 가져오니 누적합처럼
        ai ~ bi는 bi - (a[i-1])로 해결 가능
        */

        long Query(int left, int right)
        {
            if (left == 1) // sum = 0은 무한루프되니 주의.
                return Sum(right);

            long value = Sum(right) - Sum(left - 1);
            return value;
        }
    }
}