using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    // Accidental part of the class
    public partial class Matrix
    {
        /// <summary>
        /// Calculate Determinant
        /// </summary>
        /// <param name="start"></param>
        /// <param name="n"></param>
        /// <param name="mat"></param>
        /// <returns></returns>
        private static double Deteminant(int start,int n, double[,] mat)
        {
            if (n == 2)
            {
                return ((mat[0, 0] * mat[1, 1]) - (mat[1, 0] * mat[0, 1]));
            }
            else
            {
                double d = 0;
                double[,] SubMat = new double[n, n];
                for (int k = start; k < n; k++)
                {
                    int subi = 0;
                    for (int i = 1+start; i < n; i++)
                    {
                        int subj = 0;
                        for (int j = start; j < n; j++)
                        {
                            if (j != k)
                            {
                                SubMat[subi, subj] = mat[i, j];
                                subj++;
                            }
                        }
                        subi++;
                    }
                    d = d + (Math.Pow(-1, k) * mat[0, k] * Deteminant(start,n - 1, SubMat));
                }
                return d;
            }
        }


        // Էս նավսյակի ։Դ
        /// <summary>
        /// Inverse matrix
        /// </summary>
        /// <returns></returns>
        public Matrix Inverse()
        {
            if (this.N == this.M && Deteminant(0, this.N, this.matrix)!=0)
            {
                Matrix temp = new Matrix(this.N, this.M);
                double det = Deteminant(0, this.N, this.matrix);
                for (int i = 0; i < this.N; i++)
                {
                    for (int j = 0; j < this.M; j++)
                    {
                        double[,] tempM = new double[this.N - 1, this.M - 1];
                        int tempI = 0, tempJ = 0;
                        for (int k = 0; k < this.N; k++)
                        {
                            if (k != i)
                            {
                                for (int f = 0; f < this.M; f++)
                                {
                                    if (f != j)
                                    {
                                        tempM[tempI, tempJ] = this[k, f];
                                        tempJ++;
                                    }
                                }
                                tempI++;
                                tempJ = 0;
                            }
                        }
                        temp[j, i] = Math.Pow(-1, (i + j)) * Deteminant(0, this.N - 1, tempM);
                    }
                }
                return temp * (1 / det);
            }
            Console.WriteLine("Non invertible matrix");
            return null;
        }

        /// <summary>
        /// Print matrix
        /// </summary>
        public void Print()
        {
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.M; j++)
                {
                    Console.Write(this[i,j]+"  ");
                }
                Console.WriteLine();
            }
        }
    }
}
