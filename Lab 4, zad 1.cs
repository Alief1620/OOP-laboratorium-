using System;
using System.Collections.Generic;

namespace Laboratorium_4
{
    public class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        public virtual void Draw()
        {
            Console.WriteLine("Drawing a generic shape");
        }
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
        }
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a triangle");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle");
        }
    }

    class Program
    {
        static void Main()
        {
            List<Shape> shapes = new List<Shape>();

            shapes.Add(new Rectangle { X = 0, Y = 0, Width = 5, Height = 3 });
            shapes.Add(new Triangle { X = 2, Y = 1, Width = 4, Height = 3 });
            shapes.Add(new Circle { X = 3, Y = 2, Width = 6, Height = 6 });

            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }
    }

}
