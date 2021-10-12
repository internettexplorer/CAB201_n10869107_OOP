using InitialiseApp;
using Clients;

namespace Bids
{
    public class Bid
    {
        public int amount;
        public bool delivery;
        public Client bidder;

        public Bid(int amount, bool delivery)
        {
            this.amount = amount;
            this.delivery = delivery;
            this.bidder = Session.currentClient;
        }
    }
}