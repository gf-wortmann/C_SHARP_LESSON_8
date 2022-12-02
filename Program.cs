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
                result [i, j] += (A [i,r] * B[j, r]);
            }
        }

    }
    WriteArray2D ( result);
    return result;
}

int [,] FillArray (int rows, int columns, int min, int max) //, bool zeroed)
{
    int [,] result = new int [rows, columns];
    Random k = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
           //result [i,j] =  (!zeroed) ? k.Next(min+1, max) : 0;
           result [i,j] = k.Next(min+1, max);
        }
    }
    return result;
}

int [] SumByRow (int [,] Array)
{
    int rows = Array.GetUpperBound(0)+1;
    int columns = Array.Length / rows;
    int [] result = new int [rows];

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result [i] += Array [i, j];
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
Console.WriteLine("Enter number of rows of the new array: ");
rows = int.Parse(Console.ReadLine()!);

Console.WriteLine("Enter number of columns of the new array: ");
cols = int.Parse(Console.ReadLine()!);

int [,] matrixA = FillArray (rows, cols, -100, 100);
Console.WriteLine($"The Matrix A is: ");
WriteArray2D(matrixA);

int [,] matrixB = FillArray (cols, rows, -100, 100);
Console.WriteLine($"The Matrix B is: ");
WriteArray2D(matrixB);

//int [] SumByRows = SumByRow (Array);
//Console.WriteLine($"\n Sums of rows are: " + String.Join(", ", SumByRows));

//int NumberOfMinimalSumRow = indexOfMinimalItem (SumByRows) +1;
//Console.WriteLine($"\nNumber of the row producing minimal sum of items is: {NumberOfMinimalSumRow}\n\n");
