using System;

public abstract class Shape
{
    public abstract double GetArea();
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}

public class Triangle : Shape
{
    public double A { get; set; }
    public double B { get; set; }
    public double C { get; set; }

    public Triangle(double a, double b, double c)
    {
        A = a;
        B = b;
        C = c;
    }

    public override double GetArea()
    {
        var p = (A + B + C) / 2;
        return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
    }

    public bool IsRightTriangle()
    {
        var sides = new[] { A, B, C };
        Array.Sort(sides);
        return Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < 0.000001;
    }
}

using System;
using NUnit.Framework;

namespace GeometryLibrary.Tests
{
    [TestFixture]
    public class CircleTests
    {
        [Test]
        public void GetArea_Radius3_ReturnsArea()
        {
            var circle = new Circle(3);
            var expectedArea = Math.PI * 9;
            Assert.AreEqual(expectedArea, circle.GetArea(), 0.0001);
        }
    }

    [TestFixture]
    public class TriangleTests
    {
        [Test]
        public void GetArea_Sides3And4And5_ReturnsArea()
        {
            var triangle = new Triangle(3, 4, 5);
            var expectedArea = 6;
            Assert.AreEqual(expectedArea, triangle.GetArea(), 0.0001);
        }

        [Test]
        public void IsRightTriangle_Sides3And4And5_ReturnsTrue()
        {
            var triangle = new Triangle(3, 4, 5);
            Assert.IsTrue(triangle.IsRightTriangle());
        }

        [Test]
        public void IsRightTriangle_Sides3And4And6_ReturnsFalse()
        {
            var triangle = new Triangle(3, 4, 6);
            Assert.IsFalse(triangle.IsRightTriangle());
        }
    }
}
