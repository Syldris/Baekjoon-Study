#nullable disable
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(Console.OpenStandardInput(), bufferSize: 1 << 16);
        using StreamWriter sw = new StreamWriter(Console.OpenStandardOutput(), bufferSize: 1 << 16);

        int[] input = Array.ConvertAll(sr.ReadLine().Split(), int.Parse);

        int n = input[0];
        int m = input[1];

        Dictionary<string, List<string>> teamMember = new(); // 그룹 => 맴버이름들
        Dictionary<string, string> memberToGroup = new(); // 맴버이름 => 그룹이름

        for (int i = 0; i < n; i++)
        {
            string team = sr.ReadLine();

            int teamSize = int.Parse(sr.ReadLine());
            List<string> mamberList = new();

            for (int j = 0; j < teamSize; j++)
            {
                string membername = sr.ReadLine();

                mamberList.Add(membername);
                memberToGroup.Add(membername, team); // 맴버이름 => 그룹
            }

            mamberList.Sort(); // 사전순 정렬.
            teamMember.Add(team, mamberList); // 팀 => 그룹 이름 리스트.
        }

        for (int i = 0; i < m; i++)
        {
            string text = sr.ReadLine();
            int type = int.Parse(sr.ReadLine());

            if (type == 0) // 그룹 내 맴버 이름들 출력
            {
                foreach (var item in teamMember[text])
                {
                    sw.WriteLine(item);
                }
            }
            else
                sw.WriteLine(memberToGroup[text]); // 맴버 이름으로 그룹이름 출력.
        }
    }
}