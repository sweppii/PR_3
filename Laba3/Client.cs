using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    internal class Client
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public int Contacts { get; set; }
        public List<Order> OrdersHistory { get; set; }

        public Client()
        {
            OrdersHistory = new List<Order>();
        }
        public void ClientInfo ()
        {
            while (true)
            {
                try
                {
                    while (true)
                    {
                        Console.WriteLine("Введіть ваше ім'я:");
                        string name = Console.ReadLine();
                        if (name.All(Char.IsLetter))
                        {
                            Name = name;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Ім'я може містити лише букви");
                        }
                    }
                        Console.WriteLine("Введіть вашу адресу:");
                        Adress = Console.ReadLine();
                        while (true)
                        {
                        Console.Write("Введіть ваш контактний номер телефону:\n" +
                                        "+380");
                        string number = Console.ReadLine();
                        if (number.Length == 9)
                            {
                                Contacts = Convert.ToInt32(number);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Невірно вказаний номер");
                            }
                        }
                    while (true)
                    {
                        Console.WriteLine("Бажаєте щось змінити ? (1 - так, 2 - ні)");
                        string answer = Console.ReadLine();
                        switch (answer)
                        {
                            case "1":
                                {
                                    Console.WriteLine("Що ви хочете змінити ? (1 - Ім'я, 2 - Адресу, 3 - Номер телефону)");
                                    answer = Console.ReadLine();
                                    switch (answer)
                                    {
                                        case "1":
                                             { 
                                                while (true)
                                                {
                                                    Console.WriteLine("Введіть ваше ім'я:");
                                                    string name1 = Console.ReadLine();
                                                    if (name1.All(Char.IsLetter))
                                                    {
                                                        Name = name1;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Ім'я може містити лише букви");
                                                    }
                                                }
                                                break;
                                            }
                                        case "2":
                                            {
                                                Console.WriteLine("Введіть вашу адресу:");
                                                Adress = Console.ReadLine();
                                            }
                                            break;
                                        case "3":
                                            {
                                                while (true)
                                                {
                                                    Console.Write("Введіть ваш контактний номер телефону:\n" +
                                                                    "+380");
                                                    string number1 = Console.ReadLine();
                                                    if (number1.Length == 9)
                                                    {
                                                        Contacts = Convert.ToInt32(number1);
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Невірно вказаний номер");
                                                    }
                                                }
                                            }
                                            break;
                                    }
                                    break;
                                }
                            case "2":
                                {
                                    return;
                                }
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}.");
                }
            }
        }
    }
}
