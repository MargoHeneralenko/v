using System;
using System.Data;

namespace MatrixLibrary
{

    public class MatrixException : Exception
    {
        public MatrixException()
        {
            
        }
    }
    
    public class Matrix : ICloneable
    {
        private readonly int rows;
        private readonly int columns;
        private readonly double [,] array;
        /// <summary>
        /// Number of rows.
        /// </summary>
        public int Rows
        {
            get => rows;
        }

        /// <summary>
        /// Number of columns.
        /// </summary>
        public int Columns
        {
            get => columns;
        }
        
        /// <summary>
        /// Gets an array of floating-point values that represents the elements of this Matrix.
        /// </summary>
        public double[,] Array
        {
            get => array ;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class.
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Matrix(int rows, int columns)
        {
            if (rows <= 0 || columns <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rows), "Value must be greater than zero");
            }
            this.rows = rows;
            this.columns = columns;
            this.array = new double[rows, columns];
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Matrix"/> class with the specified elements.
        /// </summary>
        /// <param name="array">An array of floating-point values that represents the elements of this Matrix.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Matrix(double[,] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "cannot be null");
            }
            rows = array.GetLength(0);
            columns = array.GetLength(1);
            this.array = array;
            

        }

        /// <summary>
        /// Allows instances of a Matrix to be indexed just like arrays.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <exception cref="ArgumentException"></exception>
        public double this[int row, int column]
        {
            get
            {
                if (row < 0 || row >= this.rows || column < 0 || column >= this.columns)
                {
                    throw new ArgumentException("");
                }
                return array[row, column];
            }
            set
            {
                if (row < 0 || row >= this.rows || column < 0 || column >= this.columns)
                {
                    throw new ArgumentException("");
                }
                array[row, column] = value;
            }
        }


        /// <summary>
        /// Adds two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is sum of two matrices.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException(nameof(matrix1), "The value cannot be null");
            }

            if (matrix1.Rows <= 0 || matrix1.Columns <= 0 || matrix2.Rows <= 0 || matrix2.Columns <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(matrix1), "Value cannot be negative");
            }

            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new MatrixException();
            }

            double [,] result = new double[matrix1.Rows, matrix1.Columns];

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    result[i, j] = matrix1[i,j] + matrix2[i, j];
                }
            }

            return new Matrix (result);
        }

        /// <summary>
        /// Creates a deep copy of this Matrix.
        /// </summary>
        /// <returns>A deep copy of the current object.</returns>
        public object Clone()
        {
            Matrix clone = new Matrix(this.rows, this.columns);
            
            for (int i = 0; i < this.rows; i++)
            {
                for (int j = 0; j < this.columns; j++)
                {
                    clone[i, j] = this[i, j];
                }
            }

            return clone;
           
        }

        /// <summary>
        /// Subtracts two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is subtraction of two matrices</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException(nameof(matrix1), "The value cannot be null");
            }

            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                throw new MatrixException();
            }

            Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {
                    result[i, j] = matrix1[i,j] - matrix2[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies two matrices.
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns>New <see cref="Matrix"/> object which is multiplication of two matrices.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1 == null || matrix2 == null)
            {
                throw new ArgumentNullException(nameof(matrix1),"The value cannot be null");
            }

            if (matrix1.Columns != matrix2.Rows)
            {
                throw new MatrixException();
            }

            Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {
                    result[i,j] = 0;
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        result[i,j] += matrix1[i, k] * matrix2[k, j];
                    }
                }
            }
           
            return result;
        }

        /// <summary>
        /// Adds <see cref="Matrix"/> to the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for adding.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Add(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix), "The value cannot be null");
            }

            if (this.Rows != matrix.Rows || this.Columns != matrix.Columns)
            {
                throw new MatrixException();
            }

            Matrix result = new Matrix(Rows, Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result[i, j] = this[i, j] + matrix[i, j];
                }
            }

            return result;


        }

        /// <summary>
        /// Subtracts <see cref="Matrix"/> from the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for subtracting.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Subtract(Matrix matrix)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException(nameof(matrix), "The value cannot be null");
            }

            if (this.Rows != matrix.Rows || this.Columns != matrix.Columns)
            {
                throw new MatrixException();
            }

            Matrix result = new Matrix(this.Rows, this.Columns);

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    result[i, j] = this[i, j] - matrix[i, j];
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies <see cref="Matrix"/> on the current matrix.
        /// </summary>
        /// <param name="matrix"><see cref="Matrix"/> for multiplying.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="MatrixException"></exception>
        public Matrix Multiply(Matrix matrix)
        {
            if (matrix == null) throw new ArgumentNullException(nameof(matrix), "Value cannot be null");

            if (this.Columns != matrix.Rows) throw new MatrixException();
            
            
            Matrix result = new Matrix(this.Rows, this.Columns);

            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < this.Columns; k++)
                    {
                        result[i,j] += this[i, k] * matrix[k, j];
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Tests if <see cref="Matrix"/> is identical to this Matrix.
        /// </summary>
        /// <param name="obj">Object to compare with. (Can be null)</param>
        /// <returns>True if matrices are equal, false if are not equal.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Matrix))
            {
                return false;
            }

            Matrix other = (Matrix)obj;
            
            
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    if (this[i, j] != other[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public override int GetHashCode() => GetHashCode();
    }
}
