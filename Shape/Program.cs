// See https://aka.ms/new-console-template for more information
using System.Security.Cryptography.X509Certificates;

namespace myShape
{   
    abstract class Shape
    {
        public abstract double area();
        public abstract bool legitimate();
    }
    class Rectangle : Shape
    {
        private double length;
        private double width;

        public Rectangle(double len, double wid)
        {
            length = len;
            width = wid;
        }
        public void setLength(double len)
        {
            length = len;
        }
        public void setWidth(double wid)
        {
            width = wid;
        }
        override public double area()
        {
            return length*width;
        }
        override public bool legitimate()
        {
            if (length>0 && width>0)
            {
                return true;
            }
            return false;
        }
    }
    class Square : Shape
    {
        private double edgeLength;

        public Square(double edg)
        {
            edgeLength = edg;
        }
        public void setEdgeLength(double edg)
        {
            edgeLength = edg;
        }
        override public double area()
        {
            return edgeLength*edgeLength;
        }
        override public bool legitimate()
        {
            if (edgeLength>0)
            {
                return true;
            }
            return false;
        }
    }
    class Triangle : Shape
    {
        private double edgeLen1;
        private double edgeLen2;
        private double angle;

        public Triangle(double edg1, double edg2, double ang)
        {
            edgeLen1 = edg1;
            edgeLen2 = edg2;
            angle = ang;
        }
        public void setEdgeLen1(double edg1)
        {
            edgeLen1 = edg1;
        }
        public void setEdgeLen2(double edg2)
        {
            edgeLen2 = edg2;
        }
        public void setAngle(double ang)
        {
            angle = ang;
        }
        override public double area()
        {
            return edgeLen1*edgeLen2*Math.Sin(angle)*0.5;
        }
        override public bool legitimate()
        {
            if (edgeLen1>0 && edgeLen2>0 && angle>0 && angle<Math.PI)
            {
                return true;
            }
            return false;
        }
    }
    class Test
    {
        public Shape createShape()
        {
            Shape sp = null;
            Random random = new Random();
            int i = random.Next(3);
            if (i==0)
            {
                sp = new Rectangle(random.NextDouble()*10, random.NextDouble()*10);
            }
            else if (i == 1)
            {
                sp = new Square(random.NextDouble()*10);
            }
            else if (i == 2)
            {
                sp = new Triangle(random.NextDouble() * 10, random.NextDouble() * 10, random.NextDouble()*Math.PI);
            }
            return sp;
        }
        static void Main(string[] args)
        {
            double sum = 0.0;
            //Rectangle rectangle = new Rectangle(5.0, 10.0);
            //Square square = new Square(7.0);
            //Triangle triangle = new Triangle(3.0, 4.0, 0.5 * Math.PI);

            //Console.WriteLine(rectangle.area());
            //Console.WriteLine(rectangle.legitimate());

            //Console.WriteLine(square.area());
            //Console.WriteLine(square.legitimate());

            //Console.WriteLine(triangle.area());
            //Console.WriteLine(triangle.legitimate());
            //triangle.setAngle(5.0);
            //Console.WriteLine(triangle.legitimate());\
            Test ot = new Test();
            Shape []s = new Shape[10];
            for (int i = 0; i < 10; i++)
            {
                s[i] = ot.createShape();
            }

            for (int i = 0; i < 10; i++)
            {
                sum = sum + s[i].area();
            }
            Console.WriteLine("The total area is: " + sum);
        }
    }
}
