#nullable disable
public class Node
{
    public Node left;
    public Node right;
    public int value;
}

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        Node root = new Node();

        const long min = 0;
        const long max = long.MaxValue >> 2;

        long[] arr = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), long.Parse);
        for (int i = 0; i < n; i++)
        {
            Update(root, min, max, arr[i], true);
        }

        for (int i = 0; i < m; i++)
        {
            string[] line = sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            int query = int.Parse(line[0]);

            if (query == 1)
            {
                int pos = int.Parse(line[1]) - 1;
                int value = int.Parse(line[2]);

                Update(root, min, max, arr[pos], false);
                arr[pos] += value;
                Update(root, min, max, arr[pos], true);
            }
            else if (query == 2)
            {
                int pos = int.Parse(line[1]) - 1;
                int value = int.Parse(line[2]);

                Update(root, min, max, arr[pos], false);
                arr[pos] -= value;
                Update(root, min, max, arr[pos], true);
            }
            else if (query == 3)
            {
                long left = long.Parse(line[1]);
                long right = long.Parse(line[2]);
                sw.WriteLine(Query(root, min, max, left, right));
            }
            else
            {
                int other = int.Parse(line[1]);
                other = n + 1 - other; // N번째로 큰수 => N번째로 작은 수 변환 ex) 5개수중 2번쨰로 큰수는 4번째로 작은 수

                sw.WriteLine(OtherQuery(root, min, max, other));
            }
        }

        void Update(Node node, long start, long end, long index, bool add)
        {
            if (start == end)
            {
                node.value += add ? 1 : -1;
                return;
            }

            long mid = (start + end) / 2;

            if (index <= mid)
            {
                node.left ??= new Node();
                Update(node.left, start, mid, index, add);

                //if (node.left == null)
                //    node.left = new Node();
            }
            else
            {
                node.right ??= new Node();
                Update(node.right, mid + 1, end, index, add);

                //if (node.right == null)
                //    node.right = new Node();
            }

            node.value = (node.left?.value ?? 0) + (node.right?.value ?? 0); // ?? 연산순위에 주의.

            //if (node.left != null)
            //    node.value += node.left.value;
            //if(node.right != null)
            //    node.value += node.right.value;
        }

        int Query(Node node, long start, long end, long left, long right)
        {
            if (node == null)
                return 0;
            if (start > right || end < left)
            {
                return 0;
            }

            if (left <= start && end <= right)
            {
                return node.value;
            }

            long mid = (start + end) / 2;

            return Query(node.left, start, mid, left, right) + Query(node.right, mid + 1, end, left, right);
        }

        long OtherQuery(Node node, long start, long end, int other)
        {
            if (start == end)
            {
                return start;
            }

            long mid = (start + end) / 2;

            if (node.left != null && node.left.value >= other)
            {
                return OtherQuery(node.left, start, mid, other);
            }
            else
            {
                return OtherQuery(node.right, mid + 1, end, other - (node.left?.value ?? 0));
            }
        }
    }
}