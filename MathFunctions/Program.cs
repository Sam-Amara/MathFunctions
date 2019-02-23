using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathFunctions
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Test Math Functions on the console
            Program testMathFunctions = new Program();
            bool exit = false;
            double radius, area;
            uint a, b, c;
            double [] solutions;

            while (!exit)
            {
                Console.WriteLine("This program allows you to test the following functions:");
                Console.WriteLine(" 1. Calculate Area and Circumference of a Circle");
                Console.WriteLine(" 2. Calculate the Volume of a Hemisphere");
                Console.WriteLine(" 3. Calculate the Area of a Triangle");
                Console.WriteLine(" 4. Solve a Quadratic Equation");
                Console.WriteLine(" 5. Exit");
                Console.Write("\nEnter number: ");
                switch (Console.ReadLine())
                {
                    case "1":
                        // Option 1: calculate Circumference and Area of a Circle
                        Console.Write("Enter Radius of Circle (real number >0): ");
                        if(double.TryParse(Console.ReadLine(),out radius))
                        { 
                            if(radius > 0)
                            { 
                                Console.WriteLine($"\nCircumference: {testMathFunctions.CircleCircumference(radius):F02}");
                                Console.WriteLine($"Area: {testMathFunctions.CircleArea(radius):F02}\n");
                                break;
                            }
                        }
                        Console.WriteLine("\nInvalid Input!\n");
                        break;
                    case "2":
                        // Option 2: calculate Volume of a Hemisphere
                        Console.Write("Enter Radius of Hemisphere (real number >0): ");
                        if (double.TryParse(Console.ReadLine(), out radius))
                        {
                            if (radius > 0)
                            {
                                Console.WriteLine($"\nVolume: {testMathFunctions.HemisphereVolume(radius):F02}\n");
                                break;
                            }
                        }
                        Console.WriteLine("\nInvalid Input!\n");
                        break;
                    case "3":
                        // Option 3: calculate Area of a Triagle
                        Console.Write("Enter length of side 'a' of Triangle (number >0): ");
                        if (uint.TryParse(Console.ReadLine(), out a))
                        {
                            Console.Write("Enter length of side 'b' of Triangle (number >0): ");
                            if (uint.TryParse(Console.ReadLine(), out b))
                            {
                                Console.Write("Enter length of side 'c' of Triangle (number >0): ");
                                if (uint.TryParse(Console.ReadLine(), out c))
                                {
                                    area = testMathFunctions.TriangleArea(a, b, c);
                                    if(area.Equals(double.NaN))
                                    {
                                        Console.WriteLine("\nInvalid Triangle!\n");
                                        break;
                                    }
                                    Console.WriteLine($"\nArea: {area:F02}\n");
                                    break;
                                }
                            }
                        }
                        Console.WriteLine("\nInvalid Input!\n");
                        break;
                    case "4":
                        // Option 4: solve quadratic equation: a*x^2 + b*x + c = 0
                        Console.WriteLine("Solve following quadratic equation: a*x^2 + b*x + c = 0 ");
                        Console.Write("Enter coefficient 'a' (number >0): ");
                        if (uint.TryParse(Console.ReadLine(), out a))
                        { 
                            Console.Write("Enter coefficient 'b' (number >=0): ");
                            if (uint.TryParse(Console.ReadLine(), out b))
                            {
                                Console.Write("Enter coefficient 'c' (number >=0): ");
                                if (uint.TryParse(Console.ReadLine(), out c))
                                {
                                    solutions = testMathFunctions.QuadraticEquationSolver(a, b, c);
                                    if (solutions== null)
                                    {
                                        Console.WriteLine("\nNo Solutions Found!\n");
                                        break;
                                    }
                                    if (solutions.Length == 1)
                                    {
                                        Console.WriteLine($"\nOne Solutions Found: {solutions[0]:F02}\n");
                                        break;
                                    }
                                    Console.WriteLine($"\nTwo Solutions Found: {solutions[0]:F02} and {solutions[1]:F02}\n");
                                    break;
                                }
                            }
                        }
                        Console.WriteLine("\nInvalid Input!\n");
                        break;
                    case "5":
                        // Option 5: Exits program
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
            
        }

        // Calculates the area of circle provied a positive radius
        // returns a double, or NaN if radius is negative
        public double CircleArea(double radius)
        {
            if (radius < 0)
                return double.NaN;

            double area = Math.PI * Math.Pow(radius, 2);

            return area;
        }

        // Calculates the circumference of a circle provied a positive radius
        // returns a double, or NaN if radius is negative
        public double CircleCircumference(double radius)
        {
            if (radius < 0)
                return double.NaN;

            double circumference = 2 * Math.PI * radius;

            return circumference;
        }

        // Calculates the volume of a hemisphere provied a positive radius
        // returns a double, or NaN if radius is negative
        public double HemisphereVolume(double radius)
        {
            if (radius < 0)
                return double.NaN;

            double volume = (2/3.0) * Math.PI * Math.Pow(radius, 3);

            return volume;
        }

        // Calculates the area of a triangle given three positive integer sides
        // returns a double, or NaN for an invalid triangle
        public double TriangleArea(uint sideA, uint sideB, uint sideC)
        {
            // checks triangle validity
            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
                return double.NaN;
            
            // p  is half the circumference
            double p = 0.5 * (sideA + sideB + sideC);

            double area = Math.Sqrt(p * (p - sideA) * (p - sideB) * (p - sideC));

            return area;
        }

        // Find three possible solutions of a quadratic equation given three positive integers
        // a * x^2 + b * x + c = 0
        // Returns an array of double containing 1 or 2 solutions, or null for no solution 
        public double[] QuadraticEquationSolver(uint coefA, uint coefB, uint coefC)
        {
            double expr = Math.Pow(coefB, 2) - (4 * coefA * coefC);

            if (expr < 0 || coefA == 0) // no solution, or not a quadratic equation
                return null;
             else if (expr == 0) // 1 solution
                 { 
                    double x = (-coefB + Math.Sqrt(expr)) / (2 * coefA);
                    return new double[] { x };
                 }
                 else // 2 solutions
                 {
                    double x1 = (-coefB + Math.Sqrt(expr)) / (2 * coefA);
                    double x2 = (-coefB - Math.Sqrt(expr)) / (2 * coefA);
                    return new double[] { x1, x2 };
                 }
        }
    }
}
