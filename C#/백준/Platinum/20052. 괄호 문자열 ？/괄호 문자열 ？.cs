#nullable disable
public struct Node
{
    public int value; // 총합값
    public int min; // 이 구간의 최소 min

    public Node(int value, int min)
    {
        this.value = value;
        this.min = min;
    }

    public static Node operator +(Node left, Node right)
    {
        // 구간을 병합했을때 총합값은 왼쪽+오른쪽, 구간에서 최솟값은 왼쪽MIN 혹은 오른쪽은 반드시 왼쪽을 고려해서 붙이기. 
        return new Node(left.value + right.value, Math.Min(left.min, left.value + right.min));
    }

}

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string text = sr.ReadLine();

        int range = text.Length;
        Node[] tree = new Node[range * 4];

        int m = int.Parse(sr.ReadLine());

        Build(1, 1, range);

        int result = 0;

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            // A~B 까지 총합값과 최솟값을 조사
            Node node = Query(1, 1, range, line[0], line[1]);

            if (node.value == 0 && node.min >= 0) // 괄호 열고닫고 총합은 0이여야하고 구간내 시작~ 일정부분에서 ) 더많이나온적이 없을때만
            {
                result++;
            }
        }

        sw.Write(result);

        void Build(int node, int start, int end)
        {
            if (start == end)
            {
                if (text[start - 1] == '(') // 열떈 +1 Min도 +1
                {
                    tree[node] = new Node(1, 1);
                }
                else // ( 일때는 구간 총합 -1 Min도 -1
                {
                    tree[node] = new Node(-1, -1);
                }
                return;
            }

            int mid = (start + end) >> 1;

            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);

            // 병합시에 Min은 왼쪽의 Min 혹은 오른쪽Min + 왼쪽 Value포함. 오른쪽에선 음수여도 왼쪽이 + 이면 상쇄가능. 왼쪽에서 -는 상쇄불가.
            tree[node] = tree[node << 1] + tree[(node << 1) + 1];
        }

        Node Query(int node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return new Node(int.MaxValue, int.MaxValue);

            if (left <= start && end <= right)
                return tree[node];

            int mid = (start + end) >> 1;

            Node leftQuery = Query(node << 1, start, mid, left, right);
            Node rightQuery = Query((node << 1) + 1, mid + 1, end, left, right);

            if (leftQuery.value == int.MaxValue)
                return rightQuery;

            else if (rightQuery.value == int.MaxValue)
                return leftQuery;

            else
                return leftQuery + rightQuery;
        }
    }
}