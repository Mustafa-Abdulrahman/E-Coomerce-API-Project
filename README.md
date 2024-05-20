# E-Coomerce-API-Project
Features
Authorization Endpoints:

Secure the API endpoints using JWT tokens.
Product Retrieval:

Retrieve products with optional filtering by category and name.
Endpoint: /product
Parameters:
category (optional)
name (optional)
Product Details:

Retrieve details of a specific product by its ID.
Endpoint: /product/getById/{id}
Parameter:
id (mandatory)
Add Procut From Form Query.
Endpoint: /product/addProduct
Parameter:
id (mandatory

Update product by id and send data in form query.
Endpoint: /product/updateProduct/{id}
Parameter:
id (mandatory

Cart Management:
Add a product to the cart.
Endpoint: /cart/addItem/ {quantity}
Parameters:
quantity (mandatory)
Take User id from token


Remove All Items
Endpoint: /cart/deleteAllCart
Parameter:
Take User id from token

Remove an item from the cart.
Endpoint: /cart/ deleteCartById/{id}
Parameter:
productId (mandatory)
Take User id from token

Edit the quantity of an item in the cart.
Endpoint: /cart/updateCartItem/{id}/{quantity}
Parameters:
Take all product from body
quantity (mandatory)
id (mandatory)	

Order Management:
Place an order with a list of products and their quantities.
Endpoint: /orders/place
Request Body Example:
json
Copy code
[
  { "productId": 1, "quantity": 5 },
  { "productId": 2, "quantity": 10 },
  { "productId": 7, "quantity": 1 }
]
View order history.
Endpoint: /orders/history
Response:
json
Copy code
[
  {
    "id": 1,
    "creationDateTime": "2023-01-01T12:00:00",
    "totalPrice": 100.00
  },
  ...
]
Product CRUD Operations (Bonus):

Create, read, update, and delete products with image functionality.
Requirements
Authorization: User ID should be obtained from JWT claims.
Architecture: Use N-Tier architecture.
CORS: Allow Cross-Origin Resource Sharing.
Delivery: Deliver the project through GitHub.
Testing: Record a video while testing all endpoints with Postman and add the video URL to the README file.
Notes
This is a backend-only project, no UI is required.
Make sure all source code is uploaded to the GitHub repository.
How to Run
Clone the Repository:

sh
Copy code
git clone https://github.com/yourusername/repo-name.git
cd repo-name
Setup Environment:

Configure your database connection in appsettings.json.
Ensure you have the necessary environment variables set for JWT and other configurations.
Run the Application:

sh
Copy code
dotnet run
Test the Endpoints:

Use Postman to test the endpoints as shown in the recorded video.
Video Demonstration
Link to Video Demonstration

Contact
For any questions or issues, please contact Your Name.
