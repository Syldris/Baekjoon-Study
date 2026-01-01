#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int testcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < testcase; t++)
        {
            string text = sr.ReadLine();
            if (text[^1] == '0')
            {
                sw.WriteLine("NO");
                continue;
            }

            bool pattern1 = false;
            bool pattern2 = false;
            int value = 0;
            int point = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (pattern1)
                {
                    if (text[i] == '0')
                    {
                        if (point == 0)
                            value++;

                        else
                        {
                            if (text[i + 1] == '1')
                            {
                                value = 0;
                                point = 0;
                                pattern1 = false;
                                pattern2 = true;
                            }
                            else
                            {
                                if (point >= 2)
                                {
                                    point = 0;
                                    value = 1;
                                }
                                else
                                {
                                    point = 0;
                                    break;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (value >= 2)
                            point++;
                        else
                            break;
                    }
                    continue;
                }
                else if (pattern2)
                {
                    if (text[i] == '1')
                        pattern2 = false;
                    else
                        break;

                    continue;
                }

                if (text[i] == '1')
                    pattern1 = true;

                else if (text[i] == '0')
                    pattern2 = true;
            }

            if (pattern1 && point > 0)
            {
                pattern1 = false;
            }

            if (pattern1 || pattern2)
            {
                sw.WriteLine("NO");
            }
            else
            {
                sw.WriteLine("YES");
            }
        }
    }
}