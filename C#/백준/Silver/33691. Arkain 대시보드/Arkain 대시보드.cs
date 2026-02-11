#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 18);

        int n = int.Parse(sr.ReadLine());
        string[] arr = new string[n];
        for (int i = 0; i < n; i++)
        {
            arr[i] = sr.ReadLine();
        }

        int k = int.Parse(sr.ReadLine());
        HashSet<string> pinned = new HashSet<string>();
        HashSet<string> dashBoard = new HashSet<string>();

        for (int i = 0; i < k; i++)
        {
            pinned.Add(sr.ReadLine()); 
        }

        for (int i = n - 1; i >= 0; i--)
        {
            if (pinned.Contains(arr[i]) && !dashBoard.Contains(arr[i]))
            {
                sw.WriteLine(arr[i]);
                dashBoard.Add(arr[i]);
            }
        }

        for (int i = n - 1; i >= 0; i--)
        {
            if (!dashBoard.Contains(arr[i]))
            {
                sw.WriteLine(arr[i]);
                dashBoard.Add(arr[i]);
            }
        }
    }
}