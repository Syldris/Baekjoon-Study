#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        while (true)
        {
            string line = sr.ReadLine();
            if(line == null)
                break;

            int num = int.Parse(line);

            int len = Pow3(num);
            char[] arr = new char[len];
            Array.Fill(arr, ' ');

            Sovle(0, num, arr);
            sw.WriteLine(new string(arr));
        }

        void Sovle(int start, int size, char[] arr)
        {
            if (size == 0)
            {
                arr[start] = '-';
                return;
            }

            size--;
            int move = Pow3(size);
            Sovle(start, size, arr);
            Sovle(start + move * 2, size, arr);
        }

        int Pow3(int x)
        {
            int value =1;

            for (int i = 0; i < x; i++)
            {
                value *= 3;
            }

            return value;
        }
    }
}