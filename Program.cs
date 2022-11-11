// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

Console.WriteLine("Укажите количество строк");
int RowsTask54 = int.Parse(Console.ReadLine()!);
Console.WriteLine("Укажите количество столбцов");
int ColumnsTask54 = int.Parse(Console.ReadLine()!);
int[,] ArrayTask54 = Get2dArray(RowsTask54,ColumnsTask54,0,9);
Console.WriteLine("Получен массив:");
Console.WriteLine();
PrintIntArray(ArrayTask54);
Console.WriteLine();
Console.WriteLine("Упорядочил по убыванию элементы каждой строки:");
Console.WriteLine();
PrintIntArrayWithSortedElementsFromMaxToMinByRows(ArrayTask54);

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

Console.WriteLine("Укажите количество строк");
int RowsTask56 = int.Parse(Console.ReadLine()!);
Console.WriteLine("Укажите количество столбцов");
int ColumnsTask56 = int.Parse(Console.ReadLine()!);
int[,] ArrayTask56 = Get2dArray(RowsTask56,ColumnsTask56,0,9);
Console.WriteLine("Получен массив:");
Console.WriteLine();
PrintIntArray(ArrayTask56);
Console.WriteLine();
// Console.WriteLine($"{FindSumByRow(ArrayTask56,0)}");
Console.WriteLine($"Наименьшая сумма элементов в строке(по индексу) № {FindRowWithMinSum(ArrayTask56)}");

// Задача 58: Задайте две квадратные матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

Console.WriteLine("Введите размерность квадратных матриц:");
int QuadMatrixSideTask58 = int.Parse(Console.ReadLine()!);
int[,] Matrix1Task58 = Get2dArray(QuadMatrixSideTask58,QuadMatrixSideTask58,0,9);
int[,] Matrix2Task58 = Get2dArray(QuadMatrixSideTask58,QuadMatrixSideTask58,0,9);
Console.WriteLine("Получены матрицы:");
Console.WriteLine();
PrintIntArray(Matrix1Task58);
Console.WriteLine();
PrintIntArray(Matrix2Task58);
Console.WriteLine();
Console.WriteLine("Результат умножения матрицы №1 на матрицу №2:");
Console.WriteLine();
PrintIntArray(MultiplicationOfSquadArrays(Matrix1Task58,Matrix2Task58));


// Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

Console.WriteLine("Укажите количество строк");
int RowsTask60 = int.Parse(Console.ReadLine()!);
Console.WriteLine("Укажите количество столбцов");
int ColumnsTask60 = int.Parse(Console.ReadLine()!);
Console.WriteLine("Укажите глубину массива");
int DeepTask60 = int.Parse(Console.ReadLine()!);
int[,,] ArrayTask60 = Get3dArray(RowsTask60,ColumnsTask60,DeepTask60,10,99);
Print3dIntArrayWithIndex(ArrayTask60);


//Methods



int[,] MultiplicationOfSquadArrays (int[,] array1, int[,] array2)
{

    int[,] result = new int[array1.GetLength(0), array1.GetLength(1)];
    for (int i = 0; i < array1.GetLength(0); i++)
    {
        for (int j = 0; j < array2.GetLength(1); j++)
        {
            for (int k = 0; k < array2.GetLength(0); k++)
            {
                result[i,j] += array1[i,k] * array2[k,j];
            }
        }
    }
    return result;
}

int FindRowWithMinSum(int[,] array)
{
    int sum = FindSumByRow(array,0);
    int result = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        if(FindSumByRow(array,i) < sum)
        {
            sum = FindSumByRow(array,i);
            result = i;
        }
    }
    return result;
}

int FindSumByRow (int[,] array, int rownumber)
{
    int result = 0;
    for (int i = 0; i < array.GetLength(1); i++)
    {
        result = result + array[rownumber,i];
    }
    return result;
}

void PrintIntArrayWithSortedElementsFromMaxToMinByRows(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.WriteLine(String.Join(" ", GetRowFrom2dArrayWithSortedElementsFromMaxToMin(array,i)));
    }
}

int[] GetRowFrom2dArrayWithSortedElementsFromMaxToMin(int[,] array, int rownumber)
{
    int[] linearray = new int[array.GetLength(1)];
    for (int i = 0; i < array.GetLength(1); i++)
    {
        linearray[i] = array[rownumber,i];
    }
    linearray = linearray.OrderByDescending(x=>x).ToArray();
    return linearray;
}

int[,] Get2dArray(int rows, int columns, int minValue, int maxValue)
{
    int[,] result = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}

int[,,] Get3dArray(int rows, int columns, int deep, int minValue, int maxValue)
{
    int[,,] result = new int[rows, columns, deep];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            int k = 0;
            while(k < deep)
            {
                int element = new Random().Next(minValue, maxValue + 1);
                if(CheckDuplicate(result,element)) continue;
                result[i,j,k] = element;
                k++;
            }
        }
    }
    return result;
}

bool CheckDuplicate (int[,,] array, int element)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if (array[i,j,k] == element)
                {
                    return true;
                }
            }
        }
    }
    return false;
}

void PrintIntArray(int[,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            Console.Write($"{Array[i, j]} ");
        }
        Console.WriteLine();
    }
}

void Print3dIntArrayWithIndex(int[,,] Array)
{
    for (int i = 0; i < Array.GetLength(0); i++)
    {
        for (int j = 0; j < Array.GetLength(1); j++)
        {
            for (int k = 0; k < Array.GetLength(2); k++)
            {
                Console.Write($"{Array[i,j,k]}({i},{j},{k}) ");
            }     
            Console.WriteLine();       
        }
        Console.WriteLine();  
    }
}