using System;

namespace FSV_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool enoughGold;
            int pc = 10; // заданная цена за 1 кристалл
            int gold;

            Console.WriteLine("Добро пожаловать в магазин / Лавка Волшебника! /");
            Console.WriteLine("   | Сколько у вас есть золотых монет? |   ");

            // золото у покупателя ИСКЛЮЧЕНИЕ - ЕСЛИ БУКВЫ
            if (!int.TryParse(Console.ReadLine(), out gold))
            {
                Console.WriteLine("     Вот и ошибка! Количество монет нужно указать цифрой или числом.\n     Попробуйте еще раз!");
                return;
            }

            // ИСКЛЮЧЕНИЕ - ЕСЛИ 0 МОНЕТ
            if (gold < 0 || gold ==0 )
            {
                Console.WriteLine($"     Вот и ошибка! Или у вас 0 монет или количество монет отрицательное.\n     Накопите их и приходите снова\n     Кристаллы нынче по {pc} монет за штуку");
                return;
            }

            Console.WriteLine("     Вы можете купить максимум}" + gold / pc + " кристалов по цене " + pc + " монет за штуку."); 
            Console.WriteLine("     Сколько кристаллов вы хотите купить");

            int cc = int.Parse(Console.ReadLine());//количество допустимых кристалов

            //ИСКЛЮЧЕНИЕ ЕСЛИ НЕ БЕРУТ КРИСТАЛЛЫ
            if (cc < 0 || cc == 0 )
            {
                Console.WriteLine("     Если вы не хотите ничего покупать - не тратьте моё время.\n     Вы не можете купить отрицательное количество кристаллов!");
                return ;
            }

            enoughGold = gold >= cc * pc;
            cc *= Convert.ToInt32(enoughGold);
            gold -= cc * pc; 
            
            Console.WriteLine($"Удачная покупка!\nУ вас осталось {gold} золотых и {cc} кристаллов\nДо скорых встреч!");

            Console.ReadKey();
        }
    }
}
