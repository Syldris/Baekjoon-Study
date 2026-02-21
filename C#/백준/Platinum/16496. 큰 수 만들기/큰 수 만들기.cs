#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        string[] arr = sr.ReadLine().Split();

        Array.Sort(arr, (a, b) =>
        {
            int len = Math.Min(a.Length, b.Length); // 둘의 길이중 짧은쪽까지 같이 비교

            for (int i = 0; i < len; i++)
            {
                if (a[i] != b[i]) // 다르면 큰쪽부터
                {
                    return b[i].CompareTo(a[i]); // b가 큰수일때 1를 반환해서 자리를 바꿈, 작으면 제자리  
                }
            }

            int index = len; // 비교했을때 같다면 길이가 남은쪽은 추가로 비교하는게 최적일것 같다.
            int end = a.Length + b.Length; // 한바퀴 돌면서 비교해보자

            while (index < end)
            {
                if (a[index % a.Length] != b[index % b.Length])
                    return b[index % b.Length].CompareTo(a[index % a.Length]); // a가 더 큰수일때 음수를 반환해 앞에있게 해주자. a > b 라면 음수니 제자리니 a가 앞이다.
                index++;
            }

            return 0;
        }
        );

        if (arr[0] == "0") // 가장 앞에오는 수가 0이면 000..이므로 0으로 출력
        {
            sw.Write(0);
            return;
        }

        for (int i = 0; i < n; i++)
        {
            sw.Write(arr[i]);
        }
    }
}