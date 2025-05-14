using System.Diagnostics;

class Program
{
    static void Main()
    {
        Process process = new Process();
        process.StartInfo.FileName = "notepad.exe";
        process.Start();

        Console.WriteLine("Notepad launched");
    }
}
