using System;
using System.Linq;
namespace Krutolapov
{
    public static class SubClass
    {
        /// <summary>
        /// ...
        /// </summary>
        /// <param name="arr">Целочисленный массив</param>
        /// <param name="n">Число n</param>
        public static void DoAFlip(int[] arr, int n)
        {
            if (n > arr.Length)
            {
                Console.Write("n не может быть больше длины массива.");
                return;
            }
            int kol = 0;
            string[] resultArr = new string[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                resultArr[i] = arr[i].ToString();
                Console.Write(arr[i] + " ");
            }
            Console.Write("\n");
            while (resultArr.Count(item => item != "-") > 1 && resultArr.Count(item => item != "-") >= n)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (resultArr[i] != "-")
                    {
                        kol++;
                        if (kol % n == 0)
                        {
                            resultArr[i] = "-";
                            Console.Write(" " + resultArr[i] + " ");
                        }
                        else
                            Console.Write(resultArr[i] + " ");
                    }
                    else
                        Console.Write(" - ");
                }
                Console.Write("\n");
                kol = 0;
            }
        }
        public static int[,] GetArrMZero(int m)
        {
            int[] tempArr = new int[m * m];
            int[,] arr = new int[m, m];
            Random rnd = new Random();
            for (int i = 1; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    do
                    {
                        arr[i, j] = rnd.Next(-9, 9);
                    }
                    while (arr[i, j] == 0);
                }
            }
            for (int i = 0, k = 0; i < m; i++) //пихаем двумерный в одномерный
            {
                for (int j = 0; j < m; j++, k++)
                {
                    tempArr[k] = arr[i, j];
                }
            }
            tempArr = tempArr.Take(tempArr.Length).OrderBy(x => rnd.Next()).ToArray();
            for (int i = 0, k = 0; i < m; i++) //пихаем одномерный в двумерный
            {
                for (int j = 0; j < m; j++, k++)
                {
                    arr[i, j] = tempArr[k];
                }
            }
            return arr;
        }
        public static void FindNumPlace(int[,] arr)
        {
            int tempStorage, length = arr.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i != j)
                        if (arr[i, j] > 0)
                        {
                            if (j < i)
                            {
                                for (int l = 0; l < length; l++)
                                {
                                    for (int n = l + 1; n < length; n++)
                                    {
                                        if (arr[l, n] < 0)
                                        {
                                            tempStorage = arr[i, j];
                                            arr[i, j] = arr[l, n];
                                            arr[l, n] = tempStorage;
                                            l = arr.Length; //выход из двойного цикла
                                            break;
                                        }
                                    }
                                }
                                if (arr[i, j] > 0)
                                    arr[i, j] = -arr[i, j];
                            }
                        }
                        else if (arr[i, j] < 0)
                        {
                            if (j > i)
                            {
                                for (int l = 1; l < length; l++)
                                {
                                    for (int n = 0; n != l; n++)
                                    {
                                        if (arr[l, n] < 0)
                                        {
                                            tempStorage = arr[i, j];
                                            arr[i, j] = arr[l, n];
                                            arr[l, n] = tempStorage;
                                            l = arr.Length; //выход из двойного цикла
                                            break;
                                        }
                                    }
                                }
                                if (arr[i, j] < 0)
                                    arr[i, j] = -arr[i, j];
                            }
                        }
                }
            }
        }
        public static void SortByMainDiagonale(int[,] arr)
        {
            int tempStorage, length = arr.GetLength(0);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (arr[i, j] == 0)
                    {
                        if (arr[i, i] != 0)
                        {
                            tempStorage = arr[i, j];
                            arr[i, j] = arr[i, i];
                            arr[i, i] = tempStorage;
                        }
                        else
                        {
                            for (int k = 0; k < length; k++)
                            {
                                if (arr[k, k] != 0)
                                {
                                    tempStorage = arr[i, j];
                                    arr[i, j] = arr[k, k];
                                    arr[k, k] = tempStorage;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        public static void Print(int[,] arr)
        {
            for (int i = 0; i < arr.GetLength(0); i++) //vivod
            {
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    if (j != arr.GetLength(0) - 1)
                        if (arr[i, j] < 0)
                            Console.Write(" " + arr[i, j]);
                        else
                            Console.Write("  " + arr[i, j]);
                    else
                        if (arr[i, j] < 0)
                        Console.WriteLine(" " + arr[i, j]);
                    else
                        Console.WriteLine("  " + arr[i, j]);

                }
            }
            Console.WriteLine();
        }
    }
}