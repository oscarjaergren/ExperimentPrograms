// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FibonacciSequenceTest.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FibonacciSequenceTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;

using DynamicProgramming;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DynamicProgrammingUnitTest
{
    [TestClass]
    public class FibonacciSequenceTest
    {
        // Testing variables
        // Number is the input value of the methods
        private const long Number = 40;

        // Result is the expected value, i.e the fibonacci of number
        private const long Result = 102334155;

        // Delegate function that takes the other methods and then add the assert values to them
        public void FibonacciTester(Func<long, long> method, string methodName)
        {
            // Benchmark the test to run the test 1000 times
            for (var i = 0; i < 1000; i++)
            {
                // Act
                long returnValue = method(Number);

                // Assert
                long actual = returnValue;
                Assert.AreEqual(actual, Result, $"{methodName} produced wrong result.");
                Debug.WriteLine("Iteration:" + i);
            }
        }

        [TestMethod]
        public void BottomUpFibonacciCalculatorTest()
        {
            FibonacciTester(
                FibonacciSequence.BottomUpFibonacciCalculator,
                nameof(FibonacciSequence.BottomUpFibonacciCalculator));
        }

        [TestMethod]
        public void DynamicFibonacciCalculator2Test()
        {
            FibonacciTester(
                FibonacciSequence.DynamicFibonacciCalculator2,
                nameof(FibonacciSequence.DynamicFibonacciCalculator2));
        }

        [TestMethod]
        public void DynamicFibonacciCalculatorTest()
        {
            FibonacciTester(
                FibonacciSequence.DynamicFibonacciCalculator,
                nameof(FibonacciSequence.DynamicFibonacciCalculator));
        }

        [TestMethod]
        public void EfficientMatrixFibonacciCalculatorTest()
        {
            FibonacciTester(
                FibonacciSequence.EfficientMatrixFibonacciCalculator,
                nameof(FibonacciSequence.EfficientMatrixFibonacciCalculator));
        }

        [TestMethod]
        public void IterativeFibonacciCalculatorTest()
        {
            FibonacciTester(
                FibonacciSequence.IterativeFibonacciCalculator,
                nameof(FibonacciSequence.IterativeFibonacciCalculator));
        }

        [TestMethod]
        public void MatrixFibonacciCalculatorTest()
        {
            FibonacciTester(
                FibonacciSequence.MatrixFibonacciCalculator,
                nameof(FibonacciSequence.MatrixFibonacciCalculator));
        }

        [TestMethod]
        public void PiFibonacciCalculatorTest()
        {
            FibonacciTester(FibonacciSequence.PiFibonacciCalculator, nameof(FibonacciSequence.PiFibonacciCalculator));
        }

        [TestMethod]
        public void RecursiveFibonacciCalculatorTest()
        {
            FibonacciTester(
                FibonacciSequence.RecursiveFibonacciCalculator,
                nameof(FibonacciSequence.RecursiveFibonacciCalculator));
        }
    }
}