public class Program
{
    static void Main()
    {
        int[] arr = new int[10];
        Dictionary<int,int> hash = new Dictionary<int,int>();
        int total = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            int num = int.Parse(Console.ReadLine());
            arr[i] = num;
            if(!hash.ContainsKey(num))
                hash.Add(num, 1);
            else
                hash[num]++;
            total += num;
        }
        Console.WriteLine(total / 10);
        Console.WriteLine(hash.MaxBy(x => x.Value).Key);
    }
}
