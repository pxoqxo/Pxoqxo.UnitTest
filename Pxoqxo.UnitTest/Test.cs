using System.Diagnostics;
using System.Reflection;

namespace Pxoqxo.UnitTest
{
    public static class Test
    {
        public static bool Run(Func<bool> test)
        {
            MethodInfo methodInfo = test.Method;
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool result = false;
            Exception? exception = null;

            try
            {
                result = test();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            stopwatch.Stop();
            Print(result, methodInfo, stopwatch.Elapsed, exception);
            return result;
        }
        public static async Task<bool> RunAsync(Func<Task<bool>> test)
        {
            MethodInfo methodInfo = test.Method;
            Stopwatch stopwatch = Stopwatch.StartNew();
            bool result = false;
            Exception? exception = null;

            try
            {
                result = await test();
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            stopwatch.Stop();
            Print(result, methodInfo, stopwatch.Elapsed, exception);
            return result;
        }
        private static void Print(bool result, MethodInfo methodInfo, TimeSpan elapsed, Exception? exception)
        {
            string status = result ? "[PASS]" : "[FAIL]";

            Type? declaringType = methodInfo.DeclaringType;
            string namespaceName = declaringType?.Namespace ?? "-";
            string className = declaringType?.Name ?? "-";
            string methodName = methodInfo.Name;

            string time = $"[{GetLabel(elapsed)}]";

            string message = string.Empty;
            string stackTrace = string.Empty;
            if (!result && exception != null)
            {
                message = $" [{exception.Message}]";
                if (exception.StackTrace != null)
                {
                    stackTrace = $"\r\n{exception.StackTrace}";
                }
            }

            Console.ForegroundColor = result ? ConsoleColor.Green : ConsoleColor.Red;
            Console.Write(status);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" [");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(namespaceName);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(className);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(methodName);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("] ");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(time);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(message);

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(stackTrace);
        }
        private static string GetLabel(TimeSpan timeSpan)
        {
            if (timeSpan.TotalDays >= 1)
            {
                return timeSpan.TotalDays + "d";
            }
            else if (timeSpan.TotalHours >= 1)
            {
                return timeSpan.TotalHours + "h";
            }
            else if (timeSpan.TotalMinutes >= 1)
            {
                return timeSpan.TotalMinutes + "min";
            }
            else if (timeSpan.TotalSeconds >= 1)
            {
                return timeSpan.TotalSeconds + "s";
            }
            else if (timeSpan.TotalMilliseconds >= 1)
            {
                return timeSpan.TotalMilliseconds + "ms";
            }
            else if (timeSpan.TotalMicroseconds >= 1)
            {
                return timeSpan.TotalMicroseconds + "μs";
            }
            else
            {
                return timeSpan.TotalNanoseconds + "ns";
            }
        }
    }
}
