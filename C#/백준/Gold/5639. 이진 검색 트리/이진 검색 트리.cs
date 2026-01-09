#nullable disable
class Program
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;

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

        Node root = new Node(first);
        while (true)
        {
            string input = sr.ReadLine();
            if (input == null) break;

            int value = int.Parse(input);
            Insert(root, value);
        }

        DFS(root);

        void Insert(Node node, int value)
        {
            if (value < node.value)
            {
                if (node.left != null) 
                    Insert(node.left, value);

                else
                    node.left = new Node(value);
            }
            else
            {
                if (node.right != null)
                    Insert(node.right, value);

                else
                    node.right = new Node(value);
            }
        }

        void DFS(Node node)
        {
            if (node.left != null) DFS(node.left);
            if (node.right != null) DFS(node.right);

            sw.WriteLine(node.value);
        }
    }
}