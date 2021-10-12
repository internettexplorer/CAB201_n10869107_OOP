CAB201_n10869107_OOP

todo list / journal

* creating a separate class for Client list and Product list, and then two more classes Client_Manager and Product_Manager with the relevant methods for those classes? How will this look on the class diagram?  

* Bid class - inside Product class 
* comment out the code a bit 

* registration: checking if email already exists? 

* could my code be similar if i refer to the class instances directly rather than an ID system? 
-------

Questions for Monday
1. Do we have to represent every class in our code in the class diagram? 
2. Is my code structure in alignment with OOP design? Specifically -- use of static Session class to store data - static member in Program.cs rather than static class 
3. Where to use virtual methods? Where is extension possible? ToString, getX
4. Where to implement inheritance? #11 
5. One class per file? 

* breaking away from list-based implementation?
* using interfaces for the shared display/get functs for product and bid?

-------

Class relationships

Client HAS-A Product
Product HAS-A Bid

-------

Search: 
1. take user input of type
2. loop through Product list for that type
3. store matches inside a List<Product> list
4. loop through list to display each product of that type

Bid class:

Bid:
1. take user string input: type
2. display list of products of that type
3. take user int input: which item to bid for
4. user int input: bidding amount

View list of bids:
1. display list of user products
2. take user int input: which product?
3. display bid list (inside Product maybe) of current bids:
    attributes displayed: bidder name & email, amount


---
Products have: name, type, cost, userID 

Advertise() adds a product to the session-wide ProductList

Abstracted functions: IProduct() / virtual
GetProducts() : get and store in list
DisplayProducts() : show as formatted list


listing products for sale: ListProducts()
    ProductList: get products where currentClient.id = userID (equality check)
    Store products in temporary userProducts list (list.Add)
    Display user products by looping through list (for)

searching for products: Search()
    :: string inputProdType 
    Prompt user for product type to search for
    ProductList: get products where the inputProdType == product.type (foreach?)
    Store matching products in temporary returnProdSearch list (list.Add)
    Display product search results by looping through list (for)

bidding: -> is this where virtual methods can be used?? Bid()
    Bid :: bidAmount, bidderID || biddername, bidderemail? 

    Product HAS- bid, each Product instance contains a list of Bids.
    Expressed in the Product class as a list field. 

    Prompt user for product type
    Same as Search method: get products with matching types, store in temp list
    Display enumerated list of products
    Prompt user for integer selection (what product to bid for)
    Prompt user for bid amount
    Prompt user to y/n click & collect or home delivery

    Create Bid instance
    Instantiate Bid class with bid amount and bidder details from currently logged in user (currentClient).
    Add bid to List<Bid> of that Product

    maybe override 
selling: Sell()
    Transaction :: house charge, taxpayable





