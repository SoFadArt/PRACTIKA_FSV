using System;

namespace FSV_Task6
{ 

//1 Кадровый учет. 10 баллов. 
//Описать функцию заполнения массивов – досье, функцию форматированного вывода и 
//функцию удаления досье. (+6 баллов за систему поиска по !фамилии!) 
//Функция расширяет уже имеющийся массив на 1 и дописывает туда новое значение. 
//Будет 2 массива: 1) фио 2) должность. 
//Программа должна быть с меню, которое содержит пункты: 
//1) добавить досье. 
//2) вывести все досье(в одну строку через “-” фио и должность с порядковым номером в начале) 
//3) удалить досье 
//4) выход 
//</summary> 


    class Program
    {

        static void Main(string[] args)
        {
            string[,] dataTable = { { "Василий Пупкин", "президент" }, { "Кирилл Андратьев", "долбаеб" } };
            string[] menu = { "Добавить", "Удалить", "Посмотреть", "Выход" };
            int index = 0;

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.ResetColor();
                Console.WriteLine("\t\tМеню");

                for (int i = 0; i < menu.Length; i++)
                {
                    if (index == i)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine(menu[i]);
                    Console.ResetColor();
                }

                ConsoleKeyInfo userInput = Console.ReadKey(true);

                switch (userInput.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (index != 0) index--;
                        break;
                    case ConsoleKey.DownArrow:
                        if (index != menu.Length - 1) index++;
                        break;
                    case ConsoleKey.Enter:
                        dataTable = SelectElementofMenu(index, dataTable);
                        break;
                    default:
                        break;
                }
            }
        }

        static string[,] SelectElementofMenu(int index, string[,] dataTable)
        {
            switch (index)
            {
                case 0:
                    dataTable = AddElemetToFile(dataTable);
                    break;

                case 1:
                    ShowElementfromFile(dataTable);
                    Console.SetCursorPosition(0, 6);
                    Console.Write("Введите номер сотрудника, которого вы хотите удалить: ");
                    int indexToDelete = Convert.ToInt32(Console.ReadLine());
                    dataTable = DeleteElementfromFile(dataTable, indexToDelete);
                    break;
                case 2:
                    ShowElementfromFile(dataTable);
                    break;
                case 3:
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
            return dataTable;
        }
        static string[,] AddElemetToFile(string[,] array) //Добавление сотрудника в досье 
        {
            ClearArea();

            Console.Write("Добавление досье.\nВведите имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите должность: ");
            string post = Console.ReadLine();

            string[,] tempArray = new string[array.GetLength(0) + 1, array.GetLength(1)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    tempArray[i, j] = array[i, j];
                }
            }

            array = tempArray;

            array[array.GetLength(0) - 1, 0] = name;

            array[array.GetLength(0) - 1, 1] = post;

            ShowMessage($"Вы добавили {name} - {post} успешно", ConsoleColor.Yellow);
            return array;
        }

        static string[,] DeleteElementfromFile(string[,] array, int index)
        {
            index -= 1;
            if (index > 0 && index < array.GetLength(0))
            {
                string[,] tempArray = new string[array.GetLength(0) - 1, array.GetLength(1)];

                for (int i = 0; i < index; i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        tempArray[i, j] = array[i, j];
                    }
                }

                for (int i = index; i < tempArray.GetLength(0); i++)
                {
                    for (int j = 0; j < array.GetLength(1); j++)
                    {
                        tempArray[i, j] = array[i + 1, j];
                    }
                }

                ShowMessage($"Вы успешно удалили {array[array.GetLength(0) - 1, 0]} - {array[array.GetLength(0) - 1, 1]}", ConsoleColor.Yellow);
                array = tempArray;
            }

            else ShowMessage("Вы выбрали не существующий элемент");

            return array;
        }

        static void ShowElementfromFile(string[,] dataTable)
        {
            ClearArea();
            Console.WriteLine("Список сотрудников");
            for (int i = 0; i < dataTable.GetLength(0); i++)
            {
                Console.WriteLine((i + 1) + "." + dataTable[i, 0] + " - " + dataTable[i, 1]);
            }
        }

        static void ShowMessage(string message, ConsoleColor color = ConsoleColor.Red)
        {
            ClearArea();
            Console.SetCursorPosition(0, 6);
            Console.ForegroundColor = color;
            Console.WriteLine(message + "\t\t\t\t\t");
            Console.ResetColor();
        }
        static void ClearArea(int x = 0, int y = 6)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 15; i++)
            {
                Console.ResetColor();
                Console.WriteLine("\t\t\t\t\t\t\t\t");
            }
            Console.SetCursorPosition(x, y);
        }
    }
}