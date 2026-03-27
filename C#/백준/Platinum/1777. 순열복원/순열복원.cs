#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);
        int[] tree = new int[n * 4];

        int[] result = new int[n];

        for (int i = n; i > 0; i--)// 작은수의 갯수가 기록된거니 큰수부터 차례대로 자리를 채움
        {
            // 큰수부터 순열 뒷쪽에 채우면서 시작.
            KthUpdate(1, 1, n, arr[i - 1], i); // 이후에 나올 작은수의 갯수만큼 자리를 비워두기.
        }

        sw.Write(string.Join(' ', result));

        void KthUpdate(int node, int start, int end, int order, int value)
        {
            if (start == end)
            {
                int index = n - start; // 순열은 뒤에서부터 채운다. 1~8 start end를 n에서 빼서 인덱스 맞추기
                result[index] = value;
                tree[node] = 1; // 1로 기록해서 1칸 썻음을 알림.
                return;
            }

            int mid = (start + end) >> 1;

            int leftEntpySize = (mid - start + 1) - tree[node << 1]; // 왼쪽공간중에서 사용한 공간만큼 빼고 빈공칸체크.

            if (order >= leftEntpySize) // order가 0번째가 되게끔 자리를 비우는것이니 >=
            {
                KthUpdate((node << 1) + 1, mid + 1, end, order - leftEntpySize, value);
            }
            else
            {
                KthUpdate(node << 1, start, mid, order, value);
            }

            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }
    }
}