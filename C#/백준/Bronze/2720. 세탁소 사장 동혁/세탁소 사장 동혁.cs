#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        for (int i = 0; i < n; i++)
        {
            int value = int.Parse(sr.ReadLine());

            int quarter;
            int dime;
            int nickel;
            int penny;

            Update(out quarter, ref value, 25);
            Update(out dime, ref value, 10);
            Update(out nickel, ref value, 5);
            Update(out penny, ref value, 1);

            sw.WriteLine($"{quarter} {dime} {nickel} {penny}");
        }

        void Update(out int coin, ref int money, int mod)
        {
            int temp = money / mod;
            coin = temp;
            money -= temp * mod;
        }
    }
}