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
                        var m = Matrix.Fillredheffer(dimensionality);
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