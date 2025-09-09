# Phil REST API Examples
Welcome! This is some example code I put together that creates several REST APIs which serve as the microservices layer for my SQL database (other repo).  The end goal was to provide a complete demo from database to API to Postman collection and tests.

Setup Instructions:
1. Clone the PhilStoreAPI repository to your local and build the project.
2. Download from this repo's attached files "dbPhilStore_2025.07.27c.bak" and restore the full backup to your local SQL Server Management Studio.
3. Download from this repo's attached files "PhilStoreAPIs_2025.8.25b.postman_collection" and import this collection to Postman.
4. Download from this repo's attached filed "Development.postman_environment.json" and import this environment to Postmand.
5. Set the environment = Development
6. Build and run the PhilStoreAPI project, leave it running.
7. Open Postman and you'll see the API REST requests.
8. Run the APIs as desired.  Mission success!

The REST APIs are functionally as follows, please refer to the Postman collection for details:
1. GET GetAllProducts
2. GET ProductById
3. POST InsertProduct
4. PUT UpdateProduct
5. DELETE DeleteProduct
