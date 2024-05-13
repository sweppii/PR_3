using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    
    internal class Courier
    {
        public string Name { get; set; }
        public string Contacts { get; set; }
        public int Rating { get; set; }
        public string Transport {  get; set; }
        
        public static List<string> courierNames = new List<string>
        {
            "Олександр", "Анна", "Іван", "Катерина", "Володимир", "Марія", "Павло", "Ольга", "Софія", "Дмитро", "Наталія", "Сергій"
        };

        public static List<string> courierTransports = new List<string>
        {
            "Велосипед", "Автомобіль", "Електросамокат", "Байк", "Громадський транспорт", "Пішки"
        };
        public Courier(string name, string contacts, int rating, string transport)
        {
            Name = name;
            Contacts = contacts;
            Rating = rating;
            Transport = transport;
        }
        public void CourierInfo()
        {
            Console.WriteLine($"Ім'я кур'єра: {Name}\n" +
                              $"Контактний номер телефону кур'єра: +38066{Contacts}\n" +
                              $"Рейтинг кур'єра: {Rating}/5\n" +
                              $"Спосіб транспортування замовлення: {Transport}");
        }

    }
}
