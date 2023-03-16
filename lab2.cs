using System;

class Program
{
    static void Main(string[] args)
    {
        // Задаємо матрицю:
        int[,] matrix = {
            {1, -2, 3, -4},
            {-5, 6, -7, 8},
            {9, 10, -11, -12}
        };

        // Обчислюємо характеристики стовпців:
        int[] characteristics = new int[matrix.GetLength(1)];
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,j] < 0 && matrix[i,j] % 2 != 0)
                {
                    characteristics[j] += Math.Abs(matrix[i,j]);
                }
            }
        }

        // Сортуємо матрицю за зростанням характеристик:
        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        {
            for (int k = j + 1; k < matrix.GetLength(1); k++)
            {
                if (characteristics[k] < characteristics[j])
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        int temp = matrix[i,j];
                        matrix[i,j] = matrix[i,k];
                        matrix[i,k] = temp;
                    }
                    int tempChar = characteristics[j];
                    characteristics[j] = characteristics[k];
                    characteristics[k] = tempChar;
                }
            }
        }

        // Обчислюємо суму елементів у стовпцях з від'ємними елементами:
        int sum = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            bool hasNegative = false;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i,j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }
            if (hasNegative)
            {
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    sum += matrix[i,j];
                }
            }
        }

        // Виводимо результати:
        Console.WriteLine("Матриця після перестановки стовпців:");
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i,j] + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine("Сума елементів у стовпцях з від'ємними елементами: " + sum);
    }
}
