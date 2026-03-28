#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        const int OFFSET = 1000000001; // 1부터 시작하게끔 보정값.

        int n = int.Parse(sr.ReadLine());
        int[] completeQuest = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        List<int> list = new List<int>(n);

        for (int i = 0; i < n; i++)
        {
            completeQuest[i] += OFFSET;
            list.Add(completeQuest[i]); // 완료한 퀘스트
        }

        int m = int.Parse(sr.ReadLine());
        (int mod, int a, int b)[] query = new (int, int, int)[m];

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int mod = line[0];

            if (mod == 1)
            {
                line[1] += OFFSET;

                query[i] = (mod, line[1], 0);
                list.Add(line[1]);
            }
            else
            {
                line[1] += OFFSET;
                line[2] += OFFSET;

                query[i] = (mod, line[1], line[2]);
                list.Add(line[1]);
                list.Add(line[2]);
            }
        }

        List<int> sorted = list.Distinct().ToList();
        sorted.Sort();

        int rank = 0;
        Dictionary<int, int> dict = new Dictionary<int, int>(sorted.Count);
        for (int i = 0; i < sorted.Count; i++)
        {
            dict[sorted[i]] = ++rank; // 값 = 순서 좌표압축.
        }

        int[] tree = new int[rank * 4];

        for (int i = 0; i < n; i++)
        {
            int questNum = dict[completeQuest[i]]; // 미리 완료한 퀘스트 등록.
            Update(1, 1, rank, questNum);
        }

        for (int i = 0; i < m; i++)
        {
            (int mod, int a, int b) = query[i];

            if (mod == 1)
            {
                Update(1, 1, rank, dict[a]); // a번 퀘스트 완료.
            }
            else
            {
                sw.WriteLine((b - a + 1) - Query(1, 1, rank, dict[a], dict[b])); // a번부터 b번까지 미완성 퀘스트 갯수 출력. 전체범위중 완료한만큼 빼면 된다.
            }
        }

        void Update(int node, int start, int end, int index)
        {
            if (start == end)
            {
                tree[node] = 1; // 퀘스트 완료.
                return;
            }

            int mid = (start + end) >> 1;

            if (index <= mid)
            {
                Update(node << 1, start, mid, index);
            }
            else
            {
                Update((node << 1) + 1, mid + 1, end, index);
            }

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        int Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) >> 1;

            return Query(node << 1, start, mid, left, right) + Query((node << 1) + 1, mid + 1, end, left, right);
        }
    }
}