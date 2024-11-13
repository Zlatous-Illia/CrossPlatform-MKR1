using System;
using System.IO;

namespace Lab1
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Чтение входного файла
                string input = File.ReadAllText("INPUT.TXT").Trim();
                int x = int.Parse(input);

                // Получение количества решений
                int result = GetWaysToRepresentAsSum(x);

                // Запись результата в выходной файл
                File.WriteAllText("OUTPUT.TXT", result.ToString());

                Console.WriteLine($"Количество способов представления {x} как суммы четырех чисел: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public static int GetWaysToRepresentAsSum(int x)
        {
            int count = 0;

            // Перебор всех возможных значений a, b, c
            for (int a = 1; a <= x - 3; a++)  // a <= x - 3, потому что d минимум 1
            {
                for (int b = a; b <= x - 2; b++)  // b >= a, b <= x - 2, потому что c и d минимум 1
                {
                    for (int c = b; c <= x - 1; c++)  // c >= b, c <= x - 1, потому что d минимум 1
                    {
                        int d = x - a - b - c;  // находим d, остальная часть от x
                        if (d >= c)  // проверяем условие d >= c
                        {
                            count++;  // если условие выполнено, увеличиваем счетчик
                        }
                    }
                }
            }

            return count;
        }
    }
}
