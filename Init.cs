using System;

using AppDB;
using Clients;
using UserInterfaceUtils;

namespace InitialiseApp
{
    public class App
    {
        Database session = new Database();

        public void StartMenu()
        {
            const int REGISTER = 0, LOGIN = 1, EXIT = 2;

            Console.WriteLine("\n");
            Console.WriteLine(@"Welcome to...");
            Console.WriteLine(@"                  _   _                            ");
            Console.WriteLine(@"                 | | (_)                           ");
            Console.WriteLine(@"  __ _ _   _  ___| |_ _  ___  _ __   ___  ___ _ __ ");
            Console.WriteLine(@" / _` | | | |/ __| __| |/ _ \| '_ \ / _ \/ _ \ '__|");
            Console.WriteLine(@"| (_| | |_| | (__| |_| | (_) | | | |  __/  __/ |   ");
            Console.WriteLine(@" \__,_|\__,_|\___|\__|_|\___/|_| |_|\___|\___|_|   ");
            Console.WriteLine("\n");

            bool running = true;
            while (running) 
            {
                int option = UserInterface.GetOption("\nPlease select one of the following",
                    "Register", "Login", "Exit"
                );

            
                switch (option)
                {
                    case REGISTER:
                        session.Register();
                        break;

                    case LOGIN:
                        session.Login();
                        if (session.clientLoggedIn == true)
                        {
                            ClientMenu();
                        }
                        break;
    
                    case EXIT:
                        running = false;
                        break;

                    default: break;
                }
            }
        }

        public void ClientMenu()
        {
            const int ADVERTISE_PROD = 0, SEARCH_PROD = 1, MAKE_BID = 2, PROD_LIST = 3, BID_LIST = 4, SELL_PROD = 5, LOGOUT = 6;

            bool client_running = true;
            while (client_running)
            {
                Console.WriteLine("\n");
                int clientOption = UserInterface.GetOption("\nMake a selection",
                    "Advertise a product", "Search for a product", "Make a bid", "View my products for sale", "View bids on my products",
                    "Sell a product", "Logout"
                    );
                
                switch (clientOption)
                {
                    case ADVERTISE_PROD:
                        Console.Write("Ad success");
                        
                        foreach (var client in session.clientData)
                        {
                            Console.WriteLine($"\n{client.name}\n{client.email}");
                        }
                        break;
                    case SEARCH_PROD:
                        Console.Write("Search success");
                        break;
                    case MAKE_BID: 
                        Console.Write("Bid success");
                        break;
                    case PROD_LIST:
                        Console.Write("Prod list success");
                        break;
                    case BID_LIST:
                        Console.Write("Bid list success");
                        break;
                    case SELL_PROD:
                        Console.Write("Sell success");
                        break;
                    case LOGOUT:
                        Console.WriteLine("Logging out...");
                        StartMenu();
                        break;
                    default: break;
                }

            }
        }
    }
}