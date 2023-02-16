// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

int[,] GetArray()
{
    Console.WriteLine("Задайте размерность массива mxn");
    int rows = InputWithValidation("m: ", 1);
    int cols = InputWithValidation("n: ", 1);
    return FillArray(rows, cols);
}

int InputWithValidation(string message, byte limit)
{
    int num;
    string? inputText;
    while (true)
    {
        Console.Write(message);
        inputText = Console.ReadLine();
        if (inputText.Length > limit)
        {
            Console.WriteLine($"Ошибка! Ограничение ввода в {limit} символ(а)");
            continue;
        }
        if (inputText == null || inputText.Trim() == "")
        {
            Console.WriteLine("Ошибка! Вы ничего не ввели.");
            continue;
        }
        try
        {
            num = int.Parse(inputText);
            break;
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка! Введите число.");
            continue;
        }
    }
    return num;
}

void PrintArray(int[,] thisArr)
{
    int rows = thisArr.GetLength(0);
    int cols = thisArr.GetLength(1);
    Console.Clear();
    Console.WriteLine($"Массив {rows}x{cols}:");
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write("{0, 7}", thisArr[i, j]);
        }
        Console.WriteLine();
    }
}

int[,] FillArray(int rows, int cols)
{
    int[,] newArr = new int[rows, cols];
    Random randNum = new Random();
    int lowerBound = 0;
    int upperBound = 10;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            newArr[i, j] = randNum.Next(lowerBound, upperBound);
        }
    }
    return newArr;
}

void CheckMatch(int[,] thisArr)
{
    int rows = thisArr.GetLength(0);
    int cols = thisArr.GetLength(1);
    (int, int) sizeArr = (rows, cols);
    int DesiredNum = InputWithValidation("Введите искомое число\\элемент: ", 2);
    if (IntLength(DesiredNum) > 1)
    {
        int checkRow = DesiredNum % 10;
        int checkCol = DesiredNum / 10;
        (int, int) checkVal = (checkRow, checkCol);
        if (СheckPosition(checkVal, sizeArr))
        {
            Console.WriteLine($"{DesiredNum} -> число {thisArr[checkRow - 1, checkCol - 1]} (строка {checkRow} столбец {checkCol})");
            Environment.Exit(0);
        }
    }
    else
    {
        (bool state, int row, int col) resultValue = СheckValue(thisArr, DesiredNum);
        if (resultValue.state)
        {
            Console.WriteLine($"{DesiredNum} -> число {DesiredNum} найдено (строка {resultValue.row} столбец {resultValue.col})");
            Environment.Exit(0);
        }
    }
    Console.WriteLine($"{DesiredNum} -> такого числа в массиве нет");
}

int IntLength(int num)
{
    if (num == 0)
        return 1;
    int result = 0;
    while (num > 0)
    {
        num = num / 10;
        result++;
    }
    return result;
}

bool СheckPosition((int row, int col) check, (int rows, int cols) arr)
{
    if ((check.row > arr.rows) || (check.col > arr.cols)) return false;
    return true;
}

(bool, int, int) СheckValue(int[,] thisArr, int value)
{
    int rows = thisArr.GetLength(0);
    int cols = thisArr.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            if (thisArr[i, j] == value)
                return (true, i + 1, j + 1);
        }
    }
    return (false, 0, 0);
}

int[,] newArray = GetArray();
PrintArray(newArray);
CheckMatch(newArray);