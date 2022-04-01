using System;

namespace FSV_Task3_1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string password = "1234";
            string enterthepassword;
            int tryingcounter = 3;
            string secret_message = "Он не поздравил бабушку с Юбилеем...";

            while (tryingcounter > 0)
            {
                Console.Write("Введите пароль для доступа к сообщению\nУ вас есть изначально 3 попытки: ");
                enterthepassword = Console.ReadLine();
                if (password == enterthepassword)
                {
                    Console.WriteLine("Ваше секретеное сообщение: \n\n" + secret_message);
                    Console.ReadLine();
                    break;
                }
                else
                {
                    tryingcounter--;
                    Console.WriteLine("Вы ввели неправильный пароль у вас осталось: " + tryingcounter + " попытки что ввести правильный пароль \n");
                    if (tryingcounter == 0)
                    {
                        Console.WriteLine("Все пароли неверны, попробуйте позже");
       
                    }
                }
            }

        }
    }
}
