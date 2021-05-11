using System;

namespace DetermMatrix
{
    public class Matrix
    {
        public static double[] result;
        
        
        public static double GetDeterminant(double[,] matrix)
        {
            if (matrix.GetLength(0) != matrix.GetLength(1))
                throw new ArgumentException("Matrix isn't square");
            double determinant = 0;
            var length = matrix.GetLength(0);
            switch (length)
            {
                case 1:
                    return matrix[0, 0];
                
                case 2:
                    return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
                
                case > 2:
                {
                    for (var j = 0; j < matrix.GetLength(1); j++)
                    {
                        determinant += Math.Pow(-1, 0 + j) * matrix[0, j] * GetDeterminant(GetMinor(matrix, 0, j));
                    }
                    break;
                }
                
                default:
                    throw new OverflowException("Memory collision, array have negative length");
            }

            return determinant;
        }
        
        public static double[,] GetMinor(double[,] matrix, int row, int column)
        {
            var dimensionality = matrix.GetLength(0);
            var minor = new double[dimensionality - 1, dimensionality - 1];
            for (var i = 0; i < dimensionality; i++)
            for (var j = 0; j < dimensionality; j++)
            {
                if ((i == row) && (j == column))
                    continue;
                if (i > row && j < column)
                    minor[i - 1, j] = matrix[i, j];
                if (i < row && j > column)
                    minor[i, j - 1] = matrix[i, j];
                if (i > row && j > column) 
                    minor[i - 1, j - 1] = matrix[i, j];
                if (i < row && j < column)
                    minor[i, j] = matrix[i, j];
            }
            return minor;
        }
        
        public static void ParseMatrix(string[] input)
        {
            double num;
            var n = input.Length;
            var matrix = new double[n, n];
            var b = new double[n];
            var x = new double[n];
            var state = true;
            for (var i = 0; i < n; i++)
            {
                var j = 0;
                var s = input[i].Split('=');
                b[i] = Convert.ToDouble(s[1]);
                foreach(var item in s[0])
                {
                    if (item == '-') state = false;
                    if (!double.TryParse(item.ToString(), out num)) continue;
                    if (state)
                        matrix[i, j] = Convert.ToDouble(item.ToString());
                    else
                    {
                        matrix[i, j] = -Convert.ToDouble(item.ToString());
                        state = true;
                    }                             
                    j++;
                }
            }
            if (SoLAECramerRule(n, matrix, b, x) == 1)
            {
                Console.WriteLine("System have infinity solutions");
                Console.Read();
                return;
            }

            for (var i = 0; i < n; i++)
                Console.WriteLine("x" + i + " = " + result[i]);
            Console.Read();
        }
        public static int SoLAECramerRule(int n, double[,] A, double[] b, double[] x)
        {
            var matrix = new double[n, n];
            var determinant = GetDeterminant(A);
            if (determinant == 0) return 1;
            for (var i = 0; i < n; i++)
            {
                Equal(n, matrix, A);
                SwapColumn(n, i, matrix, b);
                x[i] = GetDeterminant(matrix) / determinant;
            }
            result = x;
            return 0;
        }
        static void Equal(int n, double[,] A, double[,] B)
        {
            for (var i = 0; i < n; i++)
            for (var j = 0; j < n; j++)
                A[i, j] = B[i, j];
        }
        static void SwapColumn(int n, int N, double[,] A, double[] b)
        {
            for (var i = 0; i < n; i++)
                A[i, N] = b[i];
        }
        
        public static double[,] Fillredheffer(int dimensionality)
        {
            var m = new double[dimensionality, dimensionality];
            for (var i = 0; i < dimensionality; i++)
            for (var j = 0; j < dimensionality; j++)
            {
                var x = i + 1;
                var y = j + 1;
                if (y % x == 0 || j == 0) m[i, j] = 1;
                else m[i, j] = 0;
            }

            return m;
        }
    }
}