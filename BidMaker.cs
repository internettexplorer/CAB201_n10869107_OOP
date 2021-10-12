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
        string userInputType;

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

            Console.WriteLine($"Please select one of the following '{userInputType}' items:\n");
            
            for (int i = 0; i < tempProdList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {tempProdList[i].type} '{tempProdList[i].name}'");
            }
        }

        public void GetBid()
        {
            string BID_TOO_LOW = "Bid amount must be greater than the starting cost";
            string BID_PROMPT = "\nEnter bid ($)";
            string DELIVERY = "(1) Home delivery or (2) Click & Collect";
            int userSelection = UserInterface.GetInt($"\nEnter a number between 1 and {tempProdList.Count}");
            int selectionIndex = userSelection - 1;

            Product bidProduct = tempProdList[selectionIndex];

            int inputBidAmt;

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

            bool delivery;
            int inputDeliveryOption = UserInterface.GetInt(DELIVERY);

            if (inputDeliveryOption == 1)
            {
                delivery = true;
            }
            else
            {
                delivery = false;
            }

            Bid newBid = new Bid(inputBidAmt, delivery);
            bidProduct.productBids.Add(newBid);

            Console.Write($"Bid of ${newBid.amount} made by {newBid.bidder.name} ({newBid.bidder.email})");
            
        }

    }
}