using System.Text;
public class Program
{
    static void Main()
    {
        int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Array.Sort(arr);
        Array.Reverse(arr);

        Console.WriteLine(arr[0] + arr[1]);
    }
}
