using Pxoqxo.UnitTest;
using Pxoqxo.UnitTest.Tests;

// Anonymous Methods
Console.WriteLine("-> Anonymous Methods");
Test.Run(() => true);
Test.Run(() =>
{
    return false;
});
Test.Run(() => Method1());
Test.Run(() =>
{
    return Method2();
});

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine();
Console.WriteLine("--------------------------------------------------");
Console.WriteLine();

// No Namespace
Console.WriteLine("-> No Namespace");
Test.Run(Method1);
Test.Run(Method2);
Test.Run(Method3);
Test.Run(Method4);

Console.ForegroundColor = ConsoleColor.White;
Console.WriteLine();
Console.WriteLine("--------------------------------------------------");
Console.WriteLine();

// Custom Class With Namespace
Console.WriteLine("-> Custom Class With Namespace");
DemoTests demoTests = new();
Test.Run(demoTests.Method1);
Test.Run(demoTests.Method2);
Test.Run(demoTests.Method3);
Test.Run(DemoTests.Method4);

bool Method1()
{
    int[] i = [];
    i[0] = 1;

    return true;
}
bool Method2()
{
    Thread.Sleep(100);
    return true;
}
bool Method3()
{
    Thread.Sleep(1000);
    return true;
}
static bool Method4()
{
    return true;
}

namespace Pxoqxo.UnitTest.Tests
{
    public class DemoTests
    {
        public bool Method1()
        {
            int[] i = [];
            i[0] = 1;

            return true;
        }
        public bool Method2()
        {
            Thread.Sleep(100);
            return true;
        }
        public bool Method3()
        {
            Thread.Sleep(1000);
            return true;
        }
        public static bool Method4()
        {
            return true;
        }
    }
}
