#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        string[] input = sr.ReadLine().Split();
        int k = int.Parse(input[0]);
        int n = int.Parse(input[1]);

        string[] arr = new string[k];
        int maxValue = 0;
        for (int i = 0; i < k; i++)
        {
            arr[i] = sr.ReadLine();
            maxValue = Math.Max(int.Parse(arr[i]), maxValue);
        }

        string maxValueString = maxValue.ToString();

        Array.Sort(arr, (a, b) =>
        {
            int len = a.Length + b.Length;
            for (int i = 0; i < len; i++)
            {
                if (a[i % a.Length] != b[i % b.Length]) // aaaa.. bb.. 일때 
                    return b[i % b.Length].CompareTo(a[i % a.Length]); // b가 더클때 앞으로 오게 양수
            }
            return 0;
        });

        int extraCount = n - k;

        for (int i = 0; i < k; i++)
        {
            while (extraCount > 0 && arr[i] == maxValueString) // 가장 큰 수는 남는 횟수 만큼 추가사용
            {
                sw.Write(arr[i]);
                extraCount--;
            }
            sw.Write(arr[i]);
        }
    }
}