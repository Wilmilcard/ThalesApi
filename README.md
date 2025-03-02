<p align="center">
    <h3 align="center">Juan David Leon Barrera</h3>
	<p align="center">
		<img src="https://img.shields.io/badge/.NET-5C2D91?logo=.net&logoColor=white" alt="template repository">
		<img src="https://img.shields.io/static/v1?label=proyect type&message=Api Rest&color=white" alt="v1.0.0">
		<img src="https://img.shields.io/static/v1?label=version&message=1.0.1&color=red" alt="v1.2">
		<img src="https://img.shields.io/static/v1?label=licence&message=No apply&color=green" alt="no tiene">
	</p>
    <p align="center">
        <a href="https://nevergate.com.co/"><img src="https://nevergate.com.co/otros/portafolio/images/logo.png" width="200"></a>
    </p>
</p>


# 🚩 Objective

Develop a Rest Api solution that meets the assumptions:

Create a Data Access Layer: 
- Implement a Data Access Layer to consume the following REST APIs: 
  - List of products: 
    https://api.escuelajs.co/api/v1/products   
  - Product data by ID: 
    https://api.escuelajs.co/api/v1/products/3 
    
These APIs return a list of products and specific product data based on the provided ID.  

Create a Business Logic Layer: 
- Implement a Business Logic Layer to compute the following value: 
  - Tax calculation: tax = price * 19% 
The tax calculation should be applied to each product 

Create a WebAPI Controller: 
- Implement a WebAPI controller with methods to: 
  - Return the list of products. 
  - Return product details by ID.

Unit Testing Requirements: 
- The application must include unit tests for at least one of the methods in the Business Logic Layer. 

# 📄 Project Description
This project has been developed in Visual Studio 2022 and .Net 8

It has 3 layers:

**1. ThalesApi layer** 🍂 
Where are

- the controllers
	- There are 3 controllers:
		- **AuthController**: which is responsible for verifying the authentication of users to consume the API
		- **LocalController**: Consumes the local database, it is optional and is not vital for its operation
		- **OnlineController**: The controller that resolves the test request 
- the business logic
- the http request for post requests
- the http response to map the responses of the external service
- interfaces
- services
- utils folder where a global class is stored
- Authentication services
- and dependency injection

The api implements the authentication mode, but it has the open methods with the `[AllowAnonymous]` tag that already comes by default. If you want to test the functionality, you should put the `[Authorize]` tag in the controllers that are required.

> [!NOTE]
> A Startup.cs class is created to facilitate the organization when subscribing to services, it is loaded from Program.cs

**2. ThalesApi.Domain** 🥐

A class library project, where everything related to the database is found:
- Models
- DataContext
- Migrations
- Seeders
- Repository
  
> [!NOTE]
> It is not requested in the test but an option of code first connected to SQL Server was created in case of internet or local tests

**3. ThalesApi.Test** ✔
It is the unit testing project that tests the method that calculates the taxes

# 🔥 Project execution

Para que el proyecto funcione correctamente se debe de tener instalado:

- IDE (Visual Studio 2022)
- Sql Server (optional)
- Postman (optional)

Once you have the tools installed:

1. Clone the repository
2. Then run the project with **IIS Express**.
3. The application will now be running from the swagger endpoint in the standard route https://localhost:44336/swagger/index.html

## Optional 💡
If you want, you can run the application locally by creating a database and running the seeders.
1. Create a database called "thales_api" in Sql Server in the connection chain.
2. Open the "Package Manager" console and in the project where the console will be executed put it in **ThalesApi.Domain**. Run the command `update-database`; this will create the tables and fill them with the *sedder*
3. Then run the project with **IIS Express**.
4. The application will now be running from the swagger endpoint in the standard route https://localhost:44336/swagger/index.html

> [!WARNING]
> If you want to change the name, it is as easy as going to the ApiNet6 project and in the `appsetting.json` change the property **database = Database_Name** 

# 🧪 Endpoints API

- It is possible to consume the API through GET. I will leave the list of urls where you can bring information
    - Online Controller
        - Bring all products: **[https://localhost:44336/api/Online/GetProductsFromDB](https://localhost:44336/api/Online/GetProductsFromApi)**
        - Find by Id product: **[https://localhost:44336/api/Online/GetProductsFromDB/55](https://localhost:44336/api/Online/GetProductByIdFromApi/4)**
    - Local Controller
        - Bring all products: **[https://localhost:44336/api/Local/GetProductsFromDB](https://localhost:44336/api/Local/GetProductsFromDB)**
        - Find by Id product: **[https://localhost:44336/api/Local/GetProductsFromDB/55](https://localhost:44336/api/Local/GetProductsFromDB/55)**

🛴
