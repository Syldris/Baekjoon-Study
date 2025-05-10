public class Program
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        int x = int.Parse(inputs[0]);
        int y = int.Parse(inputs[1]);

        Console.WriteLine((x * y / 24200) + 1);

    }
}
