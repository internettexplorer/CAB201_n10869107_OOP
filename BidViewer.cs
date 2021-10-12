using System.Collections.Generic;
using System;
using ProductInterface;
using UI;
using Products;
using InitialiseApp;

namespace Bids
{
    public class BidViewer : ProductViewer
    {
        protected internal override void DisplayProducts()
        {

            string NO_PRODUCTS = "You have no products for sale";

            if (Session.userProducts.Count == 0)
            {
                Console.Clear();
                Console.WriteLine(NO_PRODUCTS);
                return;
            }
        
            Console.Clear();
            Console.WriteLine("Please select a product:\n");
            
            for (int i = 0; i < Session.userProducts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Session.userProducts[i].type} '{Session.userProducts[i].name}'");
            }

            GetBidView();
        }

        public void GetBidView()
        {
            string NO_BIDS = "There are no bids on this product currently";
            
            int viewSelection = UserInterface.GetInt("\nSelection");
            int selectionIndex = viewSelection - 1;

            Product viewProduct = Session.userProducts[selectionIndex];

            if (viewProduct.productBids.Count == 0)
            {
                Console.Clear();
                Console.WriteLine(NO_BIDS);
                return;
            }

            Console.WriteLine("Bids received:\n");

            for (int i = 0; i < viewProduct.productBids.Count; i++)
            {
                Console.WriteLine($"{i + 1}. ${viewProduct.productBids[i].amount} from {viewProduct.productBids[i].bidder.name} ({viewProduct.productBids[i].bidder.email})");
            }
        }
    }
}