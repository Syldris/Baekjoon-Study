#nullable disable
public class Node
{
    public Node leftNode;
    public Node rightNode;

    public int value;
    public int lazy;

    public Node(int value)
    {
        this.value = value;
    }
}

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int m = int.Parse(sr.ReadLine());

        int c = 0;
        Node root = new Node(0);
        const int Range = 1000000000;

        for (int i = 0; i < m; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);

            int left = line[1] + c;
            int right = line[2] + c;

            if (line[0] == 1)
            {
                c = Query(root, 1, Range, left, right);
                sw.WriteLine(c);
            }
            else
            {
                Update(root, 1, Range, left, right);
            }
        }

        void Update(Node node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return;

            if (left <= start && end <= right)
            {
                node.value = end - start + 1;
                node.lazy = 1;
                return;
            }

            node.leftNode ??= new Node(0);
            node.rightNode ??= new Node(0);

            Push(node, start, end);

            int mid = (start + end) >> 1;

            Update(node.leftNode, start, mid, left, right);
            Update(node.rightNode, mid + 1, end, left, right);

            node.value = node.leftNode.value + node.rightNode.value;
        }

        int Query(Node node, int start, int end, int left, int right)
        {
            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
                return node.value;

            node.leftNode ??= new Node(0);
            node.rightNode ??= new Node(0);

            Push(node, start, end);

            int mid = (start + end) >> 1;

            return Query(node.leftNode, start, mid, left, right) + Query(node.rightNode, mid + 1, end, left, right);
        }

        void Push(Node node, int start, int end)
        {
            if (node.lazy == 0) return;

            int mid = (start + end) >> 1;
            int leftValue = (mid - start + 1) * node.lazy;
            int rightValue = (end - mid) * node.lazy;

            if (node.leftNode == null)
                node.leftNode = new Node(leftValue); // left 없으면 생성
            else
                node.leftNode.value = leftValue;

            if (node.rightNode == null)
                node.rightNode = new Node(rightValue); // right 없으면 생성
            else
                node.rightNode.value = rightValue;

            node.leftNode.lazy = node.lazy;
            node.rightNode.lazy = node.lazy;

            node.lazy = 0;
        }
    }
}