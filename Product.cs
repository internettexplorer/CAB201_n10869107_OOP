using System;
using System.Collections.Generic;

namespace Products
{
    public class Product
    {
        public string name {get; set;}
        public string type {get; set;}
        public int initialCost {get; set;}

        // public int id ??

        public Product(string name, string type, int initialCost)
        {
            this.name = name;
            this.type = type;
            this.initialCost = initialCost;
        }
    }

    public class ProductManager
    {
        List<Product> productList = new List<Product>();

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

                productList.Add(newProduct);

                Console.WriteLine($"\nSuccessfully added {newProduct.type} '{newProduct.name}' starting at ${newProduct.initialCost}");
            }
            catch (FormatException)
            {
                Console.Write("Please enter a valid integer");
            }
        }


    }
}