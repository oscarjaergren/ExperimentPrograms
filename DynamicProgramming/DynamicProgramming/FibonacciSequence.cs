// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FibonacciSequence.cs" company="">
//   
// </copyright>
// <summary>
//   Defines the FibonacciSequence type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace DynamicProgramming
{
    public static class FibonacciSequence
    {
        #region MatrixFibonnaciCalculator

        public static long MatrixFibonacciCalculator(long n)
        {
            long[,] f = { { 1, 1 }, { 1, 0 } };
            if (n == 0)
                return 0;
            PowerMatrix1(f, n - 1);

            return f[0, 0];
        }

        /* Helper function that multiplies 2  
        matrices F and M of size 2*2, and puts 
        the multiplication result back to F[][] */
        private static void MultiplyMatrix1(long[,] F, long[,] M)
        {
            long x = F[0, 0] * M[0, 0] + F[0, 1] * M[1, 0];
            long y = F[0, 0] * M[0, 1] + F[0, 1] * M[1, 1];
            long z = F[1, 0] * M[0, 0] + F[1, 1] * M[1, 0];
            long w = F[1, 0] * M[0, 1] + F[1, 1] * M[1, 1];

            F[0, 0] = x;
            F[0, 1] = y;
            F[1, 0] = z;
            F[1, 1] = w;
        }

        /* Helper function that calculates F[][]  
        raise to the power n and puts the result 
        in F[][] Note that this function is designed 
        only for fib() and won't work as general 
        power function */
        private static void PowerMatrix1(long[,] F, long n)
        {
            long i;
            var M = new long[,] { { 1, 1 }, { 1, 0 } };

            // n - 1 times multiply the matrix to 
            // {{1,0},{0,1}} 
            for (i = 2; i <= n; i++)
                MultiplyMatrix1(F, M);
        }

        #endregion

        #region EfficentMatrixFibonacciCalculator

        public static long EfficientMatrixFibonacciCalculator(long n)
        {
            var f = new long[,] { { 1, 1 }, { 1, 0 } };
            if (n == 0)
                return 0;
            EfficientPowerMatrix(f, n - 1);

            return f[0, 0];
        }

        private static void EfficientPowerMatrix(long[,] F, long n)
        {
            if (n == 0 || n == 1)
                return;
            var M = new long[,] { { 1, 1 }, { 1, 0 } };

            EfficientPowerMatrix(F, n / 2);
            EfficientMultiplyMatrix(F, F);

            if (n % 2 != 0)
                EfficientMultiplyMatrix(F, M);
        }

        private static void EfficientMultiplyMatrix(long[,] f, long[,] m)
        {
            long x = f[0, 0] * m[0, 0] + f[0, 1] * m[1, 0];
            long y = f[0, 0] * m[0, 1] + f[0, 1] * m[1, 1];
            long z = f[1, 0] * m[0, 0] + f[1, 1] * m[1, 0];
            long w = f[1, 0] * m[0, 1] + f[1, 1] * m[1, 1];

            f[0, 0] = x;
            f[0, 1] = y;
            f[1, 0] = z;
            f[1, 1] = w;
        }

        #endregion

        public static long IterativeFibonacciCalculator(long number)
        {
            long firstNumber = 0, secondNumber = 1, result = 0;

            if (number == 0) return 0; // To return the first Fibonacci number   
            if (number == 1) return 1; // To return the second Fibonacci number   

            for (var i = 2; i <= number; i++)
            {
                result = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = result;
            }

            return result;
        }

        public static long RecursiveFibonacciCalculator(long number)
        {
            if (number <= 1)
            {
                return number;
            }

            return RecursiveFibonacciCalculator(number - 1) + RecursiveFibonacciCalculator(number - 2);
        }

        public static long DynamicFibonacciCalculator(long number)
        {
            if (number <= 1)
            {
                return number;
            }

            long[] memoArrays = new long[number + 1];
            long result = Recursion(number);

            // Local Function to do the recursion in
            long Recursion(long num)
            {
                if (num <= 1)
                {
                    return num;
                }

                if (memoArrays[num] != 0)
                {
                    return memoArrays[num];
                }

                return Recursion(number);
            }

            return result;
        }

        public static long DynamicFibonacciCalculator2(long n)
        {
            // Declare an array to  
            // store Fibonacci numbers. 
            // 1 extra to handle  
            // case, n = 0 
            var f = new long[n + 2];
            long i;

            /* 0th and 1st number of the  
               series are 0 and 1 */
            f[0] = 0;
            f[1] = 1;

            for (i = 2; i <= n; i++)
                /* Add the previous 2 numbers 
                                       in the series and store it */
                f[i] = f[i - 1] + f[i - 2];

            return f[n];
        }

        // Helper method for PiCalculator
        public static long PiFibonacciCalculator(long n)
        {
            double phi = (1 + Math.Sqrt(5)) / 2;
            return (long)Math.Round(Math.Pow(phi, n) / Math.Sqrt(5));
        }



        public static long BottomUpFibonacciCalculator(long n)
        {
            long a = 0, b = 1;

            // To return the first Fibonacci number  
            if (n == 0) return a;

            for (long i = 2; i <= n; i++)
            {
                long c = a + b;
                a = b;
                b = c;
            }

            return b;
        }
    }
}