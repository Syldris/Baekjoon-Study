#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int[] arr = new int[81];
        int s1 = int.Parse(input[0]);
        int s2 = int.Parse(input[1]);
        int s3 = int.Parse(input[2]);

        for (int i = 1; i <= s1; i++)
        {
            for (int j = 1; j <= s2; j++)
            {
                for (int k = 1; k <= s3; k++)
                {
                    int index = i + j + k;
                    arr[index]++;
                }
            }
        }

        int result = 0;
        int max = 0;
        for (int i = 1; i <= 80; i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                result = i;
            }
        }
        sw.Write(result);
    }
}