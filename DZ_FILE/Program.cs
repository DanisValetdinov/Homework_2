using System;
using System.Text.RegularExpressions;

namespace std
{
    class Program
    {
        public static void Main()
        {
            /*1. Выведите на экран информацию о каждом типе данных в виде:
            Тип данных – максимальное значение – минимальное значение*/
            Console.WriteLine("Задание 1. Вывести на экран тип данных, их максимальное и минимальное значения");
            Console.WriteLine("Тип данных - максимальное значение - минимальное значение\n" +
                $"byte - 255 - 0\n" +
                $"sbyte - 127 - -128\n" +
                $"short - 768 - -32\n" +
                $"ushort - 65535 - 0\n" +
                $"int - 2 147 483 647 - -2 147 483 648\n" +
                $"uint - 4 294 967 295 - 0\n" +
                $"long - 9 223 372 036 854 775 807 - -9 223 372 036 854 775 807\n" +
                $"ulong - 18 446 744 073 709 551 615 - 0\n" +
                $"float - 3.402823e38 - -3.402823e38\n" +
                $"double - 1.797693e308 - -1.797693e308\n" +
                $"decimal - 7.922816e28 - -7.922816e28\n");

            /*2. Напишите программу, в которой принимаются данные пользователя в виде имени,
            города, возраста и PIN-кода. Далее сохраните все значение в соответствующей
            переменной, а затем распечатайте всю информацию в правильном формате.*/
            Console.WriteLine("Задание 2. Вывести в консоль данные пользователя в правильном формате");
            Console.Write("Введите имя пользователя:");
            string name = Console.ReadLine();
            Console.Write("Введите город проживания пользователя:");
            string town = Console.ReadLine();
            Console.Write("Введите возраст пользователя:");
            int age = 0;
            bool is_age = int.TryParse(Console.ReadLine(), out age);
            Console.Write("Введите PIN-код пользователя:");
            int pin_code = 0;
            bool is_pin = int.TryParse(Console.ReadLine(), out pin_code);
            (string, string, int, int) tuple = ("", "", 0, 0);
            if (is_pin && is_age)
            {
                tuple.Item1 = name;
                tuple.Item2 = town;
                tuple.Item3 = age;
                tuple.Item4 = pin_code;
                Console.WriteLine($"Имя пользователя:{tuple.Item1}\nГород пользователя:{tuple.Item2}\nВозраст пользователя:{tuple.Item3}\nPIN-код пользователя:{tuple.Item4}");
            }
            else
            {
                Console.WriteLine("Ваши данные некорректны");
            }


            /*3. Преобразуйте входную строку: строчные буквы замените на заглавные, заглавные – на строчные.*/
            Console.WriteLine("Задание 3. Изменить строчные буквы на заглавные и наоборот");
            Console.Write("Введите строку:");
            string str = Console.ReadLine();
            string answer = "";
            if (Regex.IsMatch(str, @"^[a-zA-Zа-яА-Я]+$"))
            {
                int len = str.Length;
                for (int i = 0; i < len; i++)
                {
                    if (str[i] == char.ToLower(str[i]))
                    {
                        answer += char.ToUpper(str[i]);
                    }
                    else
                    {
                        answer += char.ToLower(str[i]);
                    }

                }
                Console.WriteLine(answer);
            }
            else
            {
                Console.WriteLine("Вы ввели не только буквы");
            }


            /*4. Введите строку, введите подстроку. Необходимо найти количество вхождений и вывести на экран.*/
            Console.WriteLine("Задание 4. Найти количество вхождений подстроки в строку и вывести на экран");
            Console.Write("Введите строку:");
            string str1 = Console.ReadLine();
            Console.Write("Введите подстроку:");
            string str2 = Console.ReadLine();
            int index, len1;
            int answer1 = 0;
            if (str1.Length > 0 && str2.Length > 0)
            {
                if (str1.Contains(str2))
                {
                    while (str1.Contains(str2))
                    {
                        len1 = str2.Length;
                        index = str1.IndexOf(str2);
                        str1 = str1.Remove(index, len1);
                        answer1 += 1;
                    }
                    Console.WriteLine($"Количество вхождений: {answer1}");
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
            else
            {
                Console.WriteLine("Ваша строка пуста");
            }


            /*5. Цель этой задачи - определить, сколько бутылок виски беспошлинной торговли вам
            нужно будет купить, чтобы экономия по сравнению с обычной средней ценой фактически
            покрыла расходы на ваш отпуск. Вам будет предоставлена стандартная цена (normPrice),
            скидка в Duty Free (salePrice) и стоимость отпуска (holidayPrice). Например, если бутылка
            обычно стоит 10 фунтов стерлингов, а скидка в дьюти фри составляет 10%, вы
            сэкономите 1 фунт стерлингов на каждой бутылке. Если ваш отпуск стоит 500 фунтов
            стерлингов, ответ, который вы должны вернуть, будет 500. Все входные данные будут
            целыми числами. Пожалуйста, верните целое число. Округлить в меньшую сторону.*/
            Console.WriteLine("Задание 5. Определить сколько бутылок нужно купить, чтобы фактически покрыть расходы от отпуска");
            int normPrice, salePrice, holidayPrice;
            Console.Write("Введите стандартную цену:");
            bool isnum1 = int.TryParse(Console.ReadLine(), out normPrice);
            Console.Write("Введите скидку(в %):");
            bool isnum2 = int.TryParse(Console.ReadLine(), out salePrice);
            Console.Write("Введите стоимость отпуска:");
            bool isnum3 = int.TryParse(Console.ReadLine(), out holidayPrice);
            if (isnum1 && isnum2 && isnum3)
            {
                if (normPrice <= 0)
                {
                    Console.WriteLine("Привезите и мне парочку ;-)");
                }
                else if (salePrice <= 0)
                {
                    Console.WriteLine("Даже не думай, лишь деньги потратишь");
                }
                else if (salePrice >= 100)
                {
                    Console.WriteLine("Я уже лечу туда");
                }
                else if (holidayPrice <= 0)
                {
                    Console.WriteLine("Ты собрался отдыхать на помойке?");
                }
                else
                {
                    Console.WriteLine($"Вам необходимо купить {holidayPrice / (normPrice * salePrice / 100)} бутылок, чтобы фактически покрыть расходы на отпуск");
                }

            }
            else
            {
                Console.WriteLine("Ваши данные некорректны");
            }
        }
    }
}