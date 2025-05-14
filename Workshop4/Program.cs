using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

class Program
{
    static void Main()
    {
        LaunchAndWait("explorer.exe", @"C:\Windows");
        Thread.Sleep(2000);

        string filePath = @"C:\Temp\example.txt";
        CreateTextFile(filePath);
        LaunchAndWait("notepad.exe", filePath);
        Thread.Sleep(2000);
    }

    static void LaunchAndWait(string processName, string arguments = "")
    {
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = processName,
                Arguments = arguments,
                UseShellExecute = true
            };

            var process = Process.Start(psi);

            if (process != null)
            {
                Console.WriteLine($"{process.ProcessName} process no. {process.Id} is launched.");
                process.WaitForExit();
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

    static void CreateTextFile(string path)
    {
        string? directory = Path.GetDirectoryName(path);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory!);
        }

        File.WriteAllText(path, "This is an example file created by Workshop4.");
        Console.WriteLine($"Created text file at: {path}");
    }
}