#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int l = int.Parse(input[0]);
        int c = int.Parse(input[1]);

        char[] arr = sr.ReadLine().Split().Select(x => x[0]).ToArray();

        Array.Sort(arr);

        char[] password = new char[l];
        bool[] select = new bool[c];
        BackTrack(0, 0);

        void BackTrack(int depth, int prev)
        {
            if (depth == l)
            {
                int a = 0;
                int b = 0;

                foreach (char c in password)
                {
                    if (check(c)) a++;
                    else b++;
                }

                if (a >= 1 && b >= 2)
                {
                    sw.WriteLine(new string(password));
                }
                return;
            }

            for (int i = prev; i < c; i++)
            {
                if (!select[i])
                {
                    select[i] = true;
                    password[depth] = arr[i];
                    BackTrack(depth + 1, i);

                    select[i] = false;
                }
            }
        }

        bool check(char c) => c switch
        {
            'a' => true,
            'e' => true,
            'i' => true,
            'o' => true,
            'u' => true,
            _ => false
        };
    }
}