using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    internal class MockTesterManager: DeliveryManager
    {
        public override Restaurant ChoosingResturant()
        {
            string city = "Скадовськ";
            Random random = new Random();
            int chosenResturant = random.Next(1,9);
            ResNames chosenName;
            ResTypes chosenType;
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
            Restaurant ChoRestaurant = new Restaurant(chosenName, chosenType, city);
            return ChoRestaurant;
        }
        public override Order CreateOrder(Client client, DeliveryManager Delmanager, Restaurant res)
        {
            DishList = res.DishList;
            Order Order = new Order(new List<Dish>(), res, client);
            Random random = new Random();
            int dish=random.Next(1,4);
            int dishco;
            for (int i = 0; i<dish; i++)
            {
                dishco = random.Next(0, DishList.Count);
                Order.DishList.Add(DishList[dishco]);
            }
            return Order;
        }
        public override void ChosingCourier()
        {
            courier = GenCourier();
            courier.CourierInfo();
        }
        public override void OrderDelievery(Order order)
        {
            base.OrderDelievery(order);
        }
    }
}
