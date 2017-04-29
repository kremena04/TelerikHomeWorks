using System;
using System.Text;

namespace WalkInMatrix
{
    public class Matrix
    {
        private const int MinLength = 1;
        private const int MaxLength = 100;
        private int size;
        private int[,] matrix;

        public Matrix(int size)
        {
            this.Size = size;
            this.matrix = new int[this.Size, this.Size];
            this.FillMatrix();
        }

        public int Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < MinLength || value > MaxLength)
                {
                    throw new ArgumentOutOfRangeException("Matrix lenght must be between 1 and 100");
                }

                this.size = value;
            }
        }

        public void FillMatrix()
        {
            int cellValue = 1;
            int row = 0;
            int col = 0;
            int directionX = 1;
            int directionY = 1;
            while (true)
            {
                this.matrix[row, col] = cellValue;
                if (!MatrixMethods.AreNeighbourCellsEmpty(this.matrix, row, col))
                {
                    MatrixMethods.FindNextEmptyCell(this.matrix, out row, out col);
                    if (row != 0 && col != 0)
                    {
                        directionX = 1;
                        directionY = 1;
                        cellValue++;
                        this.matrix[row, col] = cellValue;
                    }
                    else
                    {
                        break;
                    }
                }

                if (!MatrixMethods.IsInRange(this.matrix, row + directionX) ||
                    !MatrixMethods.IsInRange(this.matrix, col + directionY) ||
                    this.matrix[row + directionX, col + directionY] != 0)
                {
                    while (!MatrixMethods.IsInRange(this.matrix, row + directionX) ||
                            !MatrixMethods.IsInRange(this.matrix, col + directionY) ||
                            this.matrix[row + directionX, col + directionY] != 0)
                    {
                        MatrixMethods.GetNextDirection(ref directionX, ref directionY);
                    }
                }

                row += directionX;
                col += directionY;
                cellValue++;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(0); col++)
                {
                    result.Append(string.Format("{0,3}", this.matrix[row, col]));
                }

                result.Append(Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
