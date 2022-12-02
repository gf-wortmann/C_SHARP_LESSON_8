//Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
//Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
//Массив размером 2 x 2 x 2
//66(0,0,0) 25(0,1,0)
//34(1,0,0) 41(1,1,0)
//27(0,0,1) 90(0,1,1)
//26(1,0,1) 55(1,1,1)



int [,,] FillArray (int layers, int rows, int columns, int min, int max) 
{
    int [,,] result = new int [layers, rows, columns];
    Random r = new Random();
    for (int i = 0; i < layers; i++)
    {
        for (int j = 0; j < rows; j++)        
        {
            for (int k = 0; k < columns; k++)
            {
                result [i, j, k] = r.Next(min+1, max);
            }
        }
    }
    return result;
}

void PrintArray3D ( int [,,] Array)
{
    int rows = Array.GetUpperBound(0)+1;
    int columns = Array.GetUpperBound(1) + 1;
    int layers = Array.GetUpperBound(2) + 1;
    
    for (int k = 0; k < layers; k++)
    {
        for (int j = 0; j < columns; j++)
        {   
            for (int i = 0; i < rows; i++)
            {
                string c = (Array[i, j, k] > 0) ? " " : "";
                Console.Write($"\t{c}{Array [i, j, k]} ");
                Console.Write($"[{i}, {j}, {k}]");
            }
            Console.Write("\n");
        }
        Console.Write("\n");
    }
}

//=======================================

Console.Clear();

int [,,] matrix3 = FillArray(2,2,2,0,10);
PrintArray3D(matrix3);
