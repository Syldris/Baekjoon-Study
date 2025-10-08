#nullable disable
using System;
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        (int year, string name)[] runtime = new (int, string)[] {
(1967, "DavidBowie"),
(1969, "SpaceOddity"),
(1970, "TheManWhoSoldTheWorld"),
(1971, "HunkyDory"),
(1972, "TheRiseAndFallOfZiggyStardustAndTheSpidersFromMars"),
(1973, "AladdinSane"),
(1973, "PinUps"),
(1974, "DiamondDogs"),
(1975, "YoungAmericans"),
(1976, "StationToStation"),
(1977, "Low"),
(1977, "Heroes"),
(1979, "Lodger"),
(1980, "ScaryMonstersAndSuperCreeps"),
(1983, "LetsDance"),
(1984, "Tonight"),
(1987, "NeverLetMeDown"),
(1993, "BlackTieWhiteNoise"),
(1995, "1.Outside"),
(1997, "Earthling"),
(1999, "Hours"),
(2002, "Heathen"),
(2003, "Reality"),
(2013, "TheNextDay"),
(2016, "BlackStar")};
        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] input = sr.ReadLine().Split();
            int start = int.Parse(input[0]);
            int end = int.Parse(input[1]);
            (int year, string name)[] result = runtime.Where(x => x.year >= start && x.year <= end).ToArray();
            sw.WriteLine(result.Length);
            foreach (var item in result)
            {
                sw.WriteLine($"{item.year} {item.name}");
            }
        }
    }
}