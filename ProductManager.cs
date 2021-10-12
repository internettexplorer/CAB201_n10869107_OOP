using System;
using System.Collections.Generic;

using InitialiseApp;
using ProductInterface;

namespace Products
{
    public class ProductManager
    {
        protected internal List<Product> userProducts = new List<Product>();
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
                Console.Write("Please enter a valid integer\n");
            }
        }

        // public void GetProducts()
        // {
        //     foreach (var product in Session.productList)
        //     {
        //         if (product.prodCreatorID == Session.currentClient.clientID)
        //         {
        //             userProducts.Add(product);
        //         }
        //     }
        // }
        // public void ListProducts()
        // {
        //     string NO_PRODUCTS = "You have no products available for sale right now.";;

        //     if (userProducts.Count == 0)
        //     {
        //         Console.WriteLine(NO_PRODUCTS);
        //         return;
        //     }

        //     Console.WriteLine("Products for sale:\n");

        //     for (int i = 0; i < userProducts.Count; i++)
        //     {
        //         Console.WriteLine($"{i + 1}. {userProducts[i].type} '{userProducts[i].name}'");
        //     }
        // }

        // public void Search()
        // {
        //     Console.Write("Product type: ");
        //     string inputSearchType = Console.ReadLine();         
        // }


    }
}