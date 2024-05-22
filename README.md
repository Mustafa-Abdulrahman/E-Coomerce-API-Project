# Store Ecommerce ASP.NET API Core Project

This project is a back-end for an e-commerce website, built using the ASP.NET Core API using N-tier Arcticture, which is based on 3 layers, which are the
**API**: which contains the End Point & Controller.
**Bussness Layer**: which contains the code required to obtain the final information
**Data Access Layer**: which deals with the database, and contains models and context

## Project features:
### Authorization
•	JWT Authentication: Secure authentication using JSON Web Tokens (JWT) to ensure only authorized users can access protected endpoints.
### Product Management
•	Retrieve Products: Fetch a list of products with optional filtering by category and name.
•	Product Details: Get detailed information about a specific product using its ID.
•	CRUD Operations: (Bonus) Create, read, update, and delete products, including image upload functionality.
### Cart Management
•	Add to Cart: Add products to the user's cart specifying the product ID and quantity.
•	Remove from Cart: Remove a specific product from the cart using its ID.
•	Edit Item Quantity: Update the quantity of a specific product in the cart.
### Order Processing
•	Place Order: Create a new order with a list of product IDs and their quantities.
•	View Orders History: Retrieve a list of past orders, including order ID, creation date, and total price.
###Architecture and Design
•	N-Tier Architecture: Clean separation of concerns with distinct layers for presentation, business logic, and data access.
•	DTOs: Use of Data Transfer Objects to streamline communication between layers and ensure data integrity.
•	CORS Support: Cross-Origin Resource Sharing enabled to allow requests from different origins.
### Additional Features
•	User Management: Obtain user details from JWT claims without explicitly passing user IDs in requests.

## Instructions for use Api’s:
-	Before Use Apis, You Must Install MSSQL Serve, Visual Studio
-	Using  update-database to Because It The DB Work As Code First.
**BaseUrl**= https://localhost:7205
### User End Point:
 ![image](https://github.com/Mustafa-Abdulrahman/E-Coomerce-API-Project/assets/100872559/b5c56837-2d51-4ead-a43f-5f506f610b0c)

### Product End Point:
 ![image](https://github.com/Mustafa-Abdulrahman/E-Coomerce-API-Project/assets/100872559/b1bb35b3-11e6-4ce3-a96d-832608b9b622)

### Order End Point:
 ![image](https://github.com/Mustafa-Abdulrahman/E-Coomerce-API-Project/assets/100872559/3ede18e1-93fc-4c63-8f3e-0f9675d956f6)

### FileImages End Point:
 ![image](https://github.com/Mustafa-Abdulrahman/E-Coomerce-API-Project/assets/100872559/76939f58-e73d-4d48-9d07-92728f7a7e80)

### Category End Point:
 
![image](https://github.com/Mustafa-Abdulrahman/E-Coomerce-API-Project/assets/100872559/2fbe1a68-0c64-4b44-91f3-29e019230139)

### Cart End Point:

 ![image](https://github.com/Mustafa-Abdulrahman/E-Coomerce-API-Project/assets/100872559/5dbb4225-1339-41e5-93c4-99f3f362482b)



