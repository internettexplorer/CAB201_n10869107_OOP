using System;
using UI; 
using InitialiseApp;

namespace Clients
{
    public class Authenticator
    {
        // Storage of User class instances 
        public void Register()
        {
            // Prompts user for input and creates a User instance with the provided info
            Console.Write("\nFull name: ");
            string inputName = Console.ReadLine();

            Console.Write("Email: ");
            string inputEmail = Console.ReadLine();

            string inputPwd = UserInterface.GetPassword("Password");

            Console.Write("Address: ");
            string inputAddress = Console.ReadLine();

            Client newClient = new Client(inputName, inputEmail, inputPwd, inputAddress);

            Session.clientData.Add(newClient);

            Console.Clear();

            Console.Write($"\nNew client {newClient.name} ({newClient.email}) registered.\nLet's get auctioning!\n");
            Console.WriteLine($"Your GUID is {newClient.clientID.ToString()}");
        }

        public void Login()
        {
            string EMAIL_ERR = "Email not registered, please try again";
            string PWD_ERR = "Wrong password, please try again";

            bool loginAttempt = true;

            while (loginAttempt)
            {
                Console.Write("\nEmail: ");
                string loginEmail = Console.ReadLine();

                string loginPwd = UserInterface.GetPassword("Password");

                // Attempts to find the index of the user email input in the clientData
                // list, if email does not exist/is incorrect print error message.
                // Stores the current Client instance in a variable if a match is found and
                // exits the loop.
                try
                {
                    Session.index = Session.clientData.FindIndex(c => c.email.Equals(loginEmail, StringComparison.Ordinal));
                    Session.currentClient = Session.clientData[Session.index];
                    
                    if (loginEmail == Session.currentClient.email && loginPwd == Session.currentClient.pwd)
                    {
                        Console.Clear();
                        Console.WriteLine($"Welcome back {Session.currentClient.name}");
                        Console.WriteLine($"{Session.currentClient.name}: {Session.index}"); // debugging purposes

                        Session.currentClient.loggedIn = true;
                        
                        loginAttempt = false;
                    }
                    else
                    {
                        Console.Write($"{PWD_ERR}\n");
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Write($"{EMAIL_ERR}\n");
                }
            }
        }

    } 
}