#nullable disable
using System;
using System.Collections;
using System.Numerics;
class Program
{
    static void Main()
    {
        using StreamReader sr = new StreamReader(new BufferedStream(Console.OpenStandardInput()));
        using StreamWriter sw = new StreamWriter(new BufferedStream(Console.OpenStandardOutput()));

        sw.Write("    8888888888  888    88888\n   88     88   88 88   88  88\n    8888  88  88   88  88888\n       88 88 888888888 88   88\n88888888  88 88     88 88    888888\n\n88  88  88   888    88888    888888\n88  88  88  88 88   88  88  88\n88 8888 88 88   88  88888    8888\n 888  888 888888888 88  88      88\n  88  88  88     88 88   88888888");
    }
}
