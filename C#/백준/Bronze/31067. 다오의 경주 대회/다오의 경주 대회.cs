#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int k = int.Parse(input[1]);

        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int result = 0;

        for (int i = 1; i < n; i++)
        {
            if (arr[i] <= arr[i - 1])
            {
                if (arr[i] + k > arr[i - 1])
                {
                    arr[i] += k;
                    result++;
                }
                else
                {
                    sw.Write(-1);
                    return;
                }
                    
            }
        }
        sw.Write(result);
    }
}