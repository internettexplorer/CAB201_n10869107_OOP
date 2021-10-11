using System;

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
}