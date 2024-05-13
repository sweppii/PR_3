using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    public enum ResNames
    {
        ПузатаХата = 1,
        LvivCroissants = 2,
        McDonalds = 3,
        KFC = 4,
        BurgerKing = 5,
        AromaKava = 6,
        StrarBucks = 7,
        DominosPizza = 8 
    }
    public enum ResTypes
    {
        Фастфуд = 1,
        ГромадськеХарчування = 2,
        Кафе = 3,
        Піцерія = 4
    }

    internal class Restaurant
    {
        public ResNames Name { get; set; }
        public string Adress { get; set; }
        public ResTypes Type { get; set; }
        public int Rating { get; set; }
        public string City { get; set; }
        public List<Dish> DishList { get; set; }
        private static List<string> adresses = new List<string>
        {
            "Вулиця Лісова",
            "Вулиця Садова",
            "Вулиця Шевченка",
            "Вулиця Перемоги",
            "Вулиця Гагаріна",
            "Вулиця Незалежності",
            "Вулиця Зелена",
            "Вулиця Привокзальна",
        };
        public Restaurant(ResNames name, ResTypes type, string city)
        {
            Name = name;
            Type = type;
            City = city;
            Rating = GenRating();
            Adress = GenAdress();
            DishList = Dish.dishes.Where(dish => dish.Type == type).ToList();
        }
        public static int GenRating()
        {
            var random = new Random();
            return random.Next(2, 6);
        } 
        public static string GenAdress()
        {
            var random = new Random();
            int TheAdress = random.Next(adresses.Count);
            string adress = adresses[TheAdress];
            int HouseNum = random.Next(1, 301);
            return adress + ", " + HouseNum.ToString();
        }
        public void Info()
        {
            Console.WriteLine($"Назва ресторану: {Name} \n" +
                              $"Тип ресторану: {Type} \n" +
                              $"Адреса ресторану: {Adress} \n" +
                              $"Рейтинг ресторану: {Rating}");
        }

    }
}
