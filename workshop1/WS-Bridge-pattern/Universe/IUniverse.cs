using System.Collections.Generic;
using System.Drawing;
using Element;

namespace Universe
{
    public interface IUniverse {
        int Width {get;}
        int Height {get;}
        int ElementsCount {get;}
        List<IElement> Elements {get;}

        void Add(IElement element);
        void Remove(IElement element);
        IElement GetElementAt(Point p);
        bool IsInside(Point p);
        void Update();
    }
}
