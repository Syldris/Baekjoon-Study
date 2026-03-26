#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int n = int.Parse(input[0]);
        int m = int.Parse(input[1]);

        string[] texts = new string[n * 5 + 1];
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i] = sr.ReadLine();
        }
        int[] result = new int[5];

        for (int y = 0; y < n; y++)
        {
            for (int x = 0; x < m; x++)
            {
                int posX = x * 5 + 1;
                int posY = y * 5 + 1;

                int count = 0;

                for (int i = 0; i < 4; i++)
                {
                    if (texts[posY + i][posX] == '*')
                        count++;
                }
                result[count]++;
            }
        }

        sw.Write(string.Join(' ', result));

    }
}