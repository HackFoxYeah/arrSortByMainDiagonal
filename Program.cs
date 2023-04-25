using System;

namespace Krutolapov
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int m = 10;
            int[,] arr = SubClass.GetArrMZero(m);
            Console.WriteLine("Сгенерированный массив: \n");
            SubClass.Print(arr);
            SubClass.SortByMainDiagonale(arr);
            Console.WriteLine("Отсортирована главная диагональ массива: \n");
            SubClass.Print(arr);
            SubClass.FindNumPlace(arr);
            Console.WriteLine("Элементы отсортированы по знаку относительно главной диагонали: \n");
            SubClass.Print(arr);
            Console.ReadKey();
        }
    }
}