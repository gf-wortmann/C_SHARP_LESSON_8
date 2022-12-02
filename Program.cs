//Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
//Например, даны 2 матрицы:
//2 4 | 3 4
//3 2 | 3 3
//Результирующая матрица будет:
//18 20
//15 18


int [,] MultiplyMatrices (int [,] A, int [,] B)
{
    int rowsInA = A.GetUpperBound(0)+1;
    int columnsInA = A.Length / rowsInA;
    int rowsInB = B.GetUpperBound(0)+1;
    int columnsInB = B.Length / rowsInB;
    int [,] result = new int [rowsInA, columnsInB];
    if (columnsInA != rowsInB) return (FillArray (rowsInA, columnsInB, 0, 0));
    
    for (int i = 0; i < rowsInA; i++ )
    {
        for (int j = 0; j < columnsInB; j++)
        {
            for (int r = 0; r < columnsInA; r++)
            {
                result [i, j] += (A [i,r] * B[r, j]);
            }
        }

    }
    return result;
}

int [,] FillArray (int rows, int columns, int min, int max) 
{
    int [,] result = new int [rows, columns];
    Random k = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
           result [i,j] = k.Next(min+1, max);
        }
    }
    return result;
}

void WriteArray2D ( int [,] Array)
{
    int rows = Array.GetUpperBound(0)+1;
    int columns = Array.Length / rows;
    
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            string c = (Array[i,j] > 0) ? " " : "";
            Console.Write($"\t{c}{Array [i, j]}");
        }
        Console.Write("\n");
    }
}

//=======================================

int cols, rows;

Console.Clear();
Console.WriteLine("Enter number of rows in the 1st matrix: ");
rows = int.Parse(Console.ReadLine()!);

Console.WriteLine("Enter number of columns in the 1st matrix: ");
cols = int.Parse(Console.ReadLine()!);
Console.WriteLine($"\nIt is assumed 2nd matrix has {cols} rows and {rows} columns.\n");

int [,] matrixA = FillArray (rows, cols, -10, 10);
//int [,] matrixA = {{2, 4}, {3, 2}};
Console.WriteLine($"The Matrix A is: ");
WriteArray2D(matrixA);

int [,] matrixB = FillArray (cols, rows, -10, 10);
//int [,] matrixB = {{3, 4}, {3, 3}};
Console.WriteLine($"The Matrix B is: ");
WriteArray2D(matrixB);

int [,] Product;// = new int [rows, rows];
//int [,] Product = new int [2, 2]; //to be clarified
Product = MultiplyMatrices (matrixA, matrixB);
Console.WriteLine($"The Product Matrix is: ");
WriteArray2D (Product);
Console.WriteLine("\n\n");
