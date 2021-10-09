using System;
using System.Collections.Generic;

using UI;

namespace Clients
{
    public class Client
    {
        
        public string name {get; set;}
        public string email {get; set;}
        public string pwd {get; set;}
        public string address {get; set;}
        public Guid clientID {get; private set;}

        public bool loggedIn;
    
        // eventually want to have support for products and bid (classes?) in this class

        public Client(string name, string email, string pwd, string address) 
        {
            this.name = name;
            this.email = email;
            this.pwd = pwd;
            this.address = address;
            this.clientID = Guid.NewGuid();
        }  
    }

    public class ClientManager
    {
        // Storage of User class instances 
        public List<Client> clientData = new List<Client>();
        public Client currentClient;
        public int index;

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

            clientData.Add(newClient);

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
                    index = clientData.FindIndex(c => c.email.Equals(loginEmail, StringComparison.Ordinal));
                    currentClient = clientData[index];
                    
                    if (loginEmail == currentClient.email && loginPwd == currentClient.pwd)
                    {
                        Console.Clear();
                        Console.WriteLine($"Welcome back {currentClient.name}");
                        Console.WriteLine($"{currentClient.name}: {index}"); // debugging purposes

                        currentClient.loggedIn = true;
                        
                        loginAttempt = false;
                    }
                    else
                    {
                        Console.Write(PWD_ERR);
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Write(EMAIL_ERR);
                }
            }
        }

    } 
}