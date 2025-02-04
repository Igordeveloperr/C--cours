﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_ВМ_лаба_2
{
    internal class InverseMatrixMethod
    {
        private double[,] arrayA, arrayB, lambdaArray;
        private double _detA;
        private Matrix A, ATransponse, LambdATransponse, B;
        public InverseMatrixMethod()
        {
            Setup();
        }

        public void PrintInfo()
        {
            Console.WriteLine("МЕТОД ОБРАТНОЙ МАТРИЦЫ");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Исходная система:");
            Console.WriteLine("x1 + 3*x2 + 8*x3 = 10");
            Console.WriteLine("8*x1 + 6*x2 + 4*x3 = 2");
            Console.WriteLine("2*x1 + 5*x2 + 7*x3 = 10");
            Console.WriteLine("Матрица алгебраических дополнений:");
            LambdATransponse.Print();
        }

        // находим корни
        public void CalcRoot()
        {
            double x1, x2, x3;
            Matrix inverseMatrix = CalcInverseMatrix();
            Console.WriteLine("Обратная матрица:");
            inverseMatrix.Print();
            Matrix X = inverseMatrix * B;
            x1 = Math.Round(X.array[0, 0], 4);
            x2 = Math.Round(X.array[1, 0], 4);
            x3 = Math.Round(X.array[2, 0], 4);
            Console.WriteLine($"Ответ: x1 = {x1} x2 = {x2} x3 = {x3}");
        }
        // вычисляем обратную матрицу
        private Matrix CalcInverseMatrix()
        {
            Matrix res = (LambdATransponse * (1 / _detA));
            return res.Transpose();
        }

        // предрасчет
        private void Setup()
        {
            arrayA = new double[3, 3]
            {
                { 1,3,8 },
                { 8,6,4 },
                { 2,5,7 }
            };

            arrayB = new double[3, 1]
            {
                { 10 },
                { 2 },
                { 10 }
            };

            lambdaArray = new double[3, 3]
            {
                { 22,-48,28 },
                { 19,-9,1 },
                { -36,60,-18 }
            };

            A = new Matrix(3, 3);
            A.Fill(arrayA);

            B = new Matrix(3, 1);
            B.Fill(arrayB);

            _detA = A.Determinant();
            ATransponse = A.Transpose();

            LambdATransponse = new Matrix(3, 3);
            LambdATransponse.Fill(lambdaArray);
        }
    }
}
