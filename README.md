# Product-Store-Client-Side- ASP.NET Core MVC
This project is an ASP.NET Core MVC web application for a store. The application persists two models: Customer and Product. It includes session management and authentication features such as login, logout, and profile management.

#Features 
Customer Management: Customers can create an account, login, view, and edit their profile.
Product Management: List, view, and manage products in the store.
Session Management: Shopping cart and user-related data are persisted in session.
Authentication: The application supports login and logout functionality.
Profile Management: Customers can view and update their personal details.
Technologies Used
ASP.NET Core MVC
Entity Framework Core (for database interactions)
SQL Server (or any other supported database)
Session State (for session management)
Authentication Middleware (for login/logout)
Getting Started
Prerequisites
Ensure you have the following installed:

.NET 7 SDK
SQL Server or any compatible database
Visual Studio or any IDE that supports .NET Core development
Installation
Clone the repository:

bash
Copy code
git clone https://github.com/itslezley/Product-Store-Client-Side.git
cd Product-Store-Client-Side
Restore the dependencies:

bash
Copy code
dotnet restore
Set up the database:

Open the appsettings.json file and update the connection string for your database:

json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=StoreDB;Trusted_Connection=True;MultipleActiveResultSets=true"
}
Run the migrations to create the necessary tables:

bash
Copy code
dotnet ef database update
Run the application:

bash
Copy code
dotnet run
Access the app: Open your browser and go to https://localhost:5001/ to see the app in action.

Models
Customer
The Customer model stores user information such as:

Id (Primary Key)
FirstName
LastName
Email
Password (hashed)
Profile Details (such as address, phone, etc.)
Product
The Product model stores details about the store's products:

Id (Primary Key)
Name
Description
Price
Quantity in Stock
Authentication
Login: Users can log in using their registered email and password.
Logout: Users can log out, which clears their session.
Profile Management: Users can view and update their profile information once logged in.
Session Management
Shopping Cart: Products added to the cart are stored in session, ensuring they persist across different requests during the user session.
Session Data: The user's login status and any cart data are stored in session for easy retrieval.
Entity Framework Core (EF Core)
EF Core is used for data persistence. It maps the Customer and Product models to database tables and handles CRUD operations.

To modify or add database tables, you can create a new migration:

bash
Copy code
dotnet ef migrations add <MigrationName>
dotnet ef database update
Authentication and Authorization
The app uses ASP.NET Core Identity for managing authentication. A simple login/logout flow is implemented, with session management keeping track of the logged-in user.

Login: /Account/Login
Logout: /Account/Logout
Profile: /Account/Profile
You can modify the AccountController to add more features or customizations to authentication as needed.

Folder Structure
Controllers: Manages HTTP requests and interacts with the models.
Models: Defines the Customer and Product entities.
Views: Razor views for presenting data to the user.
Migrations: Contains EF Core migrations for database schema changes.
Future Enhancements
Implement shopping cart checkout functionality.
Add product categories.
Include search and filter capabilities for products.
Improve the user profile to include more detailed information.
License
This project is licensed under the MIT License. See the LICENSE file for details.
