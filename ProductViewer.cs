using System;
using InitialiseApp;
using ProductInterface;

namespace Products
{
    public class ProductViewer : IProduct
    {
        void IProduct.DisplayProducts()
        {
            this.DisplayProducts();
        }
        public void GetProducts()
        {
            foreach (var product in Session.productList)
            {
                if (product.prodCreatorID == Session.currentClient.clientID)
                {
                    Session.userProducts.Add(product);
                }
            }
        }

        protected internal virtual void DisplayProducts()
        {
            string NO_PRODUCTS = "You have no products available for sale right now.\n";;

            if (Session.userProducts.Count == 0)
            {
                Console.Clear();
                Console.WriteLine(NO_PRODUCTS);
                return;
            }

            Console.Clear();
            Console.WriteLine("Products for sale:\n");

            for (int i = 0; i < Session.userProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Session.userProducts[i].type} '{Session.userProducts[i].name}'");
            }
        }
    }
}