#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());

        bool[] answer = new bool[26];

        for (int t = 0; t < testcase; t++)
        {
            string text = sr.ReadLine().ToLower();

            for (int i = 0; i < text.Length; i++)
            {
                if ('a' <= text[i] && text[i] <= 'z')
                {
                    answer[text[i] - 'a'] = true;
                }
            }

            List<char> list = new List<char>(); // 안나온 문자열

            for (int i = 0; i < answer.Length; i++)
            {
                if (!answer[i])
                    list.Add((char)(i + 'a'));
            }

            if (list.Count == 0)
            {
                sw.WriteLine("pangram");
            }
            else
            {
                list.Sort();
                sw.Write("missing ");

                foreach (var item in list)
                {
                    sw.Write(item);
                }

                sw.WriteLine();
            }
            Array.Fill(answer, false);
        }
    }
}