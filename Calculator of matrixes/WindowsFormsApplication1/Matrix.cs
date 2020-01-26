using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Matrix
    {
        public float[,] matrix = null;

        public int CountColumn { get; private set; } // зчитування строки
        public int CountRow { get; private set; } // зчитування рядків
        public Matrix(int x = 1, int y = 1)
        {
            matrix = new float[x, y];

            CountColumn = y;
            CountRow = x;
        }

        public Matrix(Matrix matrix_1_0)
        {
            this.matrix = matrix_1_0.matrix;
            this.CountColumn = matrix_1_0.CountColumn;
            this.CountRow = matrix_1_0.CountRow;
        }
       
        

         float GetM(float[][] Matrix)
        {
            float Returning;
            if (Matrix.Length == 2)
            {
                Returning = Matrix[0][0] * Matrix[1][1] - Matrix[0][1] * Matrix[1][0];
            }
            else
            {
                float[][] Minor = new float[Matrix.Length - 1][]; //мінор, але можливо, що це матриця n-ого порядку
                int i, j, k;
                short Minus = 1;
                float Temp;
                Returning = 0;

                for (i = 0; i < Matrix.Length; i++)
                {
                    for (j = 1; j < Matrix.Length; j++) //зберігаю значення для "можливо" мінора
                    {
                        Minor[j - 1] = new float[Matrix.Length - 1];
                        for (k = 0; k < i; k++) //значення до діагоналі
                            Minor[j - 1][k] = Matrix[j][k];

                        for (k++; k < Matrix.Length; k++)   //значення після діагоналі
                            Minor[j - 1][k - 1] = Matrix[j][k];
                    }

                    Temp = GetM(Minor);
                    Temp = Matrix[0][i] * Minus * Temp;
                    Returning += Temp;

                    if (Minus > 0)  //змінюю знак, згідно з правилами
                        Minus = -1;
                    else
                        Minus = 1;
                }
            }

            return Returning;
        }

         static T[][] ToJag<T>(T[,] source)
         {
             try
             {
                 int FirstDim = source.GetLength(0);  // Row
                 int SecondDim = source.GetLength(1); // Column

                 var result = new T[FirstDim][];   // тільки прийнятний синтаксис ???
                 for (int i = 0; i < FirstDim; ++i)
                 {
                     result[i] = new T[source.GetLength(1)];  // тільки для рядків
                     for (int j = 0; j < SecondDim; ++j)
                     {
                         result[i][j] = source[i, j];
                     }
                 }

                 return result;
             }
             catch (InvalidOperationException)
             {
                 throw new InvalidOperationException("Invalid operation error.");
             }
         }

        public Matrix Opr() //Метод знаходження визначника матриці
        {
            Matrix t = new Matrix();
            t[0, 0] = GetM(ToJag<float>(this.matrix));
            return t;
        }

         public float this[int x, int y]
        {
            get { return matrix[x, y]; }
            set { matrix[x, y] = value; }
        }
        public override string ToString()
        {
            StringBuilder ret = new StringBuilder();
            if (matrix == null) return ret.ToString();

            for (int i = 0; i < CountRow; i++)
            {
                for (int t = 0; t < CountColumn; t++)
                {
                    ret.Append(matrix[i, t]);
                    ret.Append(" ");
                }
                ret.Append("\n");
            }
            return ret.ToString();
        }

        public static Matrix operator +(Matrix matrix1, Matrix matrix2) // Метод додавання матриць
        {
            Matrix t = new Matrix(matrix1.CountRow, matrix1.CountColumn);
            for (int y = 0; y < matrix1.CountRow; y++)
            {
                for (int x = 0; x <matrix1.CountColumn ; x++)
                {
                    t[y, x] = matrix1[y, x] + matrix2[y, x];
                }
            }
            return t;
        }

        public static Matrix operator -(Matrix matrix_1, Matrix matrix_2) // Метод віднімання матриць
        {
            Matrix N = new Matrix(matrix_1.CountRow, matrix_1.CountColumn);
            for (int y = 0; y < matrix_1.CountRow; y++)
            {
                for (int x = 0; x < matrix_1.CountColumn; x++)
                {
                    N[y, x] = (matrix_1[y, x] - matrix_2[y, x]) * -1;
                }
            }
            return N;
        }

        public static Matrix operator *(Matrix matrix_10, Matrix matrix_20) // Метод множення матриць
        {
            Matrix M = new Matrix(matrix_10.CountRow, matrix_10.CountColumn);
            for (int y = 0; y < matrix_10.CountRow; y++)
            {
                for (int x = 0; x < matrix_10.CountColumn; x++)
                {
                    for( int j = 0; j < matrix_10.CountRow && j < matrix_10.CountColumn; j++)
                        M[y, x] += matrix_10[y, j] * matrix_20[j, x];
                }
            }
            return M;
        }
        
        public static Matrix operator ^(Matrix matrix_1_0, Matrix matrix_2_0) // Метод піднесення до n-го степеня матриці
        {
 
            Matrix M = new Matrix(matrix_1_0);
       
            for (int y = 1; y < matrix_2_0[0,0]; y++)
            {
                M = M * matrix_1_0;
            }
            return M;
          
        }
    }
}
 /* public void Transp() //Метод транспонирования матрицы
        {
            for (int j = 0; j < CountRow; j++)
            {
                for (int i = 0; i < CountColumn; i++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
         }
*/