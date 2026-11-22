#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());

        int[] arr = new int[n];

        string[] text = sr.ReadLine().Split();

        List<(int move, int index, bool enabled)> list = new();
        for (int i = 0; i < n; i++)
            list.Add((int.Parse(text[i]), i, true));

        int order = 0;

        for (int i = 0; i < n; i++)
        {
            arr[i] = list[order].index + 1;

            list[order] = (list[order].move, list[order].index, false); // 비활성화

            int move = list[order].move;

            if (i == n - 1) break; // 마지막 루프는 바로끝냄.

            while (move != 0)
            {
                if (move > 0) // 오른쪽으로 이동
                {
                    order++;

                    if (order >= n) order -= n;

                    if (list[order].enabled)
                        move--;
                }
                else // 왼쪽으로 이동
                {
                    order--;

                    if (order < 0) order += n;

                    if (list[order].enabled)
                        move++;
                }
            }
        }

        sw.Write(String.Join(' ', arr));
    }
}