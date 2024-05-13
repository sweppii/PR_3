using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    internal class DeliveryManager
    {
        public Courier courier { get; set; }
        public List<Dish> DishList { get; set; }
        public string Address { get; set; }
        public DeliveryManager()
        {
            
        }
        public virtual Restaurant ChoosingResturant()
        {
            while (true)
            {
                Console.WriteLine("Введіть місто: ");
                string city = Console.ReadLine();
                Console.WriteLine("Оберіть ресторан:\n" +
                                  "------------------\n" +
                                  "ПузатаХата = 1,\n" +
                                  "LvivCroissants = 2,\n" +
                                  "McDonalds = 3,\n" +
                                  "KFC = 4,\n" +
                                  "BurgerKing = 5,\n" +
                                  "AromaKava = 6,\n" +
                                  "StarBucks = 7,\n" +
                                  "DominosPizza = 8");
                int chosenResturant = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                ResNames chosenName;
                ResTypes chosenType;
                if (chosenResturant < 1 || chosenResturant > 10)
                {
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    continue;
                }
                else
                {
                    chosenName = (ResNames)chosenResturant;
                    switch (chosenName)
                    {
                        case ResNames.McDonalds:
                        case ResNames.KFC:
                        case ResNames.BurgerKing:
                            chosenType = ResTypes.Фастфуд;
                            break;
                        case ResNames.ПузатаХата:
                        case ResNames.LvivCroissants:
                            chosenType = ResTypes.ГромадськеХарчування;
                            break;
                        case ResNames.AromaKava:
                        case ResNames.StrarBucks:
                            chosenType = ResTypes.Кафе;
                            break;
                        case ResNames.DominosPizza:
                            chosenType = ResTypes.Піцерія;
                            break;
                        default:
                            chosenType = ResTypes.Кафе;
                            break;
                    }
                }
                Restaurant ChoRestaurant = new Restaurant(chosenName, chosenType, city);
                ChoRestaurant.Info();

                Console.WriteLine("Вас все задовольняє? (1) так (2) ні");
                int satisfactionResponse = Int32.Parse(Console.ReadLine());
                switch (satisfactionResponse)
                {
                    case 1:
                        Console.Clear();
                        return ChoRestaurant;
                    case 2:
                        Console.WriteLine("Давайте спробуємо знову.");
                        break;
                    default:
                        Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                        break;
                }

                Console.Clear();
            }
        }
        public virtual Order CreateOrder(Client client, DeliveryManager Delmanager, Restaurant res)
        {
            DishList= res.DishList;
            Order Order = new Order(new List<Dish>(), res, client);
            while(true)
            {
                Order.DishList.Add(DishInfo());
                Console.WriteLine("Бажаєте додати ще одну страву ? (1 - так, 2 - ні)");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        break;
                    case 2:
                        Order.OrderInfo("Замовлення складене");
                        return Order;
                    default:
                        Console.WriteLine("Будь ласка, виберіть так чи ні");
                        break;
                }
            }
        }
        public virtual Dish DishInfo()
        {
            Console.WriteLine("-----------------------------------\n" +
                              "Оберіть страви які хочете замовити:");
            for(int i = 0; i < DishList.Count; i++)
            {
                Console.WriteLine($"{i + 1}:{DishList[i].Name}\n" +
                                          $"{DishList[i].Description}\n" +
                                          $"Ціна: {DishList[i].Price}\n" +
                                          $"Калорійність: {DishList[i].Calories}\n");

            }
            int chodish = Convert.ToInt32(Console.ReadLine());
            if ( chodish <1 || chodish>DishList.Count)
            {
                Console.WriteLine("Такого блюда немає, спробуйте ще раз");
                return DishInfo();
            }
            Console.Clear();    
            return DishList[chodish - 1];
        }
        public Courier GenCourier()
        {
            Random random = new Random();
            string couriername = Courier.courierNames[random.Next(Courier.courierNames.Count)];
            string couriercont = random.Next(1000000, 9999999).ToString();
            int courierrating = random.Next(1, 5);
            string couriertransport = Courier.courierTransports[random.Next(Courier.courierTransports.Count)];
            Courier courier = new Courier(couriername, couriercont, courierrating, couriertransport);
            return courier;
        }
        public virtual void ChosingCourier()
        {
            courier = GenCourier();
            courier.CourierInfo();
        }
        public virtual void OrderDelievery(Order order)
        {
            order.OrderInfo("Сплачено, готується");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            order.OrderInfo("Замовлення готове");
            System.Threading.Thread.Sleep(4000);
            Console.Clear();
            order.OrderInfo("Очікування кур'єра");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            order.OrderInfo("Замовлення у дорозі");
            System.Threading.Thread.Sleep(5000);
            Console.Clear();
            order.OrderInfo("Замовлення доставленно");
            Random random = new Random();
            int delval = random.Next(150, 300);
            Console.WriteLine($"Дякуємо за те що обрали нас!\n" +
                              $"Ціна доставки:{delval}");
        }
    }
}
