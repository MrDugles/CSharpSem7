// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

int[,] GetArray()
{
    Console.WriteLine("Задайте размерность массива mxn");
    int rows = InputWithValidation("m: ");
    int cols = InputWithValidation("n: ");
    return FillArray(rows, cols);
}

int InputWithValidation(string message)
{
    int num;
    string? inputText;
    while (true)
    {
        Console.Write(message);
        inputText = Console.ReadLine();
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
        catch (OverflowException)
        {
            Console.WriteLine("Ошибка! Вы ввели слишком много символов.");
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
    Console.WriteLine();
    for (int i = 0; i < rows; i++)
    {
        Console.Write("{0, 9}", "|");
        for (int j = 0; j < cols; j++)
        {
            Console.Write("{0, 7}{1,7}", thisArr[i, j], "|");
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

void ColsAverage(int[,] thisArr)
{
    int rows = thisArr.GetLength(0);
    int cols = thisArr.GetLength(1);
    int summ = 0;
    double result = 0;
    Console.WriteLine();
    Console.Write("Average |");
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            summ += thisArr[j,i];
        }
        result = summ / (rows * 1.0);
        Console.Write("{0, 7}{1,7}", result, "|");
        summ = 0;
        result = 0;
    }
    Console.WriteLine();
}

int[,] newArray = GetArray();
PrintArray(newArray);
ColsAverage(newArray);
