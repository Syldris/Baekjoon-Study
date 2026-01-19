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

        for (int t = 0; t < n; t++)
        {
            char[][] text = new char[3][];
            for (int i = 0; i < 3; i++)
            {
                text[i] = sr.ReadLine().ToCharArray();
            }

            for (int i = 0; i < m; i++)
            {
                int pos = i * 8;
                int a = text[1][pos + 1] - '0';
                int b = text[1][pos + 3] - '0';

                int value = 0;
                int k = 5;
                if (text[1][pos+6] == '.')
                {
                    value = text[1][pos + 5] - '0';
                }
                else
                {
                    value = (text[1][pos + 5] - '0') * 10 + text[1][pos + 6] - '0';
                    k++;
                }


                if (a + b == value)
                {
                    text[1][pos] = '*';
                    for (int j = 1; j <= k; j++)
                    {
                        text[0][pos + j] = '*';
                        text[2][pos + j] = '*';
                    }
                    text[1][pos + k + 1] = '*';
                }
                else
                {
                    text[0][pos + 3] = '/';
                    text[1][pos + 2] = '/';
                    text[2][pos + 1] = '/';
                }
            }

            for (int i = 0; i < 3; i++)
            {
                sw.WriteLine(new string(text[i]));
            }
        }
    }
}