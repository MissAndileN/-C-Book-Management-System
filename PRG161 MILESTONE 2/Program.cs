using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;

namespace PRG161_Milestone2_2024
{
    class Program
    {
        //ENUMS
        enum MenuOptions
        {
            AddCustomer,
            CalculateDiscount,
            OrderMedia,
            Checkout,
            Exit
        }

        enum MediaTypes
        {
            VHS = 1,
            DVD,
            CD
        }
        //we used static to show that thare is only one cart shared by all instances
        static List<string> cart = new List<string>();
        static decimal totalPrice = 0m;

        static void Main(string[] args)
        {
            // Done by Nkosinathi Nyathi
            bool exit = false;
            while (!exit)
            {
                switch (DisplayMainMenu())
                {
                    case MenuOptions.AddCustomer:
                        AddCustomer();
                        break;
                    case MenuOptions.CalculateDiscount:
                        CalculateDiscount();
                        break;
                    case MenuOptions.OrderMedia:
                        OrderMedia();
                        break;
                    case MenuOptions.Checkout:
                        Checkout();
                        break;
                    case MenuOptions.Exit:
                        exit = true;
                        break;
                }
            }
        }

        //Main menu method by Nkosinathi Nyathi
        static MenuOptions DisplayMainMenu()
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Add Customer");
            Console.WriteLine("2. Calculate Discount");
            Console.WriteLine("3. Order Media");
            Console.WriteLine("4. Checkout");
            Console.WriteLine("5. Exit");
            int choice = int.Parse(Console.ReadLine());
            return (MenuOptions)(choice - 1); //we used "(choice - 1)" to convert the user's menu selection which is an integer into an enum value representing the type of media.
        }

        //Add customer method by Andile Ntuli
        static void AddCustomer()
        {
            Console.WriteLine("Enter customer name:");
            string name = Console.ReadLine();
            Console.WriteLine($"Customer Name: {name}");
            Console.WriteLine("Enter registration date (yyyy-mm-dd):");
            DateTime regDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine($"Registration Date: {regDate.ToShortDateString()}");
            //used timespan to show time difference between now and registration date
            TimeSpan regPeriod = DateTime.Now - regDate;
            if (regPeriod.Days > 5 * 365)
            {
                Console.WriteLine("No discount for registration period over 5 years.");
            }
        }

        //Calculate discount method by Andile Ntuli
        static void CalculateDiscount()
        {
            Console.WriteLine("Enter registration date (yyyy-mm-dd):");
            DateTime regDate = DateTime.Parse(Console.ReadLine());
            TimeSpan regPeriod = DateTime.Now - regDate;

            if (regPeriod.Days < 5 * 365)
            {
                Console.WriteLine("5% discount.");
            }
            else if (regPeriod.Days >= 5 * 365 && regPeriod.Days < 10 * 365)
            {
                Console.WriteLine("10% discount.");
            }
            else if (regPeriod.Days >= 10 * 365 && regPeriod.Days < 15 * 365)
            {
                Console.WriteLine("20% discount.");
            }
            else
            {
                Console.WriteLine("35% discount.");
            }
        }

        //Order media method by Nkosinathi Nyathi
        static void OrderMedia()
        {
            Console.WriteLine("Select media type to order:");
            Console.WriteLine("1. VHS");
            Console.WriteLine("2. DVD");
            Console.WriteLine("3. CD");
            int choice = int.Parse(Console.ReadLine());




            Console.WriteLine("Enter price of the item:");
            decimal price = decimal.Parse(Console.ReadLine());
            totalPrice += price;
        }

        //Checkout method by Andile Ntuli
        static void Checkout()
        {
            Console.WriteLine("Checkout:");
            Console.WriteLine("Items in your cart:");
            foreach (var item in cart)
            {
                Console.WriteLine(item);
            }

            decimal discount = CalculateTotalDiscount();
            decimal finalPrice = totalPrice - (totalPrice * discount / 100);

            Console.WriteLine($"Total price before discount: {totalPrice} Rand");
            Console.WriteLine($"Discount applied: {discount}%");
            Console.WriteLine($"Total price after discount: {finalPrice} Rands");

            // Reset cart
            cart.Clear();
            totalPrice = 0;
            Console.WriteLine("Cart has been reset.");
        }

        //Calculate total discount method by Nkosinathi Nyathi
        static decimal CalculateTotalDiscount()
        {
            Console.WriteLine("Enter registration date (yyyy-mm-dd):");
            DateTime regDate = DateTime.Parse(Console.ReadLine());
            TimeSpan regPeriod = DateTime.Now - regDate;

            if (regPeriod.Days < 5 * 365)
            {
                return 5;
            }
            else if (regPeriod.Days >= 5 * 365 && regPeriod.Days < 10 * 365)
            {
                return 10;
            }
            else if (regPeriod.Days >= 10 * 365 && regPeriod.Days < 15 * 365)
            {
                return 20;
            }
            else
            {
                return 35;
            }
        }
    }
}