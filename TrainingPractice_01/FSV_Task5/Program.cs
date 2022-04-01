using System;
using System.Diagnostics;
using System.IO;
using static System.Console;


namespace SGV_Task_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int turn = 0;
            double isled = 0;
            int row = 10;
            int col = 20;
            string isled_bar = "[.....]";
            bool _while1 = true;
            int enemy1 = 0;
            string enemy_string = "";
            string turn_string = "";
            int[,] map = new int[row, col];
            int[,] map_isl = new int[row, col];
            string[] lines = File.ReadAllLines($"maps/map01.txt");


            for (int i = 0; i < lines.Length; i++)
            {
                string[] numbers = lines[i].Split();
                int j = 0;
                while (j < col)
                {
                    map[i, j] = Convert.ToInt32(numbers[j]);
                    map_isl[i, j] = Convert.ToInt32(numbers[j]);
                    j++;
                }
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Помоги музыканту выйти из лабиринта и собрать все ноты!\nВремя пойдет, как только ты начнешь движение!\n");
            Console.ResetColor();

                
            DrawMap(map, row, col);


            long freq = Stopwatch.Frequency; //частота таймера
            Stopwatch stopwatch = new Stopwatch(); 
           
            do
            {
                var ch = Console.ReadKey(false).Key;

                stopwatch.Start(); //запускаем таймер

                switch (ch)
                {
                    case ConsoleKey.LeftArrow:
                        MoveLeft(map, row, col, ref _while1, ref turn, ref map_isl, ref enemy1);
                        Console.Clear();
                        Console.WriteLine("Ход: {0}", turn);
                        isled = 0;

                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                if (map_isl[i, j] == 12)
                                {
                                    isled = isled + 1;
                                    isled = Math.Round(isled, 1);
                                    Progress_Bar(ref isled, ref isled_bar);
                                }
                            }
                        }
                        Console.WriteLine("Исследование карты: {0}%, {1}", isled, isled_bar);
                        DrawMap(map, row, col);
                        break;

                    case ConsoleKey.RightArrow:
                        MoveRight(map, row, col, ref _while1, ref turn, ref map_isl, ref enemy1);
                        Console.Clear();
                        Console.WriteLine("Ход: {0}", turn);
                        isled = 0;
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                if (map_isl[i, j] == 12)
                                {
                                    isled = isled + 1.33;
                                    isled = Math.Round(isled, 1);
                                    Progress_Bar(ref isled, ref isled_bar);
                                }
                            }
                        }
                        Console.WriteLine("Исследование карты: {0}%, {1}", isled, isled_bar);
                        DrawMap(map, row, col);
                        break;

                    case ConsoleKey.UpArrow:
                        MoveUp(map, row, col, ref _while1, ref turn, ref map_isl, ref enemy1);
                        Console.Clear();
                        Console.WriteLine("Ход: {0}", turn);
                        isled = 0;
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                if (map_isl[i, j] == 12)
                                {
                                    isled = isled + 1.33;
                                    isled = Math.Round(isled, 1);
                                    Progress_Bar(ref isled, ref isled_bar);
                                }
                            }
                        }
                        Console.WriteLine("Исследование карты: {0}%, {1}", isled, isled_bar);
                        DrawMap(map, row, col);
                        break;

                    case ConsoleKey.DownArrow:
                        MoveDown(map, row, col, ref _while1, ref turn, ref map_isl, ref enemy1);
                        Console.Clear();
                        Console.WriteLine("Ход: {0}", turn);
                        isled = 0;
                        for (int i = 0; i < row; i++)
                        {
                            for (int j = 0; j < col; j++)
                            {
                                if (map_isl[i, j] == 12)
                                {
                                    isled = isled + 1.33;
                                    isled = Math.Round(isled, 1);
                                    Progress_Bar(ref isled, ref isled_bar);
                                }
                            }
                        }
                        Console.WriteLine("Исследование карты: {0}%, {1}", isled, isled_bar);
                        DrawMap(map, row, col);
                        break;
                }

                Enemy(map, row, col);
            }
            while (_while1);
            if (enemy1 == 1)
                enemy_string = "нота";
            else
                enemy_string = "нот";
            if (turn == 41 | turn == 51 | turn == 61 | turn == 71 | turn == 81 | turn == 91 | turn == 101)
                turn_string = "ход";
            else
            {
                if (turn >= 42 & turn <= 44 | turn >= 52 & turn <= 54 | turn >= 62 & turn <= 64 | turn >= 72 & turn <= 74 | turn >= 82 & turn <= 84 | turn >= 92 & turn <= 94 | turn >= 102 & turn <= 104)
                {
                    turn_string = "хода";
                }
                else
                {
                    turn_string = "ходов";
                }
            }

            Console.WriteLine("Поздравляем, Ты прошел Лабиринт!");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nТвоя статистика:");
            Console.ResetColor();
            Console.WriteLine("Карта пройдена за {0} {1}\nВсего собрано {2} {3}", turn, turn_string, enemy1, enemy_string);

            if (enemy1 == 4)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Спасибо, Ты собрал все ноты!");
                Console.ResetColor();
            }
            stopwatch.Stop(); //смотрим сколько миллисекунд было затрачено на прохождение

            double sec = (double)stopwatch.ElapsedTicks / freq; //переводим такты в секунды
            Console.WriteLine($"Лабиринт пройден за: {sec} секунд");
            Console.ReadKey();
            
        }

        static void DrawMap(int[,] map1, int row1, int col1)
        {

            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col1; j++)
                {
                    switch (map1[i, j])
                    {
                        case 0:
                            Console.Write(" ");
                            break;
                        case 1:
                            Console.Write("▓");
                            break;

                        case 12:
                            Console.Write("☺");
                            break;
                        case 13:
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("█");
                            Console.ResetColor();
                            break;
                        case 14:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("♫");
                            Console.ResetColor();
                            break;

                    }
                }
                Console.WriteLine();
            }
        }

        static void MoveLeft(int[,] map1, int row1, int col1, ref bool _while1, ref int turn1, ref int[,] map2, ref int enemy)
        {
            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col1; j++)
                {
                    if (map1[i, j] == 12)
                    {
                        if (map1[i, j - 1] == 0)
                        {
                            map1[i, j - 1] = 12;
                            map2[i, j - 1] = 12;
                            map1[i, j] = 0;
                            turn1 = turn1 + 1;
                        }
                        else
                        {
                            if (map1[i, j - 1] == 13)
                            {
                                map1[i, j - 1] = 12;
                                map2[i, j - 1] = 12;
                                map1[i, j] = 0;
                                turn1 = turn1 + 1;
                                _while1 = false;
                            }
                            else
                            {
                                if (map1[i, j - 1] == 14)
                                {
                                    map1[i, j - 1] = 12;
                                    map2[i, j - 1] = 12;
                                    map1[i, j] = 0;
                                    turn1 = turn1 + 1;
                                    enemy = enemy + 1;
                                }
                            }
                        }
                    }
                }
            }
        }
        static void MoveRight(int[,] map1, int row1, int col1, ref bool _while1, ref int turn1, ref int[,] map2, ref int enemy)
        {
            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col1; j++)
                {
                    if (map1[i, j] == 12)
                    {
                        if (map1[i, j + 1] == 0)
                        {
                            map1[i, j + 1] = 12;
                            map2[i, j + 1] = 12;
                            map1[i, j] = 0;
                            turn1 = turn1 + 1;
                            i = 9;
                            j = 19;
                        }
                        else
                        {
                            if (map1[i, j + 1] == 13)
                            {
                                map1[i, j + 1] = 12;
                                map1[i, j] = 0;
                                turn1 = turn1 + 1;
                                _while1 = false;
                            }
                            else
                            {
                                if (map1[i, j + 1] == 14)
                                {
                                    map1[i, j + 1] = 12;
                                    map1[i, j] = 0;
                                    turn1 = turn1 + 1;
                                    enemy = enemy + 1;
                                }
                            }
                        }
                    }
                }
            }
        }
        static void MoveUp(int[,] map1, int row1, int col1, ref bool _while1, ref int turn1, ref int[,] map2, ref int enemy)
        {
            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col1; j++)
                {
                    if (map1[i, j] == 12)
                    {
                        if (map1[i - 1, j] == 0)
                        {
                            map1[i - 1, j] = 12;
                            map2[i - 1, j] = 12;
                            map1[i, j] = 0;
                            turn1 = turn1 + 1;
                        }
                        else
                        {
                            if (map1[i - 1, j] == 13)
                            {
                                map1[i - 1, j] = 12;
                                map1[i, j] = 0;
                                turn1 = turn1 + 1;
                                _while1 = false;
                            }
                            else
                            {
                                if (map1[i - 1, j] == 14)
                                {
                                    map1[i - 1, j] = 12;
                                    map1[i, j] = 0;
                                    turn1 = turn1 + 1;
                                    enemy = enemy + 1;
                                }
                            }
                        }
                    }
                }
            }
        }
        static void MoveDown(int[,] map1, int row1, int col1, ref bool _while1, ref int turn1, ref int[,] map2, ref int enemy)
        {
            for (int i = 0; i < row1; i++)
            {
                for (int j = 0; j < col1; j++)
                {
                    if (map1[i, j] == 12)
                    {
                        if (map1[i + 1, j] == 0)
                        {
                            map1[i + 1, j] = 12;
                            map2[i + 1, j] = 12;
                            map1[i, j] = 0;
                            turn1 = turn1 + 1;
                            i = 9;
                            j = 19;
                        }
                        else
                        {
                            if (map1[i + 1, j] == 13)
                            {
                                map1[i + 1, j] = 12;
                                map2[i + 1, j] = 12;
                                map1[i, j] = 0;
                                turn1 = turn1 + 1;
                                _while1 = false;
                            }
                            else
                            {
                                if (map1[i + 1, j] == 14)
                                {
                                    map1[i + 1, j] = 12;
                                    map2[i + 1, j] = 12;
                                    map1[i, j] = 0;
                                    turn1 = turn1 + 1;
                                    enemy = enemy + 1;
                                }
                            }
                        }
                    }
                }
            }
        }
        static void Progress_Bar(ref double isled1, ref string isled_bar1)
        {
            if (isled1 > 0 & isled1 <= 20)
            {
                isled_bar1 = "[►....]";
            }
            else
            {
                if (isled1 > 20 & isled1 <= 40)
                {
                    isled_bar1 = "[►►...]";
                }
                else
                {
                    if (isled1 > 40 & isled1 <= 60)
                    {
                        isled_bar1 = "[►►►..]";
                    }
                    else
                    {
                        if (isled1 > 60 & isled1 <= 80)
                        {
                            isled_bar1 = "[►►►►.]";
                        }
                        else
                        {
                            if (isled1 > 80 & isled1 <= 100)
                            {
                                isled_bar1 = "[►►►►►]";
                            }
                        }
                    }
                }
            }
        }
        static void Enemy(int[,] map1, int row1, int col1)
        {
            Random rnd = new Random();
            int random_move = rnd.Next(1, 4);
            if (random_move == 1)
            {
                for (int i = 0; i < row1; i++)
                {
                    for (int j = 0; j < col1; j++)
                    {
                        if (map1[i, j] == 14)
                        {
                            if (map1[i, j - 1] == 0)
                            {
                                map1[i, j - 1] = 14;
                                map1[i, j] = 0;
                            }
                        }
                    }
                }
            }
            if (random_move == 2)
            {
                for (int i = 0; i < row1; i++)
                {
                    for (int j = 0; j < col1; j++)
                    {
                        if (map1[i, j] == 14)
                        {
                            if (map1[i, j + 1] == 0)
                            {
                                map1[i, j + 1] = 14;
                                map1[i, j] = 0;
                                i = 9;
                                j = 19;
                            }
                        }
                    }
                }
            }
            if (random_move == 3)
            {
                for (int i = 0; i < row1; i++)
                {
                    for (int j = 0; j < col1; j++)
                    {
                        if (map1[i, j] == 14)
                        {
                            if (map1[i - 1, j] == 0)
                            {
                                map1[i - 1, j] = 14;
                                map1[i, j] = 0;
                            }
                        }
                    }
                }
            }
            if (random_move == 4)
            {
                for (int i = 0; i < row1; i++)
                {
                    for (int j = 0; j < col1; j++)
                    {
                        if (map1[i, j] == 14)
                        {
                            if (map1[i + 1, j] == 0)
                            {
                                map1[i + 1, j] = 14;
                                map1[i, j] = 0;
                                i = 9;
                                j = 19;
                            }
                        }
                    }
                }
            }
        }
 
    }
}