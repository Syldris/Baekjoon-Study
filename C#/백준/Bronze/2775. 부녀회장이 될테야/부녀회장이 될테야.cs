using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
public class NewEmptyCSharpScript1
{
    static void Main()
    {
        int testcase = int.Parse(Console.ReadLine());

        for (int i = 0; i < testcase; i++)
        {
            int k = int.Parse(Console.ReadLine()); //층
            int n = int.Parse(Console.ReadLine()); //호

            Console.WriteLine(plus(k,n));
            
        }
    }

    static int plus(int k, int n)
    {
        if (k == 0) return n;
        if (n == 1) return 1;
        return plus(k - 1, n) + plus(k, n - 1);
    }
}