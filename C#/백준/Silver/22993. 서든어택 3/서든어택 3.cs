#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        long curPower = arr[0];

        arr[0] = 0; // 0으로 만들기
        Array.Sort(arr);

        for (int i = 1; i < n; i++)
        {
            if (curPower > arr[i])
            {
                curPower += arr[i];
            }
            else
            {
                sw.Write("No");
                return;
            }
        }

        sw.Write("Yes");
    }
}