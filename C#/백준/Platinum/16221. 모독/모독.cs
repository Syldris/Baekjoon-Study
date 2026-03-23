#nullable disable
public struct Node
{
    public int value; // 노드에 있는 하수인의 총 갯수
    public bool isFull; // 왼쪽(1)으로부터 이어져있는지? 체력 1 2 3.. 으로 연속적으로 발동해야함

    public Node(int value, bool isFull)
    {
        this.value = value;
        this.isFull = isFull;
    }
}

class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int n = int.Parse(sr.ReadLine());

        int max = 1000000;
        Node[] tree = new Node[max * 4];

        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
            int value = line[0] == 1 ? 1 : -1;
            int index = line[1];

            Update(1, 1, max, index, value); // [체력] = 갯수, 1부터 이어지는지 여부(4, false)로 기록
            sw.WriteLine(Query(1, 1, max)); 
        }

        void Update(int node, int start, int end, int index, int value)
        {
            if (start == end)
            {
                tree[node].value += value;

                if (tree[node].value > 0)
                    tree[node].isFull = true;
                else
                    tree[node].isFull = false;

                return;
            }

            int mid = (start + end) >> 1;

            if (index <= mid)
            {
                Update(node << 1, start, mid, index, value);
            }
            else
            {
                Update((node << 1) + 1, mid + 1, end, index, value);
            }

            tree[node].value = tree[node << 1].value + tree[(node << 1) + 1].value;
            tree[node].isFull = tree[node << 1].isFull && tree[(node << 1) + 1].isFull; // 왼쪽 & 오른쪽 다 차있어야함
        }

        int Query(int node, int start, int end)
        {
            if (start == end)
            {
                return tree[node].isFull ? tree[node].value : 0; // 해당 노드 왔을떄 off인 경우 반환X
            }

            int mid = (start + end) >> 1;

            if (!tree[node << 1].isFull) // 왼쪽 자식 범위에서 1이 다 차있지 않은 경우.
            {
                return Query(node << 1, start, mid);
            }
            else // 왼쪽 자식이 연속되게 다 차있는 경우. 오른쪽 탐색
            {
                return Query((node << 1) + 1, mid + 1, end) + tree[node << 1].value; // 왼쪽노드 값은 전부 더해주고 가자.
            }
        }
    }
}