using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Laba3
{
    internal class Order
    {
        public string OrderStatus { get; set; }
        public double TotalAmout { get; set; }
        public List<Dish> DishList { get; set; }
        public Restaurant Restaurant { get; set; }
        public Courier Courier { get; set; }
        public Client Client { get; set; }
        public Order(List<Dish> dishList, Restaurant restaurant, Client client)
        {
            DishList = dishList;
            Restaurant = restaurant;
            Client = client;
        }
        private double CalcTotalAmount()
        {
            double total = 0;
            foreach (var dish in DishList)
            {
                total += dish.Price;
            }
            return total;
        }
        private double CalcTotalCal()
        {
            double total = 0;
            foreach(var dish in DishList)
            {
                total += dish.Calories;
            }
            return total;
        }
        public void OrderInfo(string status)
        {
            OrderStatus = status;
            Console.WriteLine($"Статус замовлення: {OrderStatus} \n" +
                              $"Клієнт: {Client.Name} \n" +
                              $"Контактний номер клієнта: {Client.Contacts} \n" +
                              $"Адреса доставки: {Client.Adress}\n" +
                              $"Склад замовлення: ");
            for(int i = 0; i < DishList.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {DishList[i].Name}");
            }
            
            Console.WriteLine($"Сумарна ціна: {CalcTotalAmount()} \n" +
                              $"Сумарна калорійність: {CalcTotalCal()}");
        }
    }
}
