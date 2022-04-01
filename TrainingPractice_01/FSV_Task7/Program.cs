using System;

namespace FSV_Task7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[10];

            FillArray(array);
            Console.WriteLine("Исходный массив");

            OutputArray(array);

            Console.WriteLine("\n\nНажмите Enter чтобы перемешать");
            Console.ReadLine();


            ShuffleArray(array);
            Console.WriteLine("Перемешанный массив");
            OutputArray(array);
            Console.WriteLine(" ");

        }

        static void FillArray(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 100);
            }
        }

        static void OutputArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + "  ");
            }
        }

        static void ShuffleArray(int[] array)
        {
            Random random = new Random();
            for (int i = array.Length - 1; i >= 0; i--)
            {
                int randomItem = random.Next(i);
                int shuffledElement = array[randomItem];
                array[randomItem] = array[i];
                array[i] = shuffledElement;
            }
        }

    }
}


