#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        Stack<int>[] stacks = new Stack<int>[4];
        for (int i = 0; i < 4; i++)
        {
            stacks[i] = new Stack<int>();
            stacks[i].Push(0);
        }

        for (int i = 0; i < n; i++)
        {
            bool push = false;
            for (int j = 0; j < 4; j++)
            {
                if (stacks[j].Peek() <= arr[i])
                {
                    stacks[j].Push(arr[i]);
                    push = true;
                    break;
                }
            }
            if (!push)
            {
                sw.Write("NO");
                return;
            }
        }

        sw.Write("YES");
    }
}