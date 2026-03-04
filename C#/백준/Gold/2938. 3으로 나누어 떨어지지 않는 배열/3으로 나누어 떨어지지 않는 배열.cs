#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int n = int.Parse(sr.ReadLine());
        int[] arr = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        List<int> zeroList = new List<int>();
        List<int> oneList = new List<int>();
        List<int> twoList = new List<int>();

        for (int i = 0; i < n; i++)
        {
            if (arr[i] % 3 == 0)
                zeroList.Add(arr[i]);

            else if (arr[i] % 3 == 1)
                oneList.Add(arr[i]);

            else
                twoList.Add(arr[i]);
        }

        bool option = (zeroList.Count == 0 && oneList.Count > 0 && twoList.Count > 0); // 0이 0개면서 1과 2로 이루어져있지않으면, 1과2가 만나버린다.

        if (zeroList.Count - oneList.Count - twoList.Count > 1 || option) // 0의 갯수가 1,2 보다 2개이상 많으면 0 2 0 1 0 같이 0끼리 못만나게 끼어넣지 못한다.  
        {
            sw.Write(-1);
            return;
        }

        int[] result = new int[n];
        int index = 0;
        int i0 = 0;
        int i1 = 0;
        int i2 = 0;

        if (oneList.Count + twoList.Count > zeroList.Count) // 1 0 2 0 1 같이 1,2끼리 만나지못하게 0을 사이에 넣는경우 
        {
            while (index < n)
            {
                if (index % 2 == 1 && i0 < zeroList.Count - 1) // 0을 미리미리 소비하되, 1개는 남겨두자.
                    result[index++] = zeroList[i0++];

                else if (i1 < oneList.Count) 
                    result[index++] = oneList[i1++];

                else if (i0 < zeroList.Count && index > 0 && result[index - 1] % 3 != 0) // 1 1 1.. 2 2 2 로 넘어가기전에 사이에 0을 끼워서 1 1 0 2 2 로 만들자. 물론 이전에 0을 썻으면 잠깐 넘긴다. 
                    result[index++] = zeroList[i0++];

                else
                    result[index++] = twoList[i2++];
            }
        }
        else // 0 2 0 1 0 같이 0 끼리 만나지 못하게 사이에 1,2를 끼어넣는 경우
        {
            while (index < n)
            {
                if (index % 2 == 0)
                    result[index++] = zeroList[i0++];

                else if (i1 < oneList.Count)
                    result[index++] = oneList[i1++];

                else
                    result[index++] = twoList[i2++];
            }
        }


        sw.Write(string.Join(' ', result));
    }
}