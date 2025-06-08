#nullable disable
using System.Text;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int[] arr1 = sr.ReadLine().Split().Select(int.Parse).ToArray();
        int[] arr2 = sr.ReadLine().Split().Select(int.Parse).ToArray();

        int winA = 0;
        int winB = 0;
        for (int i = 0; i < 10; i++)
        {
            if (arr1[i] > arr2[i])
            {
                winA++;
            }
            else if (arr1[i] < arr2[i])
            {
                winB++;
            }
        }
        if(winA == winB)
        {
            sw.Write('D');
        }
        else
        {
            sw.Write(winA > winB ? "A" : "B");
        }
    }
}