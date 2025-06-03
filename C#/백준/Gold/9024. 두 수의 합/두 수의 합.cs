#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int tastcase = int.Parse(sr.ReadLine());
        for (int t = 0; t < tastcase; t++)
        {
            int[] input = sr.ReadLine().Split().Select(int.Parse).ToArray();
            int n = input[0];
            int k = input[1];

            int[] arr = sr.ReadLine().Split().Select(int.Parse).ToArray();
            Array.Sort(arr);

            int nearK = int.MaxValue;
            int numberCaseK = 0;

            int start = 0, end = n-1;
            while (start < end)
            {
                int value = arr[end] + arr[start];
                if (Math.Abs(value - k) == nearK)
                {
                    numberCaseK++;
                }
                else if(Math.Abs(value - k) < nearK)
                {
                    nearK = Math.Abs(value - k);
                    numberCaseK = 1;
                }

                if(value <= k)
                {
                    start++;
                }
                else
                {
                    end--;  
                }
            }
            sw.WriteLine(numberCaseK);
        }
    }
}