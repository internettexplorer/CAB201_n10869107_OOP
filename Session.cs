using System.Collections.Generic;
using Clients;
using Products;

namespace InitialiseApp
{
    public struct Session
    {
        public static List<Client> clientData = new List<Client>();
        public static List<Product> productList = new List<Product>();
        public static Client currentClient;
        public static int index;
    }
}