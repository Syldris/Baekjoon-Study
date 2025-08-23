#nullable disable
using System;
using System.Text;
class Program
{
    public struct Data : IComparable<Data>
    {
        public string name;
        public int day;
        public int month;
        public int year;
        public int CompareTo(Data other)
        {
            if(year != other.year) return year.CompareTo(other.year);
            else if(month != other.month) return month.CompareTo(other.month);
            else  return day.CompareTo(other.day);
        }
    }

    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        int n = int.Parse(sr.ReadLine());
        Data[] data = new Data[n];

        for (int i = 0; i < n; i++)
        {
            string[] line = sr.ReadLine().Split();
            data[i] = new Data 
            { 
                name = line[0],
                day = int.Parse(line[1]),
                month = int.Parse(line[2]),
                year = int.Parse(line[3]),
            };
        }

        Array.Sort(data);

        sw.WriteLine(data[^1].name);
        sw.WriteLine(data[0].name);
    }
}
