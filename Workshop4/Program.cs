using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        OpenDirectoryWithVerb(@"C:\Windows", "explore");
        OpenFileWithVerb(@"C:\Windows\win.ini", "edit");  // or "open" if edit isn't registered
    }

    static void OpenDirectoryWithVerb(string path, string verb)
    {
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = path,
                Verb = verb,
                UseShellExecute = true
            };

            Process.Start(psi);
            Console.WriteLine($"Used verb '{verb}' on directory: {path}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to {verb} directory {path}: {ex.Message}");
        }
    }

    static void OpenFileWithVerb(string filePath, string verb)
    {
        try
        {
            var psi = new ProcessStartInfo
            {
                FileName = filePath,
                Verb = verb,
                UseShellExecute = true
            };

            Process.Start(psi);
            Console.WriteLine($"Used verb '{verb}' on file: {filePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to {verb} file {filePath}: {ex.Message}");
        }
    }
}