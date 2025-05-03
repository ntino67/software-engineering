using System.Drawing;
using Universe;

namespace Element
{
    public interface IElement {
        string Name {get;}
        string Symbol {get;}
        double Mass {get;}
        IUniverse Universe {get; set;}
        Point Location {get; set;}
    }
}
