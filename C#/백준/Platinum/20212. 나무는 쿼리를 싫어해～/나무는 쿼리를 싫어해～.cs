#nullable disable
public class Node
{
    public Node left;
    public Node right;

    public long value;
    public long lazy;
}

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        List<(int start, int end, int value)> query1 = new();
        List<(int order, int left, int right, int input)> query2= new();

        const int min = 1;
        const int max = 1000000000;

        int rank = 0;

        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            if (line[0] == 1)
            {
                query1.Add((line[1], line[2], line[3]));
            }
            else
            {
                query2.Add((line[3], line[1], line[2], rank++));
            }
        }

        query2.Sort();
        Node root = new Node();

        long[] result = new long[rank]; 

        int index = 0;
        foreach ((int order, int left, int right, int input) in query2)
        {
            while (order > index)
            {
                (int start, int end, int value) = query1[index++];
                Update(root, min, max, start, end, value);
            }
            result[input] = Query(root, min, max, left, right);
        }

        for (int i = 0; i < rank; i++)
        {
            sw.WriteLine(result[i]);
        }

        void Update(Node node, int start, int end, int left, int right, long value)
        {
            if (start > right || end < left)
                return;

            if (left <= start && end <= right)
            {
                int range = (end - start) + 1;

                node.value += range * value;
                node.lazy += value;
                return;
            }

            int mid = (start + end) / 2;

            node.left ??= new Node();
            node.right ??= new Node();

            Push(node, start, end);

            Update(node.left, start, mid, left, right, value);
            Update(node.right, mid + 1, end, left, right, value);

            node.value = node.left.value + node.right.value;
        }

        long Query(Node node, int start, int end, int left, int right)
        {
            if(node == null) return 0;

            if (start > right || end < left)
                return 0;

            if (left <= start && end <= right)
            {
                return node.value;
            }

            int mid = (start + end) / 2;
            Push(node, start, end);

            return Query(node.left, start, mid, left, right) + Query(node.right, mid + 1, end, left, right);
        }

        void Push(Node node, int start, int end)
        {
            if (node.lazy == 0) return;

            int mid = (start + end) / 2;

            int leftRange = (mid - start) + 1;
            int rightRange = (end - (mid + 1)) + 1;

            node.left ??= new Node();
            node.right ??= new Node();

            node.left.value += node.lazy * leftRange;
            node.right.value += node.lazy * rightRange;

            node.left.lazy += node.lazy;
            node.right.lazy += node.lazy;

            node.lazy = 0;
        }
    }
}