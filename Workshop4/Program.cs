using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        LaunchAndWait("explorer.exe");
        Thread.Sleep(2000); // wait 2 seconds before continuing

        LaunchAndWait("mspaint.exe");
        Thread.Sleep(2000); // again, for demonstration
    }

    static void LaunchAndWait(string processName)
    {
        try
        {
            Process? process = Process.Start(processName);
            if (process != null)
            {
                Console.WriteLine($"{process.ProcessName} process no. {process.Id} is launched.");
                process.WaitForExit(); // parent waits here
                Console.WriteLine($"{process.ProcessName} has exited.");
            }
            else
            {
                Console.WriteLine($"Failed to launch {processName}.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error launching {processName}: {ex.Message}");
        }
    }
}