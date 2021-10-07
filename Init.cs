using System;

using Clients;
using UI;

namespace InitialiseApp
{
    public class App
    {
        ClientManager clientManager = new ClientManager();

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
                        clientManager.Register();
                        break;

                    case LOGIN:
                        clientManager.Login();
                        if (clientManager.clientLoggedIn == true)
                        {
                            ClientMenu();
                        }
                        // else
                        // {
                        //     continue;
                        // }
                        break;
    
                    case EXIT:
                        Console.WriteLine("Thank you for using Auctioneer!");
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
                int clientOption = UserInterface.GetOption("\nProceed by choosing from the following:",
                    "Advertise a product", "Search for a product", "Make a bid", "View my products for sale", "View bids on my products",
                    "Sell a product", "Logout"
                    );
                
                switch (clientOption)
                {
                    case ADVERTISE_PROD:
                        // Product.Advertise();
                        Console.Write("Ad success");
                        
                        foreach (var client in clientManager.clientData)
                        {
                            Console.WriteLine($"\n{client.name}\n{client.email}");
                        }
                        break;
                    case SEARCH_PROD:
                        // Product.Search();
                        Console.Write("Search success");
                        break;
                    case MAKE_BID:
                        // Product.Bid();
                        Console.Write("Bid success");
                        break;
                    case PROD_LIST:
                        // Product.List();
                        Console.Write("Prod list success");
                        break;
                    case BID_LIST:
                        Console.Write("Bid list success");
                        break;
                    case SELL_PROD:
                        Console.Write("Sell success");
                        break;
                    case LOGOUT:
                        Console.Clear();
                        Console.WriteLine("\nLogging out...");
                        clientManager.clientLoggedIn = false;
                        client_running = false;
                        //StartMenu();
                        break;
                    default: break;
                }

            }
        }
    }
}