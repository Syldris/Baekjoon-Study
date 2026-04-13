#nullable disable
public struct Node
{
    public int open;
    public int close;

    public Node(int open, int close)
    {
        this.open = open;
        this.close = close;
    }

    public static Node Merge(Node leftNode, Node rightNode)
    {
        /* 왼쪽의 ( 와 오른쪽의 ) 만 합칠 수 있다. 
        
        왼쪽노드의 ) 는 적어도 ()) 등으로 한번이상 병합할 기회가 있었는데
        (가 부족해서 못해서 왼쪽에서 처리못한것. 그러므로 왼쪽에서 처리불가.
        오른쪽노드에서는 왼쪽노드의 )를 처리할수 없다. ex: )( 이런식으로 처리불가능.
        
        위와같이 오른쪽의 (는 오른쪽노드에서 해결하지 못함을 이미 증명하고 왔으며
        왼쪽에선 오른쪽노드의 (를 지울방법이 없다. ex: )( 이런식으로 처리불가능. */
        int matchNode = Math.Min(leftNode.open, rightNode.close); // 매치된 노드수는 open (((2개)) close 최소갯수로 매치가능

        return new Node(leftNode.open + rightNode.open - matchNode, leftNode.close + rightNode.close - matchNode);
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
        int result = 0;

        Build(1, 1, range);

        for (int i = 0; i < m; i++)
        {
            int index = int.Parse(sr.ReadLine());

            Update(1, 1, range, index);

            // 리프노드에선 전부 매칭되고 ) ) 같이 남는노드는 존재하지안아야함.
            if (tree[1].open == 0 && tree[1].close == 0)
            {
                result++;
            }
        }

        sw.Write(result);

        void Build(int node, int start, int end)
        {
            if (start == end)
            {
                if (text[start - 1] == '(')
                {
                    tree[node] = new Node(1, 0);
                }
                else
                {
                    tree[node] = new Node(0, 1);
                }
                return;
            }

            int mid = (start + end) >> 1;

            Build(node << 1, start, mid);
            Build((node << 1) + 1, mid + 1, end);

            tree[node] = Node.Merge(tree[node << 1], tree[(node << 1) + 1]);
        }

        void Update(int node, int start, int end, int index)
        {
            if (start == end) // 리프노드
            {
                if (tree[node].open == 1) // 닫기
                {
                    tree[node].open = 0;
                    tree[node].close = 1;
                }
                else // close = 1 로 닫혀있으면 열기
                {
                    tree[node].open = 1;
                    tree[node].close = 0;
                }
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

            tree[node] = Node.Merge(tree[node << 1], tree[(node << 1) + 1]);
        }
    }
}