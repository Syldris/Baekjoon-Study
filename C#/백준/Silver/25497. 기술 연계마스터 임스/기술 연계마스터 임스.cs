#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        string text = sr.ReadLine();

        int value = 0;
        int countL = 0;
        int countS = 0;
        bool gameOver = false;

        for (int i = 0; i < n; i++)
        {
            if ('1' <= text[i] && text[i] <= '9')
            {
                value++; 
                continue;
            }

            switch (text[i])
            {
                case 'L': countL++; break;
                case 'S': countS++; break;

                case 'R' when countL > 0:
                    countL--;
                    value++;
                    break;

                case 'K' when countS > 0:
                    countS--;
                    value++;
                    break;

                default: gameOver = true; break;
            }
            if (gameOver) break;
        }

        sw.Write(value);
    }
}