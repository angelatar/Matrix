using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLib;

namespace MatrixProg
{
    class Program
    {
        static void Main(string[] args)
        {
            //Matrix k = new Matrix();
            //k.Print();
            //Console.WriteLine();
            //Matrix m =new Matrix( k.Inverse());            
            //m.Print();
            //Console.WriteLine();
            //(m * k).Print();

            //double[] x= Matrix.Scaling(new double[] { 2, 6 }, new double[] { 2, 0.5 });
            //Console.WriteLine();
            //for (int i = 0; i < x.Length; i++)
            //{
            //    Console.Write(x[i]+"  ");
            //}
            //Console.WriteLine();

            //double[] y = Matrix.Translate(new double[] { 2, 6 }, new double[] { 4,-3});
            //Console.WriteLine();
            //for (int i = 0; i < y.Length; i++)
            //{
            //    Console.Write(y[i] + "  ");
            //}
            //Console.WriteLine();

            //double[] z = Matrix.Rotate(new double[] { 4,5,6}, "y", 90);
            //Console.WriteLine();
            //for (int i = 0; i < z.Length; i++)
            //{
            //    Console.Write(z[i] + "  ");
            //}
            //Console.WriteLine();

            double[,] d = new double[,] { { 74, 64, 152 }, { 23, 90, 148 }, { 79, 136, 75 } };
            Matrix k = new Matrix(d);
            k.Print();
            Console.WriteLine();
            k.InverseGJ();

            Matrix f = new Matrix(d);
            Console.WriteLine();
            Matrix m = new Matrix(f.Inverse());
            m.Print();
            Console.WriteLine();
        }
    }
}
