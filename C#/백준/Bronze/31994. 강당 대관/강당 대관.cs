#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 18);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        (string name, int people) seminar = (" ", 0);

        while (true)
        {
            string line = sr.ReadLine();
            if(line == null)
                break;
            string[] input = line.Split();

            string name = input[0];
            int people = int.Parse(input[1]);

            if (people > seminar.people)
                seminar = (name, people);
        }

        sw.WriteLine(seminar.name);
    }
}