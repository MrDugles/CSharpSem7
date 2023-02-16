// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

// m = 3, n = 4.

// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

void GetArray()
{
    Console.WriteLine("Задайте размерность массива mxn");
    int rows = InputWithValidation("m: ");
    int cols = InputWithValidation("n: ");
    PrintArray(rows, cols);
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
        catch(FormatException)
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

void PrintArray(int rows, int cols)
{
    double[,] thisArr = FillArray(rows, cols);
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

double[,] FillArray(int rows, int cols)
{
    double[,] newArr = new double[rows, cols];
    Random randNum = new Random();
    int lowerBound = -10;
    int upperBound = 10;
    int lowerNum = lowerBound * Math.Abs(lowerBound);
    int upperNum = upperBound * Math.Abs(upperBound);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            newArr[i, j] = randNum.Next(lowerNum, upperNum) / 10.0;
        }
    }
    return newArr;
}

GetArray();
