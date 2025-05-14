using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("PID\tName\t\tPriority\tMemory (MB)\tResponding");

        foreach (var process in Process.GetProcesses())
        {
            try
            {
                Console.WriteLine($"{process.Id}\t{process.ProcessName,-16}\t{process.BasePriority}\t\t{process.VirtualMemorySize64 / (1024 * 1024)}\t\t{process.Responding}");
            }
            catch
            {
                // Some processes may be inaccessible (e.g., system-level)
                Console.WriteLine($"Access denied to process {process.Id}");
            }
        }
    }
}