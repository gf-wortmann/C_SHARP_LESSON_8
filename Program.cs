//Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
//Например, задан массив:
//1 4 7 2
//5 9 2 3
//8 4 2 4
//В итоге получается вот такой массив:
//7 4 2 1
//9 5 3 2
//8 4 4 2

void ShortSorting (int[] input, bool Ascending)
        {
            int buffer;//, buffer_low;
            
            for (int i = 0; i < input.Length; i++)
            {
                for (int j = i+1; j < input.Length; j++)
                {
                    if (((input[i] > input[j]) && Ascending == true) || ((input[i] < input[j]) && Ascending == false))
                    {
                        buffer = input[i];
                        input[i] = input[j];
                        input[j] = buffer;
                    }
                }            
            }
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

int [] GetRowByIndexFrom (int [,] Array, int rowIndex)
{
    int rows = Array.GetUpperBound(0)+1;
    int columns = Array.Length / rows;
    int [] result = new int [columns];

    for (int i = 0; i < columns; i++)
    {
        result [i] = Array [rowIndex, i];
    }
    return result;
}

void SetRowByIndexTo (int [,] Array, int [] row, int rowIndex)
{
    int rows = Array.GetUpperBound(0)+1;
    int columns = Array.Length / rows;
    for (int i = 0; i < columns; i++)
    {
        Array [rowIndex, i] = row [i];
    }
}

void SortArrayByRows(int [,] Array)
{
    int rows = Array.GetUpperBound(0)+1;
    int columns = Array.Length / rows;
    int [] row = new int [columns];

    for (int i = 0; i < rows; i++)
    {
        row = GetRowByIndexFrom (Array, i);
        ShortSorting (row, false);
        SetRowByIndexTo (Array, row, i);
    }
}

void WriteArray ( int [,] Array)
{
    int rows = Array.GetUpperBound(0)+1;
    int columns = Array.Length / rows;
    
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            string c = (Array[i,j] > 0) ? " " : "";
            Console.Write($"\t{c}{Array [i, j]:d2}");
        }
        Console.Write("\n");
    }
}

//=======================================
int [,] Array = FillArray (3,5,-100,100);
Console.Clear();
Console.WriteLine($"The source array is: ");
WriteArray(Array);
SortArrayByRows (Array);
Console.WriteLine($"The array sorted by descending is: ");
WriteArray(Array);
