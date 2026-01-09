#nullable disable
class Program
{
    struct Node
    {
        public int value;
        public int left = 0;
        public int right = 0;

        public Node(int value)
        {
            this.value = value;
        }
    }

    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int first = int.Parse(sr.ReadLine());
        Node[] tree = new Node[10001];
        tree[0] = new Node(first);
        int count = 1;

        while (true)
        {
            string input = sr.ReadLine();
            if (input == null) break;

            int value = int.Parse(input);
            Insert(0, value);
        }

        DFS(tree[0]);

        void Insert(int index, int value)
        {
            if (value < tree[index].value)
            {
                if (tree[index].left != 0)
                    Insert(tree[index].left, value);

                else
                {
                    tree[index].left = count;
                    tree[count++] = new Node(value);
                }
            }
            else
            {
                if (tree[index].right != 0)
                    Insert(tree[index].right, value);

                else
                {
                    tree[index].right = count;
                    tree[count++] = new Node(value);
                }
            }
        }

        void DFS(Node node)
        {
            if (node.left != 0) DFS(tree[node.left]);
            if (node.right != 0) DFS(tree[node.right]);

            sw.WriteLine(node.value);
        }
    }
}