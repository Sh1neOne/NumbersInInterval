using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyMatrices
{
    class Program
    {

        //Используя многопоточность, разработайте алгоритм перемножения матриц большого размера, например: 1 000 * 2 000 * 2 000 * 30 000.
        static void Main(string[] args)
        {
            var stopWatch = Stopwatch.StartNew();
            int mat1Row = 1000, mat1Col = 2000, mat2Row = 2000, mat2Col = 30000;
            var mat1 = GenerateMatrix(mat1Row, mat1Col);
            var mat2 = GenerateMatrix(mat2Row, mat2Col);
            int[,] result = new int[mat1Row, mat2Col];
            MultiplyMatrices(mat1, mat2, result);

            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);
            Console.WriteLine("Время выполнения " + elapsedTime);
            Console.ReadLine();
        }

        /// <summary>
        /// Параллельный Алгоритм умножения матриц
        /// </summary>
        /// <param name="mat1"></param>
        /// <param name="mat2"></param>
        /// <param name="result"></param>
        static void MultiplyMatrices(int [,] mat1, int [,] mat2, int[,] result)
        {
            int mat1Rows = mat1.GetLength(0);
            int mat1Cols = mat1.GetLength(1);
            int mat2Cols = mat2.GetLength(1);

            Parallel.For(0, mat1Rows, i =>
            {
                for (int j = 0; j < mat2Cols; j++)
                {
                    int t = 0;
                    for (int k = 0; k < mat1Cols; k++)
                    {
                        t += mat1[i, k] * mat2[k, j];
                    }
                    result[i, j] = t;
                }
            }); 
        }

        /// <summary>
        /// Алгоритм генерации матрицы, заданной размерности
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public static int[,] GenerateMatrix(int col, int row)
        {
            var arr = new int[col, row];

            for (int k = 0; k < col; k++)
            {
                for (int n = 0; n < row; n++)
                {
                    arr[k, n] = 1;
                }
            }
            return arr;
        }

    }
}
