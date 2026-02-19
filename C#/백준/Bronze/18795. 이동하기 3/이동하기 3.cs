#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 20);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string input = sr.ReadLine();

        int[] arr1 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);
        int[] arr2 = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        long value = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            value += arr1[i];
        }
        for (int i = 0; i < arr2.Length; i++)
        {
            value += arr2[i];
        }

        sw.Write(value);
    }
}