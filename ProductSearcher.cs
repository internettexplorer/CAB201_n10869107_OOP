using System;
using System.Collections.Generic;
using InitialiseApp;
using ProductInterface;

namespace Products
{
    public class ProductSearcher : IProduct
    {
        List<Product> tempSearchList = new List<Product>();
        string inputSearchType;
        public void GetProducts()
        {
            tempSearchList.Clear();

            string PROMPT = "\nProduct type: ";

            Console.Write(PROMPT);
            inputSearchType = Console.ReadLine();

            foreach (var product in Session.productList)
            {
                if (product.type == inputSearchType)
                {
                    tempSearchList.Add(product);
                }
            }
        }
        
        public void DisplayProducts()
        {
            string SEARCH_FAIL = $"No products of type '{inputSearchType}' found";

            if (tempSearchList.Count == 0)
            {
                Console.WriteLine(SEARCH_FAIL);
            }

            Console.WriteLine($"Products of type '{inputSearchType}' available for sale:\n");
            
            for (int i = 0; i < tempSearchList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tempSearchList[i].type} '{tempSearchList[i].name}'");
            }
        }
    }
}