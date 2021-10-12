using System;
using System.Collections.Generic;
using InitialiseApp;
using ProductInterface;
using Products;
using UI;

namespace Bids
{
    public class BidMaker : IProduct
    {
        List<Product> tempProdList = new List<Product>();

        Product bidProduct;
        string userInputType;
        int inputBidAmt;
        int inputDeliveryOption;
        bool delivery;

        public void GetProducts()
        {
            Console.Clear();
            string PROMPT = "\nProduct type: ";

            Console.Write(PROMPT);
            userInputType = Console.ReadLine();

            foreach (var product in Session.productList)
            {
                if (product.type == userInputType)
                {
                    tempProdList.Add(product);
                }
            }
        }

        public void DisplayProducts()
        {
            string SEARCH_FAIL = $"No products of type '{userInputType}' found";

            if (tempProdList.Count == 0)
            {
                Console.WriteLine(SEARCH_FAIL);
            }

            Console.WriteLine($"Please select one of the following '{userInputType}' products:\n");
            
            for (int i = 0; i < tempProdList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tempProdList[i].type} '{tempProdList[i].name}'");
            }
        }

        public void GetBidInput()
        {
            string BID_PROMPT = "\nEnter bid ($)";
            string DELIVERY = "(1) Home delivery or (2) Click & Collect";

            string BID_TOO_LOW = "Bid amount must be greater than the starting cost";

            int userSelection = UserInterface.GetInt("\nSelection");
            int selectionIndex = userSelection - 1;

            bidProduct = tempProdList[selectionIndex];

            while (true)
            {
                inputBidAmt = UserInterface.GetInt(BID_PROMPT);
                if (inputBidAmt <= bidProduct.initialCost)
                {
                    Console.WriteLine(BID_TOO_LOW);
                    continue;
                }
                else
                {
                    break;
                }
            }

            inputDeliveryOption = UserInterface.GetInt(DELIVERY);

            if (inputDeliveryOption == 1)
            {
                delivery = true;
            }
            else
            {
                delivery = false;
            }
        }

        public void AddBid()
        {
            Bid newBid = new Bid(inputBidAmt, delivery);
            bidProduct.productBids.Add(newBid);

            Console.Clear();
            Console.Write($"Bid of ${newBid.amount} made by {newBid.bidder.name} ({newBid.bidder.email})\n");
            
            tempProdList.Clear();
        }
    }
}