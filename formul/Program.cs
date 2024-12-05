PrintYellow("Программа для анализа функции!\n\n" +
    " /   y = (1 + x - sin(x))^(1/2), где x <= 0\n" +
    "<\n" +
    " \\   y = x / (e^(-0.1*x))^(1/4), где х > 0\n");

while (true)        // безконченый цикл  - что  бы не перезапускать  программу каждый раз 
{
    MyProgramm();   // сам алгоритм 
}
void MyProgramm()
{
    PrintGreen("Введите x минимальный");    // все диалги будем делать зелеными - чтоб красиво

    double xMin = GetDouble();              // получит  число - сложная  задача - вынесем  в  отдельный  метод 

    PrintGreen("Введите x максимальный");

    double xMax = GetDouble();

    PrintGreen("Введите шаг функции");

    double xStep = GetDouble();

    Myfunc(xMin, xMax, xStep); // когда  у  нас  есть  все данные  дадим их отдельному методу 
}

void Myfunc(double min, double max, double step)
{
    if (ValidVar(min, max, step))
    { FuncPrint(min, max, step);}
}

void FuncPrint(double min, double max, double step)
{
    PrintYellow("_____Ответ____");
    /// переберем функцию 
    for (double x = min; x <= max; x += step)
    {
        double y = GetYByX(x);
        PrintYellow($"x={x}: y={y}"); // Ответ 
    }
    PrintYellow($"Пересечение функции с осью X В точке: {GetValueLessOrEqualZero(0)}");
}

double GetYByX(double x)
{
    if (x > 0) { return GetValueGreaterZero(x); }
    else { return GetValueLessOrEqualZero(x); }
}

double GetValueGreaterZero(double x) 
{
    return x / Math.Pow(Math.Exp(-0.1 * x), 1/4);
}

double GetValueLessOrEqualZero(double x)
{
    double preResult = 1 + x - Math.Sin(x);

    if (preResult < 0)
    {
        PrintRed("не является решением функции");
        return 0;
    }
    else { return Math.Sqrt(preResult); }
}

bool ValidVar(double min, double max, double step)
{
    if (min > max)
    {
        PrintRed("x минимальная больше чем x максимальная");
        return false; // выход из функции  дострочно
    }

    if (step == 0)
    {
        PrintRed("Шаг равен нулю");
        return false;
    }

    if (step < 0)
    {
        PrintRed("Шаг меньше нуля");
        return false;
    }

    return true;
}
void PrintGreen(string message)
{
    ConsoleColor color = Console.ForegroundColor;   // запомнит текущий цвет
    Console.ForegroundColor = ConsoleColor.Green;   // поменяем  на  зеленый цвет
    Console.WriteLine(message);                     // выведем  сообщение 
    Console.ForegroundColor = color;                // вернем  базовый цвет
}

void PrintYellow(string message)
{
    ConsoleColor color = Console.ForegroundColor;   // запомнит текущий цвет
    Console.ForegroundColor = ConsoleColor.Yellow;  // поменяем  на  зеленый цвет
    Console.WriteLine(message);                     // выведем  сообщение 
    Console.ForegroundColor = color;                // вернем  базовый цвет
}


void PrintRed(string message)
{
    ConsoleColor color = Console.ForegroundColor;   // запомнит текущий цвет
    Console.ForegroundColor = ConsoleColor.Red;     // поменяем  на  зеленый цвет
    Console.WriteLine(message);                     // выведем  сообщение 
    Console.ForegroundColor = color;                // вернем  базовый цвет
}

double GetDouble()
{
    try
    {
        string temp = Console.ReadLine();
        return Convert.ToDouble(temp);
    }
    catch
    {
        PrintRed("Не верный ввод, введите число");
        return GetDouble();
    }
}