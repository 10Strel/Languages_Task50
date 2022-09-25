/*
Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
[1, 7] -> такого числа в массиве нет
*/
int m = 0, n = 0, position1 = 0, position2 = 0;
Random random = new Random();

if (!InputControl("Задайте размерность двумерного массива (m n)", ref m, ref n))
    return;

int[,] array = InitArray(m, n);

PrintArray(array);

if (!InputControl("Задайте позицию элемента в массиве (pos1 pos2)", ref position1, ref position2))
    return;

string result = $"[{position1}, {position2}] -> ";

if ((position1 < m) && (position2 < n))
    result = string.Concat(result, $"{array[position1, position2]}");
else
    result = string.Concat(result, "такого элемента в массиве нет");    

Console.WriteLine(result);    

# region methods

bool InputControl(string caption, ref int par0, ref int par1)
{
    int tryCount = 3;
    string inputStr = string.Empty;
    bool resultInputCheck = false;

    while (!resultInputCheck)
    {
        Console.WriteLine($"\r\n{caption} (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        string[] inputStringArray = inputStr.Split(new char[] { ' ', ';' });

        resultInputCheck = 
            inputStringArray.Length == 2 && 
            int.TryParse(inputStringArray[0], out par0) && 
            par0 >= 0 &&
            int.TryParse(inputStringArray[1], out par1) &&
            par1 >= 0;

        if (!resultInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

int[,] InitArray(int m, int n)
{
    int[,] array = new int[m,n];

    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            array[i,j] = random.Next(0, 100);
        }
    }

    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write($"{array[i,j]}\t");
        }

        Console.WriteLine();
    }
}

# endregion
