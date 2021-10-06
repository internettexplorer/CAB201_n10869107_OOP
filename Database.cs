using System;
using System.Collections.Generic;

using Clients;
using UserInterfaceUtils;

namespace AppDB 
{
    public class Database
    {
        // Storage of User class instances 
        public List<Client> clientData = new List<Client>();

        public bool clientLoggedIn = false;

        public void Register()
        {
            // Prompts user for input and creates a User instance with the provided info
            Console.Write("\nFull name: ");
            string inputName = Console.ReadLine();

            Console.Write("\nEmail: ");
            string inputEmail = Console.ReadLine();

            string inputPwd = UserInterface.GetPassword("\nPassword");

            Console.Write("\nAddress: ");
            string inputAddress = Console.ReadLine();

            Client newClient = new Client(inputName, inputEmail, inputPwd, inputAddress);

            clientData.Add(newClient);

            Console.Write($"\nNew client {newClient.name} ({newClient.email}) registered.\nLet's get auctioning!\n");
        }

        public void Login()
        {
            // Prompts user for email and pwd, with validation at each step
            string EMAIL_ERR = "Email not registered, please try again";
            string PWD_ERR = "Wrong password, please try again";

            bool loginAttempt = true;

            while (loginAttempt)
            {
                Console.Write("\nEmail: ");
                string loginEmail = Console.ReadLine();

                // Checks each entry in user list, if email matches, give password prompt.
                // If no match found, prompt for email again
                foreach (var client in clientData)
                {
                    if (loginEmail == client.email)
                    {
                        // Checks if password matches any entry in user list
                        // If a match is found, welcome user with their name, otherwise
                        // sends them back to the email prompt
                        string loginPwd = UserInterface.GetPassword("\nPassword");

                        foreach (var clientpwd in clientData)
                        {
                            if (loginPwd == clientpwd.pwd)
                            {
                                Console.WriteLine($"Welcome {clientpwd.name}");

                                clientLoggedIn = true;
                                loginAttempt = false;
                            }
                            else
                            {
                                Console.WriteLine(PWD_ERR);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(EMAIL_ERR);
                        continue;
                    }
                }
            }

         } 
    }
}