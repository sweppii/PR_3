using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.InputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("Вас вітає наша служба доставки ! Оберіть подальші дії:\n" +
                    "1 - Ввести дані самостійно, 2 - Скористатися автозаповненням (тестовий режим)");
                int test = Convert.ToInt32(Console.ReadLine());
                switch (test) 
                {
                    case 1:

                        Client client = new Client();
                        client.ClientInfo();
                        DeliveryManager deliveryManager = new DeliveryManager();
                        Restaurant Res;
                        Res = deliveryManager.ChoosingResturant();
                        Res.Info();
                        Order order = deliveryManager.CreateOrder(client, deliveryManager, Res);
                        Console.Clear();
                        order.OrderInfo("Очікування сплати");
                        Console.WriteLine("Введіть номер карти:");
                        Console.ReadLine();
                        Console.Clear();
                        bool Cho = true;
                        while (Cho == true)
                        {
                            deliveryManager.ChosingCourier();
                            Console.WriteLine("Чи хочете нового кур'єра? (1 - так 2 - ні)");
                            int cho = Convert.ToInt32(Console.ReadLine());
                            switch (cho)
                            {
                                case 1:
                                    Console.Clear();
                                    break;
                                case 2:
                                    Cho = false;
                                    Console.Clear();
                                    break;
                                default:
                                    Console.WriteLine("Будь ласка, оберіть так чи ні");
                                    break;
                            }
                        }
                        deliveryManager.OrderDelievery(order);
                        Console.ReadLine();
                        return;
                    case 2:
                        MockTester clienttest = new MockTester();
                        MockTesterManager deliveryManagetest = new MockTesterManager();
                        Restaurant Restest;
                        Restest = deliveryManagetest.ChoosingResturant();
                        Restest.Info();
                        Order ordertest = deliveryManagetest.CreateOrder(clienttest, deliveryManagetest, Restest);
                        Console.ReadLine();
                        Console.Clear();
                        deliveryManagetest.ChosingCourier();
                        Console.ReadLine();
                        deliveryManagetest.OrderDelievery(ordertest);
                        Console.ReadLine();
                        return;

                }
            }
        }
    }
}
