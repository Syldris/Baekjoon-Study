    #nullable disable
    class Program
    {
        static void Main()
        {
            using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
            using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

            int n = int.Parse(sr.ReadLine());
            int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            bool[,] pattern = new bool[3, 3];

            (int x, int y) = converter(arr[0]);
            pattern[x, y] = true;

            for (int i = 1; i < arr.Length; i++)
            {
                (int dx, int dy) = converter(arr[i]);

                if (pattern[dx, dy])
                {
                    sw.Write("NO");
                    return;
                }

                int diffX = Math.Abs(dx - x);
                int diffY = Math.Abs(dy - y);
                if ((diffX == 2 && diffY == 1) || (diffX == 1 && diffY == 2))
                {
                    pattern[dx, dy] = true;
                }
                else if (diffX == 2 && diffY == 2)
                {
                    if (!pattern[1,1])
                    {
                        sw.Write("NO");
                        return;
                    }
                }
                else if (diffX == 2 && diffY == 0)
                {
                    if (!pattern[1, y])
                    {
                        sw.Write("NO");
                        return;
                    }
                }
                else if (diffX == 0 && diffY == 2)
                {
                    if (!pattern[x, 1])
                    {
                        sw.Write("NO");
                        return;
                    }
                }

                pattern[dx, dy] = true;
                x = dx;
                y = dy;
            }

            sw.Write("YES");

            (int x, int y) converter(int value)
            {
                int returnX = value % 3 - 1;
                int returnY = (value - 1) / 3;

                if (value % 3 == 0)
                {
                    returnX = 2;
                }

                return (returnX, returnY);
            }
        }
    }