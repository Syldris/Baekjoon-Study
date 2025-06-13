#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        while (true)
        {
            int[] input =sr.ReadLine().Split().Select(int.Parse).ToArray();
            int a = input[0];
            int b = input[1];
            int c = input[2];

            if(a == 0 && b == 0 && c ==0) 
                break;

            if (a + b + c - input.Max() <= input.Max())
            {
                sw.WriteLine("Invalid");
            }
            else if (a == b && b == c)
            {
                sw.WriteLine("Equilateral");
            }
            else if (a == c || b == c || a == b)
            {
                sw.WriteLine("Isosceles");
            }
            else
            {
                sw.WriteLine("Scalene");
            }
        }
    }
}