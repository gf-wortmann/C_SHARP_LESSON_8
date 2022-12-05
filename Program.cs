//Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
//Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
//Массив размером 2 x 2 x 2
//66(0,0,0) 25(0,1,0)
//34(1,0,0) 41(1,1,0)
//27(0,0,1) 90(0,1,1)
//26(1,0,1) 55(1,1,1)

bool zeroed = false;  // for checking if zero is produced by randomizer more than once.
//We need to differ zero from randomizer from zeros the array was filled by when initiated.

bool IsPresentIn (int item, int [,,] Array, int I, int J, int K)
{
    if (item == 0 && zeroed == false) 
    {
        zeroed = true;
//        Console.WriteLine($"Zero checked 1st time , item = {item}? zeroed = {zeroed} - IsPresentIn ()");
        return false;
    }
// looking for earlier occurences of the item, so it is shorter to look up backward, from current [i, j, k] to initial position.
    for (int i = I; i >= 0; i--) 
    {
        for (int j = J; j >= 0; j--) 
        {
            for (int k = K; k >= 0; k--) 
            {
                if (item == Array [i, j, k])
                {   
//                    Console.WriteLine($"item {item} founded in the array at [{i}, {j}, {k}] - IsPresentIn ()");
                    return true;
                }
                
            }
        }
    }
    return false;
}


int [,,] FillArray (int layers, int rows, int columns, int min, int max) 
{
    int [,,] result = new int [layers, rows, columns];
    Random r = new Random();
    int item;
    for (int i = 0; i < layers; i++)
    {
        for (int j = 0; j < rows; j++)        
        {
            for (int k = 0; k < columns; k++)
            {
                do
                {
                    item = r.Next(min+1, max);
//                    if (item == 0) Console.WriteLine($"item {item} is dropped at [{i}, {j}, {k}]");
                }
                while (IsPresentIn(item, result, i, j, k));
                result [i, j, k] = item;
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
        for (int i = 0; i < rows; i++)
        {   
            for (int j = 0; j < columns; j++)
            {
                string c = (Array[j, i, k] > 0) ? " " : "";
                c = (Array [j, i, k] == 0) ? c + " " : c;
                c = (Array [j, i, k] / 10 == 0) ? c + " ": c;

                Console.Write($"\t{c}{Array [j, i, k]} ");
                Console.Write($"[{j}, {i}, {k}]");
            }
            Console.Write("\n");
        }
        Console.Write("\n");
    }
}

//=======================================

Console.Clear();

int [,,] matrix3 = FillArray(3,3,3,-20,20);
//PrintArray3D(matrix3);

int [,,] M =    {
                    {
                        {111, 121, 131}, 
                        {211, 221, 231},
                        {311, 321, 331}
                    },
                    {
                        {112, 122, 132},
                        {212, 222, 232},
                        {312, 322, 332}
                    },
                    {
                        {113, 123, 133},
                        {213, 223, 233},
                        {313, 323, 333}
                    }
                };

//PrintArray3D (M);

//Console.Write($" {M [0,0,0]}, {M [0,0,1]} \n");
//Console.Write($" {M [0,0,0]}, {M [0,1,0]} \n");
//Console.Write($" {M [0,0,0]}, {M [1,0,0]} \n");


int [,] N =    {
                    {11, 12, 13}, 
                    {21, 22, 23}
                };
void Print2D (int [,] Array)
{
    int basic = Array.GetUpperBound(0);
    int top = Array.GetUpperBound(1);

    for (int i =0 ; i <= basic ; i++)
    {
        for (int j = 0 ; j <= top; j++)
        {
            Console.Write($"{Array [i,j]} [{i}, {j}]");
        }
        Console.WriteLine();
    }
}

//Print2D (N);

void Print2D1 (int [,,] Array)
{
    int basic = Array.GetUpperBound(0);
    int mid = Array.GetUpperBound(1);
    int top = Array.GetUpperBound(2);

    for (int k =0 ; k <= basic ; k++)
    {
        for (int j = 0 ; j <= mid; j++)
        {
            for (int i = 0 ; i <= top; i++)
            {
                string c = (Array [k,j,i] > 0) ? " " : "";
                c = (Array [k,j,i] == 0) ? c + " " : c;
                c = (Array [k,j,i] / 10 == 0) ? c + " ": c;
                Console.Write($"{c}{Array [k,j,i]} [{j}, {i}, {k}]  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

Print2D1 (matrix3);
Print2D1 (M);

int [,,] Z = 
{
    {
        {66, 25},
        {34, 41}
    },
    {
        {27, 90},
        {26, 55}
    }
};
Print2D1 (Z);
Console.WriteLine($"The array Z has {Z.Length} items.");
Console.WriteLine($"The array M has {M.Length} items.");