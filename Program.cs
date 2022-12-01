//Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
//Например, задан массив:
//
//1 4 7 2
//5 9 2 3
//8 4 2 4
//5 2 6 7
//Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка


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

int indexOfMinimalItem(int [] Array)
{
    int buffer = Array[0];
    int result = 0;
    for (int i = 0; i < Array.Length; i++)
    {
        if (Array[i] < buffer)
        {
            buffer = Array[i];
            result = i;
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

int [,] Array = FillArray (rows, cols, -100, 100);
Console.WriteLine($"The source array is: ");
WriteArray2D(Array);

int [] SumByRows = SumByRow (Array);
Console.WriteLine($"\n Sums of rows are: " + String.Join(", ", SumByRows));

int NumberOfMinimalSumRow = indexOfMinimalItem (SumByRows) +1;
Console.WriteLine($"\nNumber of the row producing minimal sum of items is: {NumberOfMinimalSumRow}\n\n");
