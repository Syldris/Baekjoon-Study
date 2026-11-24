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
            string teamName = sr.ReadLine();

            int teamSize = int.Parse(sr.ReadLine());

            teamMember.Add(teamName, new List<string>());

            for (int j = 0; j < teamSize; j++)
            {
                string membername = sr.ReadLine();

                teamMember[teamName].Add(membername); // 그룹 이름 => 맴버 리스트 추가.
                memberToGroup.Add(membername, teamName); // 맴버이름 => 그룹
            }

            teamMember[teamName].Sort(); // 사전순 정렬.
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
            {
                sw.WriteLine(memberToGroup[text]); // 맴버 이름으로 그룹이름 출력.
            }
        }
    }
}