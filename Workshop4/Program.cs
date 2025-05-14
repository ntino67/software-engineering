using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        LaunchAndNotify("mspaint");
        LaunchAndNotify("notepad");
    }

    static void LaunchAndNotify(string processName)
    {
        try
        {
            Process? process = Process.Start(processName);
            if (process != null)
            {
                Console.WriteLine($"{process.ProcessName} process no. {process.Id} is launched.");
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