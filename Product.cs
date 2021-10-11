using System;
using System.Collections.Generic;

using InitialiseApp;

namespace Products
{
    public class Product
    {
        public string name {get; set;}
        public string type {get; set;}
        public int initialCost {get; set;}

        public Guid prodCreatorID {get; private set;}

        public Product(string name, string type, int initialCost)
        {
            this.name = name;
            this.type = type;
            this.initialCost = initialCost;
            this.prodCreatorID = Session.currentClient.clientID; // could be problematic later on??
        }
    }
}