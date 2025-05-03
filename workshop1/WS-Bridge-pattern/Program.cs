using System;
using System.Drawing;
using Universe;
using Element;

class Program {
    static void Main(string[] args)
    {
        IUniverse universe = new Universe2D(5, 5);
        IElement atom = new Atom("Hydrogen", "H", 1.00794);
        atom.Location = new Point(2,3);

        universe.Add(atom);
        Console.WriteLine($"Added {atom.Name} at {atom.Location}");

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
