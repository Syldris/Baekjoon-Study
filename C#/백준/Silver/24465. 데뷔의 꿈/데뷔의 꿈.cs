#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        bool[] seat = new bool[12];
        List<(int month, int day)> passedPeople = new();

        for (int i = 0; i < 7; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int pos = GetIndex(line[0], line[1]);
            seat[pos] = true;
        }

        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int[] line = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

            int index = GetIndex(line[0], line[1]);
            if (!seat[index]) // 원래 맴버랑 별자리 안겹치면 됨.
            {
                passedPeople.Add((line[0], line[1]));
            }
        }

        if (passedPeople.Count == 0)
        {
            sw.Write("ALL FAILED");
            return;
        }

        passedPeople.Sort();
        foreach ((int month, int day) in passedPeople)
        {
            sw.WriteLine($"{month} {day}");
        }

        int GetIndex(int month, int day) // 생일 받아와서 무슨 별자리인지 나타내기.
        {
            int value = month * 100 + day; // 월 일 을 하나의 숫자로 나타내서 0402 등으로 나타내기.

            return value switch
            {
                >= 120 and <= 218 => 0,
                >= 219 and <= 320 => 1,
                >= 321 and <= 419 => 2,
                >= 420 and <= 520 => 3,
                >= 521 and <= 621 => 4,
                >= 622 and <= 722 => 5,
                >= 723 and <= 822 => 6,
                >= 823 and <= 922 => 7,
                >= 923 and <= 1022 => 8,
                >= 1023 and <= 1122 => 9,
                >= 1123 and <= 1221 => 10,
                >= 1222 or <= 119 => 11,
            };
        }
    }
}