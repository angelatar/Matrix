using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    /// <summary>
    /// Implemention of matrix type
    /// </summary>
    //  General part
    public partial class Matrix
    {
        #region Fields region
        /// <summary>
        /// Rows
        /// </summary>
        private int n;

        /// <summary>
        /// Columns
        /// </summary>
        private int m;

        /// <summary>
        /// General matrix
        /// </summary>
        private double[,] matrix;

        #endregion

        #region Property region

        /// <summary>
        /// Number of rows
        /// </summary>
        public int N
        {
            get { return n; }
            private set
            {
                if (value > 0)
                    this.n = value;
                else
                    throw new Exception("N must be > 0.");
            }
        }

        /// <summary>
        /// Number of columns
        /// </summary>
        public int M
        {
            get { return m; }
            private set
            {
                if (value > 0)
                    this.m = value;
                else
                    throw new Exception("M must be > 0.");
            }
        }


        /// <summary>
        /// Indexator
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public double this[int i, int j]
        {
            get
            {
                return this.matrix[i, j];
            }
            set
            {
                    if ((i >= 0 && i < this.N) && (j >= 0 && j < this.M))
                        this.matrix[i, j] = value;
                    else
                        throw new IndexOutOfRangeException();
            }
        }
        #endregion

        #region Ctor region
        /// <summary>
        /// Parameterless constructor, where elements are genereted by user
        /// </summary>
        public Matrix()
        {
            Console.Write("Enter number of row : ");
            this.N = int.Parse(Console.ReadLine());
            Console.Write("Enter number of column : ");
            this.M = int.Parse(Console.ReadLine());
            Console.Write("Enter elements : ");
            this.matrix = new double[this.N, this.M];
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.M; j++)
                {
                    this[i, j] = double.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Constructor with random elements
        /// </summary>
        /// <param name="n"> Number of rows </param>
        /// <param name="m"> Number of columns </param>
        public Matrix(int n,int m)
        {
            this.N = n;
            this.M = m;
            this.matrix = new double[this.N, this.M];
            Random r = new Random();
            for(int i=0;i<this.N;i++)
            {
                for (int j = 0; j < this.M; j++)
                    this.matrix[i, j] = r.Next() % 156;
            }
        }

        /// <summary>
        /// Constructor with 1 parameter
        /// </summary>
        /// <param name="n"> Number of rows </param>
        /// <param name="m"> Number of columns </param>
        public Matrix(double[,] inputMatrix)
        {
            this.N = inputMatrix.GetLength(0);
            this.M = inputMatrix.GetLength(1);
            this.matrix = new double[this.N, this.M];
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.M; j++)
                    this.matrix[i, j] = inputMatrix[i, j];
            }
        }

        /// <summary>
        /// Copy constructor
        /// </summary>
        /// <param name="m"></param>
        public Matrix(Matrix m)
        {
            this.N = m.N;
            this.M = m.M;
            this.matrix = new double[this.N, this.M];
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.M; j++)
                {
                    this.matrix[i, j] = m[i, j];
                }
            }
        }

        #endregion

        #region Operator override region

        /// <summary>
        /// Addition
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public static Matrix operator+(Matrix x1, Matrix x2)
        {
            if(x1.N==x2.N && x1.M==x2.M)
            {
                Matrix temp = new Matrix(x1.N,x1.M);
                for(int i=0;i<x1.N;i++)
                {
                    for(int j=0;j<x2.M;j++)
                    {
                        temp[i, j] = x1[i, j] + x2[i, j];
                    }
                }
                // Return new matrix
                return temp;
            }

            return null;
        }

        /// <summary>
        /// Multiplication matrix by matrix
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public static Matrix operator*(Matrix x1, Matrix x2)
        {
            if (x1.M == x2.N)
            {
                Matrix temp = new Matrix(x1.N, x2.M);
                for (int i = 0; i < temp.N; i++)
                {
                    for (int j = 0; j < temp.M; j++)
                    {
                        temp[i, j] = 0;
                        for (int k = 0; k <x1.M; k++)
                        {
                            temp[i, j] += x1[i,k] * x2[k, j];
                        }
                    }
                }
                // Return new matrix
                return temp;
            }
            Console.WriteLine("Matrix cann't be multiplied!");
            return null;
        }

        /// <summary>
        /// Multiplying matrix by scalar
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public static Matrix operator *(Matrix x1,double x2)
        {
            Matrix temp = new Matrix(x1.N, x1.M);
            for (int i = 0; i < x1.N; i++)
                for (int j = 0; j < x1.M; j++)
                    temp[i,j]=x1[i,j]*x2;
            return temp;
        }

        /// <summary>
        /// Multiplying matrix by scalar (overloading)
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public static Matrix operator *(double x1, Matrix x2)
        {

            return x2*x1;
        }

        /// <summary>
        /// Compare two elements
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public static bool operator==(Matrix x1,Matrix x2)
        {
            if(x1.N==x2.N && x1.M==x2.M)
            {
                for (int i = 0; i < x1.N; i++)
                {
                    for (int j = 0; j < x1.M; j++)
                    {
                        if (x1[i, j] != x2[i, j])
                            return false;
                    }
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Compare two elements
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public static bool operator!=(Matrix x1, Matrix x2)
        {
            return !(x1 == x2);
        }

        #endregion

        #region Object functions region

        /// <summary>
        /// Return string, which introduce instance
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string temp = "";
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.M; j++)
                {
                    temp += this[i, j] + " ";
                }
                temp += '\n';
            }
            return temp;
        }

        /// <summary>
        /// Generate unique hash code
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        /// <summary>
        /// Compare two elements
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj is Matrix)
            {
                return this == ((Matrix)obj);
            }
            return false;
        }

        #endregion

        #region Matrix transformations
        /// <summary>
        /// Scaling point usig matrix
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static double[] Scaling(double[] point1, double[] point2)
        {
            if (point1.Length == 3 && point2.Length == 3)
            {
                // Create identity matrix and insert point2
                Matrix temp = new Matrix(4, 4);
                for (int i = 0; i < temp.N; i++)
                {
                    for (int j = 0; j < temp.M; j++)
                    {
                        if (i == j)
                            if (i == temp.N - 1)
                                temp[i, j] = 1;
                            else
                                temp[i, j] = point2[i];
                        else
                            temp[i, j] = 0;
                    }
                }

                // Create vector 
                Matrix tempV = new Matrix(point1.Length + 1, 1);
                for (int i = 0; i < tempV.N; i++)
                {
                    if (i == tempV.N - 1)
                        tempV[i, 0] = 1;
                    else
                        tempV[i, 0] = point1[i];
                }

                // Create vector, which will be returned
                double[] scaledPoint = new double[point1.Length];
                // Scale point1
                for (int i = 0; i < temp.N - 1; i++)
                {
                    for (int j = 0; j < temp.M; j++)
                    {
                        scaledPoint[i] += temp[i, j] * tempV[i, 0];
                    }
                }
                return scaledPoint;
            }
            Console.WriteLine("Your vector is not 3D.");
            return null;
        }

        /// <summary>
        /// RotatE given Point by given axis by given angle
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="axis"></param>
        /// <param name="angle"></param>
        /// <returns></returns>
        public static double[] Rotate(double[] point1, string axis, double angle)
        {
            if (point1.Length == 3)
            {
                // Calculate angle
                angle *= Math.PI / 180;

                // Create matrix
                Matrix temp = new Matrix(4, 4);
                for (int i = 0; i < temp.N; i++)
                {
                    for (int j = 0; j < temp.M; j++)
                    {
                        if (i == j)
                            temp[i, j] = 1;
                        else
                            temp[i, j] = 0;
                    }
                }

                // Choose axis
                switch (axis)
                {
                    case "x":
                        temp[1, 1] = Math.Cos(angle);
                        temp[1, 2] = -Math.Sin(angle);
                        temp[2, 1] = Math.Sin(angle);
                        temp[2, 2] = Math.Cos(angle);
                        break;
                    case "y":
                        temp[0, 0] = Math.Cos(angle);
                        temp[0, 2] = Math.Sin(angle);
                        temp[2, 0] = -Math.Sin(angle);
                        temp[2, 2] = Math.Cos(angle);
                        break;
                    case "z":
                        temp[0, 0] = Math.Cos(angle);
                        temp[0, 2] = -Math.Sin(angle);
                        temp[1, 0] = Math.Sin(angle);
                        temp[1, 1] = Math.Cos(angle);
                        break;
                }

                // Create vector
                Matrix tempV = new Matrix(point1.Length + 1, 1);
                for (int i = 0; i < tempV.N; i++)
                {
                    if (i == tempV.N - 1)
                        tempV[i, 0] = 1;
                    else
                        tempV[i, 0] = point1[i];
                }

                double[] rotatedPoint = new double[point1.Length];

                // Rotate point
                for (int i = 0; i < rotatedPoint.Length; i++)
                {
                    int ind = 0;
                    for (int j = 0; j < temp.M - 1; j++)
                    {
                        rotatedPoint[i] += temp[i, j] * tempV[ind++, 0];
                    }
                }

                // Return new point
                return rotatedPoint;
            }
            Console.WriteLine("Your vector is not 3D.");
            return null;
        }

        /// <summary>
        /// Translate point using matrix
        /// A translation moves a vector a certain distance in a certain direction.
        /// </summary>
        /// <param name="point1"></param>
        /// <param name="point2"></param>
        /// <returns></returns>
        public static double[] Translate(double[] point1, double[] point2)
        {
            if (point1.Length == 3 && point2.Length == 3)
            {
                // Create identity matrix and insert point 
                Matrix temp = new Matrix(point2.Length + 1, point2.Length + 1);
                for (int i = 0; i < temp.N; i++)
                {
                    for (int j = 0; j < temp.M; j++)
                    {
                        if (i == j)
                            temp[i, j] = 1;
                        else if (j == temp.M - 1)
                            temp[i, j] = point2[i];
                        else
                            temp[i, j] = 0;
                    }
                }

                // Create vector
                double[] tempV = new double[point1.Length + 1];
                for (int i = 0; i < tempV.Length; i++)
                {
                    if (i == tempV.Length - 1)
                        tempV[i] = 1;
                    else
                        tempV[i] = point1[i];
                }

                double[] translatedPoint = new double[point1.Length];

                // Translate point
                for (int i = 0; i < temp.N - 1; i++)
                {
                    translatedPoint[i] = temp[i, temp.M - 1] + tempV[i];
                }

                return translatedPoint;
            }
            Console.WriteLine("Your vector is not 3D.");
            return null;
        }

        #endregion

        #region Function region

        /// <summary>
        /// Transpose matrix
        /// </summary>
        /// <returns></returns>
        public Matrix Transpose()
        {
            Matrix temp = new Matrix(this.M, this.N);
            for (int j = 0; j < this.M; j++)
            {
                for (int i = 0; i < this.N; i++)
                {
                    // Change rows and columns
                    temp[j, i] = this[i, j];
                }
            }
            return temp;
        }

        /// <summary>
        /// Determine whether a matrix is orthogonal or not
        /// </summary>
        /// <returns></returns>
        public bool Orthogonal()
        {
            if (this.M != this.N)
                return false;

            return (this.Transpose()==this.Inverse());
        }

        /// <summary>
        /// Return maximum element in matrix
        /// </summary>
        /// <returns></returns>
        public double Max()
        {
            double temp = this[0, 0];
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.M; j++)
                {
                    if (this[i, j] > temp)
                        temp = this[i, j];
                }
            }
            return temp;
        }

        /// <summary>
        /// Return minimum element in matrix
        /// </summary>
        /// <returns></returns>
        public double Min()
        {
            double temp = this[0, 0];
            for (int i = 0; i < this.N; i++)
            {
                for (int j = 0; j < this.M; j++)
                {
                    if (this[i, j] < temp)
                        temp = this[i, j];
                }
            }
            return temp;
        }

        /// <summary>
        /// Gauss–Jordan elimination 
        /// </summary>
        /// <returns></returns>
        public Matrix InverseGJ()
        {
            if (this.N == this.M && Deteminant(0, this.N, this.matrix)!=0)
            {
                // Create new matrix twice bigger
                Matrix temp = new Matrix(this.N*2, this.M*2);
                for (int i = 0; i < this.N; i++)
                {
                    for (int j = 0; j < this.M; j++)
                    {
                        temp[i, j] = this[i, j];
                    }
                }
                for (int i = 0; i < this.N; i++)
                {
                    for (int j = this.M; j < temp.M; j++)
                    {
                        if (j == i + this.N)
                            temp[i, j] = 1;
                        else
                            temp[i, j] = 0;
                    }
                }

                // Compare and swap elements
                for (int i = this.N-1; i > 1; --i)
                {
                    if (temp[i - 1,1] < temp[i,1])
                    {
                        for (int j = 0; j < temp.M; ++j)
                        {
                            // Swap elements
                            double d = temp[i,j];
                            temp[i,j] = temp[i - 1,j];
                            temp[i - 1,j] = d;
                        }
                    }
                }

                // Divide, multiply and subtract
                for (int i = 0; i < this.N; ++i)
                {
                    for (int j = 0; j < temp.M; ++j)
                    {
                        if (j != i)
                        {
                            double d = temp[j,i] / temp[i,i];
                            for (int k = 0; k < temp.M; ++k)
                            {
                                temp[j,k] -= temp[i,k] * d;
                            }
                        }
                    }
                }

                for (int i = 0; i < this.N; ++i)
                {
                    double d = temp[i,i];
                    for (int j = 0; j < temp.M; ++j)
                    {
                        temp[i,j] = temp[i,j] / d;
                    }
                }

                // Get NxM matrix
                Matrix tempG = new Matrix(this.N, this.M);
                for (int i = 0; i < tempG.N; i++)
                {
                    for (int j = 0; j < tempG.M; j++)
                    {
                        tempG[i, j] = temp[i, j + this.N];
                    }
                }
                return tempG;

            }
            Console.WriteLine("Non invertible matrix");
            return null;
        }
        #endregion
    }
}
