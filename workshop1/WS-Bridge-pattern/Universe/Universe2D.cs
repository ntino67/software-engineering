using System;
using System.Collections.Generic;
using System.Drawing;
using Element;

namespace Universe
{
    public class Universe2D : IUniverse {
        public int Width {get; private set;}
        public int Height {get; private set;}
        public List<IElement> Elements {get;  set;}
        public int ElementsCount => Elements.Count;

        public void Add(IElement element) {
            if (!IsInside(element.Location)) {
                    throw new ArgumentException("Element is out of bounds.");
            }

            if (GetElementAt(element.Location) != null) {
                throw new ArgumentException("Another element already exist in this location");
            }

            if (Elements.Contains(element)) {
                throw new ArgumentException("Element already exists in the Universe");
            }

            Elements.Add(element);
            element.Universe = this;
        }
       
        public void Remove(IElement element) {
            if (Elements.Contains(element)) {
                Elements.Remove(element);
                element.Universe = null;
            }
        }

        public IElement GetElementAt(Point p) {
            foreach (IElement element in Elements) {
                if (element.Location == p) {
                    return element;
                }
            }
            return null;
        }

        public bool IsInside(Point p) {
            return p.X >= 0 && p.X < Width && p.Y >= 0 && p.Y < Height;
        }

        public void Update() {
            throw new NotImplementedException();
        }

        public Universe2D(int Width, int Height) {
            this.Width = Width;
            this.Height = Height;
            Elements = new List<IElement>();
        }
    }
}
