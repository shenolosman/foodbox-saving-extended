﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Backend;
using DataLayer.Data;

namespace FoodRescue_Projekt
{
    public class CustomerClient
    {
        private ConsoleKeyInfo cki;
        private ConsoleKeyInfo ckiMain;
        
        public void client()
        {
            var UserList = AdminBackend.AllUsers();
            var UserNameList = new List<string>();

            foreach (var user in UserList)
            {
                UserNameList.Add(user.Username);
            }

            while (cki.Key != ConsoleKey.Escape)
            {
                string username = "";
                bool loggedin = false;

                    Console.Clear();
                    Console.WriteLine("Press any key to login");
                    Console.WriteLine("Press ESCAPE to exit");
                    cki = Console.ReadKey();
                    if (cki.Key == ConsoleKey.Escape) break;
                    Console.Clear();
                    Console.Write("Username: ");
                    username = Console.ReadLine();
                    if (!UserNameList.Contains(username))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("User does not exist...");
                        Console.ResetColor();
                        Thread.Sleep(1000);
                    }

                    loggedin = UserNameList.Contains(username);

                while (loggedin)
                {
                    Console.Clear();
                    do
                    {
                        Console.WriteLine("[1]: View Products [2]: View purchase history");
                        cki = Console.ReadKey();
                        if (cki.Key == ConsoleKey.Backspace)
                        {
                            do
                            { 
                                Console.Clear();
                                Console.WriteLine("Are you sure you want to log out?[Y/N]");
                                var choise = Console.ReadKey();
                                if (choise.Key == ConsoleKey.Y)
                                {
                                    loggedin = false;
                                    username = "";
                                    break;
                                }

                                if (choise.Key == ConsoleKey.N)
                                {
                                    break;
                                }
                            } while (true);
                        }

                        if (loggedin == false)
                        {
                            break;
                        }
                    } while (cki.Key is not (ConsoleKey.D1 or ConsoleKey.D2 or ConsoleKey.Escape));

                    if (cki.Key == ConsoleKey.D1)
                    {
                        do
                        {
                            Console.Clear();
                            var FoodBoxList = UserBackend.AllUnsoldFoodBoxes();
                            foreach (var box in FoodBoxList)
                            {
                                var name = box.FoodBox;
                                while (name.Length < 25)
                                {
                                    name += " ";
                                }

                                Console.WriteLine($"{name} \t| {box.Price}kr \t| {box.ExpiryDate} \t|");
                            }

                            Console.WriteLine("Press the number of the foodbox you wish to purchase");
                            cki = Console.ReadKey();
                        } while (cki.Key != ConsoleKey.Backspace);
                    }

                    if (cki.Key == ConsoleKey.D2)
                    {
                        do
                        {
                            Console.Clear();
                            var userPurchaseHistory = UserBackend.UserPurchaseHistory(username);
                            foreach (var box in userPurchaseHistory)
                            {
                                Console.WriteLine($"{box.FoodBox} | {box.Price} | {box.ExpiryDate}");
                            }

                            cki = Console.ReadKey();
                        } while (cki.Key != ConsoleKey.Backspace);
                    }
                }

            }
        }
    }
}
