using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class NewEmptyCSharpScript
{
    static void Main()
    {
        string[] inputs = Console.ReadLine().Split();
        string a = inputs[0];
        string b = inputs[1];

        string mina = a.Replace('6', '5');
        string minb = b.Replace('6', '5');

        string maxa = a.Replace('5', '6');
        string maxb = b.Replace('5', '6');

        Console.WriteLine($"{int.Parse(mina) + int.Parse(minb)} {int.Parse(maxa) + int.Parse(maxb)}");
    }
}
