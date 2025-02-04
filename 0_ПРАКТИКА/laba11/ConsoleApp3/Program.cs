﻿using ConsoleApp3;

Console.ForegroundColor = ConsoleColor.Green;

double a = 0.8;
double b = 1.7;
MathFunction function = new MathFunction();

#region combined method
Console.WriteLine("1.Комбинированный метод: \n");
// вывод основных параметров на экран 
Console.WriteLine("f(x) = x - sqrt(ln(x+2))");
Logger.DrawSeparator();
Console.WriteLine("f`(x) = 1 - 1 / (2ln(sqrt(x+2)) * (x+2))");
Logger.DrawSeparator();
Console.WriteLine("f``(x) = (2ln(sqrt(x+2)) + 1) / (4ln^2(sqrt(x+2)) * (x+2)^2)");
Logger.DrawSeparator();
Console.WriteLine($"f(a) = {function.Calculate(a)}");
Console.WriteLine($"f(b) = {function.Calculate(b)}");
Logger.DrawSeparator();
Console.WriteLine($"f``(a) = {function.CalculateSecondDerivative(a)}");
Console.WriteLine($"f``(b) = {function.CalculateSecondDerivative(b)}");
Logger.DrawSeparator();

// вводим исходные данные перед началом вычислений
CombinedMethod combinedMethod = new CombinedMethod
(
   function.Calculate(a),
   function.Calculate(b),
   function.CalculateSecondDerivative(a),
   function.CalculateSecondDerivative(b),
   a,
   b
);

// определяем путь вычислений
combinedMethod.SelectDirOfCalc();
// находим корень
double result = combinedMethod.CalculateRoot();
// вывод результата на экран
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"Ответ: x = {result}");
Console.ForegroundColor = ConsoleColor.Green;
Logger.DrawSeparator();
Console.WriteLine("\n");
#endregion;

#region Simple iteration method
// вывод основных параметров на экран
Console.WriteLine("2.Метод простых итераций: \n");
Console.WriteLine("x - sqrt(ln(x+2)) = 0");
Logger.DrawSeparator();
Console.WriteLine($"ф(x) = x - f(x) / {function.CalculateK(a, b)}");
Logger.DrawSeparator();
Console.WriteLine($"ф`(x) = 1 - f'(x) / {function.CalculateK(a, b)}");
Logger.DrawSeparator();

SIMethod sIMethod = new SIMethod(a, b);
// вывод значений производный канонич функции
Console.WriteLine($"ф`(a) = {function.CalculateCanonFirstDerivative(a, a, b)}");
Console.WriteLine($"ф`(b) = {function.CalculateCanonFirstDerivative(b, a, b)}");
Logger.DrawSeparator();

// считаем корень
result =  sIMethod.CalculateRoot();

// выводим результат на экран
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"Ответ: x = {result}");
Console.ForegroundColor = ConsoleColor.Green;
Logger.DrawSeparator();
#endregion

Console.ForegroundColor = ConsoleColor.White;