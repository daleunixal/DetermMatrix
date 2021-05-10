using System;

namespace DetermMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            
                Console.WriteLine("1. Вычислить определитель именной матрицы Редхеффера");
                Console.WriteLine("2. Решить квадратную систему линейных уравнений методом Крамера");
                var state = Convert.ToInt32(Console.ReadLine());
                switch (state)
                {
                    case 1:
                    {
                        Console.WriteLine("Введите размерность матрицы");
                        var dimensionality = Convert.ToInt32(Console.ReadLine());
                        var m = new double[dimensionality, dimensionality];
                        for (var i = 0; i < dimensionality; i++)
                        for (var j = 0; j < dimensionality; j++)
                        {
                            var x = i + 1;
                            var y = j + 1;
                            if (y % x == 0 || j==0) m[i, j] = 1;                                               
                            else m[i, j] = 0;
                        }
                        var determinant = Matrix.GetDeterminant(m);
                        Console.WriteLine("Определитель матрицы - " + determinant);
                        Console.Read();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine("Введите количество переменных");
                        var length = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введите уравнения, после каждого нажимая enter");
                        var strings = new string[length];
                        for (var i = 0;i < length; i++)
                        {
                            strings[i] = Console.ReadLine();
                        }
                        Matrix.ParseMatrix(strings);
                        Console.Read();
                        break;
                    }
                
            }
        }
    }
}