using System;
using System.Diagnostics;
using System.Threading;

class Program
{
    static void Main()
    {
        LaunchWithMonitoring("mspaint.exe");
    }

    static void LaunchWithMonitoring(string processName)
    {
        try
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = processName,
                    UseShellExecute = true
                },
                EnableRaisingEvents = true // Needed to use Exited event
            };

            process.Exited += (sender, e) =>
            {
                Console.WriteLine($"[Event] Process {processName} has exited (event triggered).");
            };

            process.Start();

            Console.WriteLine($"{process.ProcessName} process no. {process.Id} is launched.");

            Thread.Sleep(2000); // Simulate doing other stuff...

            if (process.HasExited)
            {
                Console.WriteLine($"Process {processName} has already exited.");
            }
            else
            {
                Console.WriteLine($"Process {processName} is still running. Waiting for it to exit...");
                process.WaitForExit(); // Wait if still running
                Console.WriteLine($"Process {processName} has now exited.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error launching {processName}: {ex.Message}");
        }
    }
}