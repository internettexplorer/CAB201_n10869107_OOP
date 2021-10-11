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

    public class ProductManager
    {
        public void Advertise()
        {
            Console.Write("\nProduct type: ");
            string inputProdType = Console.ReadLine();

            Console.Write("Name: ");
            string inputProdName = Console.ReadLine();

            Console.Write("Starting cost: $");
            string inputCostStr = Console.ReadLine();

            try
            {
                int inputCost = Int32.Parse(inputCostStr);
                
                Product newProduct = new Product(inputProdName, inputProdType, inputCost);

                Session.productList.Add(newProduct);

                Console.WriteLine($"\nSuccessfully added {newProduct.type} '{newProduct.name}' starting at ${newProduct.initialCost}");
            }
            catch (FormatException)
            {
                Console.Write("Please enter a valid integer");
            }
        }


    }
}