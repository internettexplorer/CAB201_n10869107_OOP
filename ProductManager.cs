using System;
using System.Collections.Generic;

using InitialiseApp;
using ProductInterface;

namespace Products
{
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
                Console.Write("Please enter a valid integer\n");
            }
        }

        public void DisplayUserProducts()
        {
            ProductViewer Viewer = new ProductViewer();

            Viewer.GetProducts();
            Viewer.DisplayProducts();
        }

        public virtual void Search()
        {
            ProductSearcher Searcher = new ProductSearcher();
            
            Searcher.GetProducts();
            Searcher.DisplayProducts();
        }
    }
}