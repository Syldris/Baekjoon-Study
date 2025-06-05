#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            float weight = float.Parse(sr.ReadLine());
            if(weight < 0)
                break;
            float moonWeight = weight * 0.167f;
            sw.WriteLine($"Objects weighing {weight:F2} on Earth will weigh {moonWeight:F2} on the moon.");
        }
    }
}