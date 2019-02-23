using Microsoft.VisualStudio.TestTools.UnitTesting;
using MathFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathFunctions.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        private Program testMathFuntions = new Program();

        [TestMethod()]
        public void CircleAreaTest()
        {
            // test with negative radius
            Assert.AreEqual(double.NaN, testMathFuntions.CircleArea(-1));
            // test with zero
            Assert.AreEqual(0,testMathFuntions.CircleArea(0));
            // test with one
            Assert.AreEqual(Math.PI, testMathFuntions.CircleArea(1), 0.01);
        }

        [TestMethod()]
        public void CircleCircumferenceTest()
        {
            // test with negative radius
            Assert.AreEqual(double.NaN, testMathFuntions.CircleCircumference(-1));
            
            // test with zero
            Assert.AreEqual(0, testMathFuntions.CircleCircumference(0));
            
            // test with one
            Assert.AreEqual(6.28, testMathFuntions.CircleCircumference(1), 0.01);
        }

        [TestMethod()]
        public void HemisphereVolumeTest()
        {
            // test with negative radius
            Assert.AreEqual(double.NaN, testMathFuntions.HemisphereVolume(-1));
            
            // test with zero
            Assert.AreEqual(0, testMathFuntions.HemisphereVolume(0));
            
            // test with one
            Assert.AreEqual(2.09, testMathFuntions.HemisphereVolume(1), 0.01);
        }

        [TestMethod()]
        public void TriangleAreaTest()
        {
            // test with all side null
            Assert.AreEqual(double.NaN, testMathFuntions.TriangleArea(0,0,0));
            
            // test with invalid triangle
            Assert.AreEqual(double.NaN, testMathFuntions.TriangleArea(1,2,3));
            
            // test with all sides one
            Assert.AreEqual(0.43, testMathFuntions.TriangleArea(1,1,1), 0.01);
        }

        [TestMethod()]
        public void QuadraticEquationSolverTest()
        {
            // test with coef a null (not a quadratic eq)
            CollectionAssert.AreEquivalent(null, testMathFuntions.QuadraticEquationSolver(0, 1, 1));
            CollectionAssert.AreEquivalent(null, testMathFuntions.QuadraticEquationSolver(0, 0, 1));
            CollectionAssert.AreEquivalent(null, testMathFuntions.QuadraticEquationSolver(0, 0, 0));

            // test with coef b null (no real solution)
            CollectionAssert.AreEquivalent(null, testMathFuntions.QuadraticEquationSolver(1, 0, 1));

            // test with coef c null
            CollectionAssert.AreEquivalent(new double[] { 0, -1 }, testMathFuntions.QuadraticEquationSolver(1, 1, 0));

            // test with coef b and c null
            CollectionAssert.AreEquivalent(new double[] { 0 }, testMathFuntions.QuadraticEquationSolver(1, 0, 0));

            // test with all coefs >0, no real solution 
            CollectionAssert.AreEquivalent(null , testMathFuntions.QuadraticEquationSolver(1, 1, 1));

            // test with duplicate valid solution - should return a single solution
            CollectionAssert.AreEquivalent(new double[] { -1 }, testMathFuntions.QuadraticEquationSolver(1, 2, 1));

            // test with two distinct valid solution - should return a two solution (no delta needed)
            CollectionAssert.AreEquivalent(new double[] { -1, -1.5 }, testMathFuntions.QuadraticEquationSolver(2, 5, 3));

            // test with two distinct valid solution - should return a two solution (delta needed)
            double[] solutions =  testMathFuntions.QuadraticEquationSolver(2, 6, 3);
            Assert.AreEqual(-0.63, solutions[0], 0.01);
            Assert.AreEqual(-2.37, solutions[1], 0.01);
        }
    }
}