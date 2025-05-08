using System.Text;
public class Program
{
    static void Main()
    {
        int[] arr = new int[4];
        int[] arr2 = new int[2];
        for (int i = 0; i < 4; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        }
        Array.Sort(arr);
        Array.Reverse(arr);
        int value = 0;

        for (int i = 0; i < 3; i++)
        {
            value += arr[i];
        }
        for (int i = 0; i < 2; i++)
        {
            arr2[i] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine(value+arr2.Max());
    }
}
