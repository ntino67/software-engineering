using System.Drawing;
using Universe;

namespace Element
{
    public class Atom : IElement {
        public string Name {get;}
        public string Symbol {get;}
        public double Mass {get;}
        public IUniverse Universe {get; set;}
        public Point Location {get; set;}

        public Atom(string Name, string Symbol, double Mass) {
            this.Name = Name;
            this.Symbol = Symbol;
            this.Mass = Mass;
        }
    }
}
