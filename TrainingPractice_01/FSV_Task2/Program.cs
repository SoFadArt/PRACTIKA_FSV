using System;

namespace FSV_Task2
{
    internal class Program
    {
        string message = Console.ReadLine();
            while (!message.Contains("exit"))
            {
                if (message != "exit")
                {
                    Console.Write("Введите количество повторов сообщения: ");
                    int repeat = int.Parse(Console.ReadLine());
                    for (int i = 0; i<repeat; i++)
                    {
                        Console.WriteLine(message);
                    }
    Console.WriteLine("Повторить операцию или exit для выхода");
                    message = Console.ReadLine();
                }
            }
    }
}
