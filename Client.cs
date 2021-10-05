using System;
using System.Collections.Generic;

namespace Clients
{
    public class Client
    {
        public string name {get; set;}
        public string email {get; set;}
        public string pwd {get; set;}
        public string address {get; set;}
    
        // eventually want to have support for products and bid (classes?) in this class

        public Client(string name, string email, string pwd, string address) 
        {
            this.name = name;
            this.email = email;
            this.pwd = pwd;
            this.address = address;
        }  
    }
}