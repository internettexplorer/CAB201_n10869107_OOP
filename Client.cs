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
            // Prompts user for email and pwd, with validation at each step
            string EMAIL_ERR = "Email not registered, please try again";
            string PWD_ERR = "Wrong password, please try again";

            bool loginAttempt = true;

            while (loginAttempt)
            {
                Console.Write("\nEmail: ");
                string loginEmail = Console.ReadLine();

                string loginPwd = UserInterface.GetPassword("Password");

                foreach (var client in clientData)
                {
                    if (loginEmail == client.email && loginPwd == client.pwd)
                    {
                        Console.Clear();
                        Console.WriteLine($"Welcome back, {client.name}");

                        int index = clientData.FindIndex(c => c.email.Equals(loginEmail, StringComparison.Ordinal));

                        currentClient = clientData[index];
                        Console.WriteLine($"{currentClient}");

                        currentClient.loggedIn = true;
                        loginAttempt = false;
                    }
                    else if (loginEmail != client.email)
                    {
                        Console.WriteLine(EMAIL_ERR);
                        continue;
                    }
                    else
                    {
                        Console.WriteLine(PWD_ERR);
                        continue;
                    }
                }
            }
        }

    } 
}