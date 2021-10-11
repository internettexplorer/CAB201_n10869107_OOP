CAB201_n10869107_OOP

todo list / journal

* creating a separate class for Client list and Product list, and then two more classes Client_Manager and Product_Manager with the relevant methods for those classes? How will this look on the class diagram? 

* use IndexOf to get current logged in user and their details
-- using streams to override ToString method? 
I'm getting an error where IndexOf can't access the requested string (client.email) because the type is Clients.Client. How to convert from obj to string? Or is that the answer? Who knows? 

* set up Product and Bid classes - identify requirements
* rename Database with Client functionality to something more meaningful
* comment out the code a bit 

Questions for Monday
-- Find out whether any support sessions are being run this week. I need it..

1. Do we have to represent every class in our code in the class diagram? 
2. Is my code structure in alignment with OOP design? Specifically -- use of static Session class to store data
3. Where to use virtual methods? Where is extension possible? 

-------

Product objects needs to be accessed by: 
Client - to list their currently posted products
Client - to search for products by type

Product HAS-A Bid
Product IS-A ...?
Client IS-A ...? 

-> Maybe it's a nested structure, from top to bottom like: 
Client (list of Clients) 
has
Product/s (list of Products)
has
Bid/s (list of Bids)
