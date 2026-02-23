#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int sqrtN = (int)Math.Sqrt(n);

        int bucketCount = n / sqrtN + 1; // 7인 경우 (7/2)+1 로 2size 4개
        List<(int start, int end, int index)>[] bucket = new List<(int start, int end, int index)>[bucketCount];
        for (int i = 0; i < bucketCount; i++)
            bucket[i] = new();

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int m = int.Parse(sr.ReadLine());

        (int start, int end, int index)[] query = new (int start, int end, int index)[m];
        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            query[i] = (line[0] - 1, line[1] - 1, i); // 1Index => 0Index 로 변환
        }

        for (int i = 0; i < m; i++)
        {
            int pos = query[i].start / sqrtN; // start 기반으로 버킷에 담기. 이로써 start가 움직여도 최대 SqrtN번 움직인다.
            bucket[pos].Add(query[i]);
        }

        for (int i = 0; i < bucketCount; i++)
        {
            bucket[i].Sort((a, b) => a.end.CompareTo(b.end)); //// 버킷안에선 끝점이 단조증가 하도록 정렬한 쿼리를 버킷안에 담음.
        }

        int[] result = new int[m];

        int[] count = new int[1000001]; // 숫자의 갯수
        count[arr[0]] = 1; // 범위 0..0 으로 시작하니 시작점 수는 1개있게 카운팅 해주자.
        int currentStart = 0, currentEnd = 0;
        int value = 1;

        for (int t = 0; t < bucketCount; t++)
        {
            foreach ((int start, int end, int index) in bucket[t])
            {
                while (currentEnd < end) // end가 버킷내에서 단조증가 되게끔
                {
                    currentEnd++; // 확장할땐 이동하고 추가함
                    if (count[arr[currentEnd]] == 0) value++; // count[숫자] = 0 이면 새로운 수를 추가하니 다른 수 +1
                    count[arr[currentEnd]]++; // 범위를 확장했으니 count[현재수] = 갯수 +1
                }

                while (currentEnd > end) // 현재 끝점이 end보다 크면 end를 줄이면서 범위가 축소됨 (버킷이 달라질때 end점 단조깨져서 O(N)만큼 움직여야함)
                {
                    count[arr[currentEnd]]--; // 범위를 좁혔으니 숫자 카운팅 -1
                    if (count[arr[currentEnd]] == 0) value--; // 숫자를 줄여봤을때 0 이면 서로다른수가 -1
                    currentEnd--; // 제거할땐 순서상 제거하고 이동해야함
                }

                while (currentStart > start) // 현재 시작점이 start 보다 크면 줄이면서 start 쪽으로 범위를 확장하기
                {
                    currentStart--; // 확장할땐 이동하고 추가함
                    if (count[arr[currentStart]] == 0) value++;
                    count[arr[currentStart]]++;
                }

                while (currentStart < start) // 현재 시작점이 start 보다 작으면 start로 이동하면서 범위가 좁혀짐
                {
                    count[arr[currentStart]]--; // 범위를 좁혔으니 숫자 카운팅 -1
                    if (count[arr[currentStart]] == 0) value--; // 숫자를 줄여봤을때 0 이면 서로다른수가 -1
                    currentStart++; // 제거할땐 순서상 제거하고 이동해야함
                }

                result[index] = value;
            }
        }

        for (int i = 0; i < m; i++)
        {
            sw.WriteLine(result[i]);
        }
    }
}