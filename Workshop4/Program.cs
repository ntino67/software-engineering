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
            var psi = new ProcessStartInfo
            {
                FileName = "/mnt/c/Windows/System32/cmd.exe",
                Arguments = $"/c start {processName}",
                RedirectStandardOutput = false,
                RedirectStandardError = false,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(psi);

            Console.WriteLine($"{processName} is launched from WSL (via cmd).");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error launching {processName}: {ex.Message}");
        }
    }
}
