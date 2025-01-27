# PhotoSi.ItTest.MarketPlace

## Summary

This project implement a Mock microservices architecture, for the management of order.
It has one Gateway service for the aggregation of the apis and 3 microservices for the management of a specific domain.

The current solution is prepared to run locally on docker and it is already configure to deploy the database (on a local container) using Migrations.

## Prerequisites
Before testing the project, ensure you have the following installed:
1. **.NET SDK** (Version 8.0)
2. **Docker** (For containerized microservices)
3. **Docker Compose** (For managing multi-container services)
3. **Postman** or **cURL** (For testing the APIs)

---

## Startup Instructions

### 1. Clone the Repository
Clone the project from the repository and navigate to its root folder:
```bash
git clone https://github.com/GiorgioRaimondi1993/PhotoSi.ItTest.git
cd PhotoSi.ItTest.MarketPlace
```

### 2. Configure Environment Variables
This project is already configured to use a sql server database deployed locally (see following steps).
If you want to use a custom Sql Server DB, update the connectionString value under **ConnectionStrings:SqlServer** configuration for all:
 - _.\src\PhotoSi.Orders.API\appsetting.json_
 - _.\src\PhotoSi.Users.API\appsetting.json_
 - _.\src\PhotoSi.Products.API\appsetting.json_
 
### 3. Build and Run the Application
**Using Docker Compose:**
Run all microservices and supporting infrastructure with Docker Compose:
```bash
docker-compose up --build
```

This command will:

 - Build the Docker images for all microservices.
 - Spin up containers for the microservices and dependencies (e.g., databases, message brokers).
 
Wait for all services to start. Logs will display as the services come online.

To stop the container, run:
```bash
docker-compose down
```

### 4. Testing the APIs
The running services will expose the apis at following urls:
 - Gateway : http://localhost:8000
 - Users : http://localhost:7006/user and http://localhost:7006/locations
 - Products : http://localhost:7016/products
 - Orders : http://localhost:7026/orders

**Using Postman:**
1. Import the Postman collection provided in the repository (postman_collection.json).
2. Execute the predefined API requests to verify functionality.
3. Test typical operations such as:
	- GET to retrieve data.
	- POST to create new entries.
	- PUT to update data.
	- DELETE to remove resources.

### 4. Check Unit Test
If you want to run Unit Test :
```bash
run-unittest.bat
```

or double click the file _run-unittest.bat_
