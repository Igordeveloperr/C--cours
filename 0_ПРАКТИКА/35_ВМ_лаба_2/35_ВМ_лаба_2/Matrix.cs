﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _35_ВМ_лаба_2
{
    public class Matrix
    {
        static Random rnd = new Random();

        public double[,] array;
        int row, column;

        public int Row { get { return row; } }
        public int Column { get { return column; } }

        public void Fill(double[,] data)
        {
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    array[i, j] = data[i,j];
                }
            }
        }

        public void Print()
        {
            for(int i = 0; i < row; i++)
            {
                string line = string.Empty;
                for(int j = 0; j < column; j++)
                {
                    line += $" {array[i,j]} ";
                }
                Console.WriteLine(line);
            }
        }

        public Matrix(int row, int colunm)
        {
            this.row = row;
            this.column = colunm;
            array = new double[row, column];
        }

        public Matrix Transpose()
        {
            Matrix m = new Matrix(column, row);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    m.array[j, i] = array[i, j];
                }
            }

            return m;
        }

        public void TransposeMyself()
        {
            array = Transpose().array;
        }

        public Matrix Inverse()
        {
            double det = Determinant();
            if (det == 0)
            {
                throw new Exception("Матрица вырождена");
            }

            Matrix m = new Matrix(row, column);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    m.array[i, j] = Cofactor(array, i, j) / det;
                }
            }

            return m.Transpose();
        }

        public double Determinant()
        {
            if (column != row)
            {
                throw new Exception("Расчет определителя невозможен");
            }
            return Determinant(array);
        }

        private double Determinant(double[,] array)
        {
            int n = (int)Math.Sqrt(array.Length);

            if (n == 1)
            {
                return array[0, 0];
            }

            double det = 0;

            for (int k = 0; k < n; k++)
            {
                det += array[0, k] * Cofactor(array, 0, k);
            }

            return det;
        }

        private double Cofactor(double[,] array, int row, int column)
        {
            return (Math.Pow(-1, column + row)) * Determinant(Minor(array, row, column));
        }

        private double[,] Minor(double[,] array, int row, int column)
        {
            int n = (int)Math.Sqrt(array.Length);
            double[,] minor = new double[n - 1, n - 1];

            int _i = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == row)
                {
                    continue;
                }
                int _j = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == column)
                    {
                        continue;
                    }
                    minor[_i, _j] = array[i, j];
                    _j++;
                }
                _i++;
            }
            return minor;
        }

        public static Matrix operator +(Matrix m1, Matrix m2)
        {
            if (m1.row != m2.row || m1.column != m2.column)
            {
                throw new Exception("Сложение невозможно");
            }

            Matrix m = new Matrix(m1.row, m1.column);

            for (int i = 0; i < m1.row; i++)
            {
                for (int j = 0; j < m1.column; j++)
                {
                    m.array[i, j] = Math.Round(m1.array[i, j] + m2.array[i, j], 4);
                }
            }

            return m;
        }

        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            if (m1.row != m2.row || m1.column != m2.column)
            {
                throw new Exception("Вычитание невозможно");
            }

            Matrix m = new Matrix(m1.row, m1.column);

            for (int i = 0; i < m1.row; i++)
            {
                for (int j = 0; j < m1.column; j++)
                {
                    m.array[i, j] = m1.array[i, j] - m2.array[i, j];
                }
            }

            return m;
        }

        public static Matrix operator *(Matrix m1, Matrix m2)
        {
            if (m1.column != m2.row)
            {
                throw new Exception("Умножение невозможно");
            }

            Matrix m = new Matrix(m1.row, m2.column);

            for (int i = 0; i < m1.row; i++)
            {
                for (int j = 0; j < m2.column; j++)
                {
                    double sum = 0;

                    for (int k = 0; k < m1.column; k++)
                    {
                        sum += m1.array[i, k] * m2.array[k, j];
                    }

                    m.array[i, j] = sum;
                }
            }

            return m;
        }

        public static Matrix operator *(Matrix m1, double k)
        {
            Matrix m = new Matrix(m1.row, m1.column);

            for (int i = 0; i < m.row; i++)
            {
                for (int j = 0; j < m.column; j++)
                {
                    m.array[i, j] = m1.array[i, j] * k;
                }
            }

            return m;
        }

        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    str += array[i, j] + "\t";
                }
                str += "\n";
            }

            return str;
        }
    }
}
