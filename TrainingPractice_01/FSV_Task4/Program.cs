using System;
using System.Threading;

namespace FSV_Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Random rnd = new Random();
            int healtogr = rnd.Next(300, 500);
            int damageogr;
            int healthplayer = rnd.Next(150, 350);
            int manaplayer = rnd.Next(100, 400);
            bool startGame = true;
            string castspell;

            Console.WriteLine("Огр-налетчик атакует! К бою!\n \nВыберите заклинания для атаки или лечения: \n" +
                "1. Огненный шар - Шар наносит 50 урона, отнимает 15 единиц маны.\n" +
                "2. Зов к шаману - Востанавливает игроку  20 здоровья, отнимает 30 единиц маны.\n" +
                "3. Световой меч - Удар молнией наносит 100 урона, отнимает 50 единиц маны.\n" +
                "4. ГеоШторм - Порыв ветра наносит 80 урона, отнимает 30 единиц маны и отнимает 10xp у вашего персонажа.\n" +
                "5. Звездопад - Каменный дождь  наносит 35 урона каждую секунду, отнимает 120 единиц маны.\n");


            while (startGame)
            {
                damageogr = rnd.Next(20, 85);
                Console.WriteLine($"\nСтатистика Огра: \n Здоровье: {healtogr} , Урон: {damageogr} \n\nСтатистика игрока: \n Здоровье: {healthplayer} , Мана: {manaplayer} \n");
                Console.Write("Введите заклинание: ");
                castspell = Console.ReadLine();
                if (manaplayer <= 15)
                {
                    startGame = false;
                    Console.WriteLine("\nИгра окончена, недостаточно маны для продолжения битвы");
                }
                else if (healtogr <= 0)
                {
                    startGame = false;
                    Console.WriteLine("\nОгр повержен");
                }
                else if (healthplayer <= 0)
                {
                    startGame = false;
                    Console.WriteLine("\nИгрок погиб");
                }
                else
                {
                    switch (castspell)
                    {
                        case "Огненный шар":
                            if (manaplayer >= 15)
                            {
                                healtogr -= 40;
                                Console.WriteLine("\nОгр потерял 50 единиц здоровья");
                                manaplayer -= 15;
                                healthplayer -= damageogr;
                                Console.Write($"\nОгр атаковал дубиной смерти - игрок потерял {damageogr} здоровья\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;

                        case "Зов к шаману":
                            if (manaplayer >= 30)
                            {
                                manaplayer -= 30;
                                healthplayer += 20;
                                Console.WriteLine($"\nВаше текущее здоровье равно: {healthplayer}");
                            }
                            else if (healthplayer >= 349)
                            {
                                Console.WriteLine("\nУ вас полный запас здоровья");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;

                        case "Световой меч":
                            if (manaplayer >= 50)
                            {
                                Console.WriteLine("\nОгр потерял 100 единиц здоровья");
                                healtogr -= 100;
                                manaplayer -= 50;
                                healthplayer -= damageogr;
                                Console.Write($"\nОгр выпустил адские стрелы которые нанесли {damageogr} урона\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;

                        case "Звездопад":
                            if (manaplayer >= 120)
                            {
                                int rockrain = 0;
                                for (int i = 1; i < 6; i++)
                                {
                                    rockrain += 35;
                                    Thread.Sleep(1000);
                                    healtogr -= 35;
                                    Console.Write($"Атака каменным дождем наносит урон Огру {rockrain}:  \nПродолжительность атаки {i} секунды");
                                    Console.WriteLine();
                                }
                                Console.WriteLine("\nОгр потерял после атаки 175 единиц здоровья");
                                manaplayer -= 40;
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;

                        case "ГеоШторм":
                            if (manaplayer > 30)
                            {
                                healtogr -= 80;
                                Console.WriteLine("\nОгр потерял 80 единиц здоровья");
                                manaplayer -= 30;
                                healthplayer -= damageogr;
                                healthplayer -= 10;
                                Console.Write($"\nОгр атаковал кинжалом ужаса - игрок потерял {damageogr} здоровья\n");
                            }
                            else
                            {
                                Console.WriteLine("\nУ вас не достаточно маны!");
                            }
                            break;
                        default:
                            Console.WriteLine($"\nВам незнакомо {castspell} это заклинание");
                            break;
                    }

                }
            }


        }
    }
}
