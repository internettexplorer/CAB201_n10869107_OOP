using System;
using AppDB;
using UserInterfaceUtils;

namespace MainApp
{
    public class Program
    {
        
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void MainMenu()
        {
            const int REGISTER = 0, LOGIN = 1, EXIT = 2;
            
            Database session = new Database();

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
            while (running) {
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
                            Console.WriteLine("it worked");
                            running = false;
                        }
                        break;
    
                    case EXIT:
                        running = false;
                        break;

                    default: break;
                }
            }
        }
    }
}
