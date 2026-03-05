#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries), int.Parse);

        Stack<int> stack = new Stack<int>(); // 오름차순 단조스택 1 3 7..

        long result = 0;

        for (int i = 0; i < n; i++)
        {
            while (stack.Count > 0 && arr[stack.Peek()] > arr[i])
            {
                int pop = stack.Pop();
                int left = stack.Count > 0 ? stack.Peek() + 1 : 0; // 이전에 나온 나보다 작은수는 미포함이니 경계선처리로 +1 
                int right = i - 1; // 나보다 작은수가 왔으니 여기 이전 범위까지 오른쪽범위 가능. 1 3 7 2 = 1 3 |7| 2  = 1 |3 x| 2

                long value = (long)(right - left + 1) * arr[pop]; // 범위 * 높이
                result = Math.Max(result, value);
            }
            stack.Push(i);
        }

        while (stack.Count > 0)
        {
            int pop = stack.Pop();
            int right = n - 1; // 끝까지 남아있다면 맨오른쪽까지 사각형을 만들수있음, 0-index이니 0 ~ n-1까지다.
            int left = stack.Count > 0 ? stack.Peek() + 1 : 0; // 만약 없다면 시작(0)부터 사각형을 만들수있음 

            long value = (long)(right - left + 1) * arr[pop];
            result = Math.Max(result, value);
        }

        sw.Write(result);
    }
}