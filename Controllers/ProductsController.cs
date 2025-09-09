using PhilStoreApi.Data;
using PhilStoreApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhilStoreApi.Controllers
{
    public class ProductsController : ApiController
    {
        // GET api/<controller> -- GetAllProducts as list
        public IEnumerable<Products> Get()
        {          
            //Declare objects
            ProductData objProductData;
            DataSet dsSpProductGetWholeList;

            //Instantiate objects
            objProductData = new ProductData();
            dsSpProductGetWholeList = new DataSet();
            var objProductList = new List<Products>();

            //Get product list data
            dsSpProductGetWholeList = objProductData.SQL_spProductGetWholeList();

            for (int i = 0; i < dsSpProductGetWholeList.Tables[0].Rows.Count; i++)
            {
                objProductList.Add(new Products
                {
                    ID = (Int32)dsSpProductGetWholeList.Tables[0].Rows[i]["ID"],
                    Brand = (string)dsSpProductGetWholeList.Tables[0].Rows[i]["Brand"],
                    Name = (string)dsSpProductGetWholeList.Tables[0].Rows[i]["Name"],
                    Description = (string)dsSpProductGetWholeList.Tables[0].Rows[i]["Description"],
                    CategoryName = (string)dsSpProductGetWholeList.Tables[0].Rows[i]["CategoryName"],
                    IsActive = (Boolean)dsSpProductGetWholeList.Tables[0].Rows[i]["IsActive"],
                    RetailPrice = (decimal)dsSpProductGetWholeList.Tables[0].Rows[i]["RetailPrice"],
                    RegularPrice = (decimal)dsSpProductGetWholeList.Tables[0].Rows[i]["RegularPrice"],
                    SalePrice = (decimal)dsSpProductGetWholeList.Tables[0].Rows[i]["SalePrice"],
                    DateCreated = (DateTime)dsSpProductGetWholeList.Tables[0].Rows[i]["DateCreated"],
                    DateModified = (DateTime)dsSpProductGetWholeList.Tables[0].Rows[i]["DateModified"]
                });
            }

            return objProductList;
            //return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5 -- GetProductById
        public Products Get(int id)
        {
            //SQL_spProductGetByID
            //Declare objects
            ProductData objProductData;
            DataSet dsSQL_spProductGetByID;

            //Instantiate objects
            objProductData = new ProductData();
            dsSQL_spProductGetByID = new DataSet();
            var objProduct = new Products();

            //Get product list data
            dsSQL_spProductGetByID = objProductData.SQL_spProductGetByID(id);

            objProduct.ID = (Int32)dsSQL_spProductGetByID.Tables[0].Rows[0]["ID"];
            objProduct.Brand = (string)dsSQL_spProductGetByID.Tables[0].Rows[0]["Brand"];
            objProduct.Name = (string)dsSQL_spProductGetByID.Tables[0].Rows[0]["Name"];
            objProduct.Description = (string)dsSQL_spProductGetByID.Tables[0].Rows[0]["Description"];
            objProduct.CategoryName = (string)dsSQL_spProductGetByID.Tables[0].Rows[0]["CategoryName"];
            objProduct.IsActive = (Boolean)dsSQL_spProductGetByID.Tables[0].Rows[0]["IsActive"];
            objProduct.RetailPrice = (decimal)dsSQL_spProductGetByID.Tables[0].Rows[0]["RetailPrice"];
            objProduct.RegularPrice = (decimal)dsSQL_spProductGetByID.Tables[0].Rows[0]["RegularPrice"];
            objProduct.SalePrice = (decimal)dsSQL_spProductGetByID.Tables[0].Rows[0]["SalePrice"];
            objProduct.DateCreated = (DateTime)dsSQL_spProductGetByID.Tables[0].Rows[0]["DateCreated"];
            objProduct.DateModified = (DateTime)dsSQL_spProductGetByID.Tables[0].Rows[0]["DateModified"];          

            return objProduct;
        }

        // POST api/<controller>
        public void Post([FromBody] Product objProduct)
        {
            //Declare objects
            ProductData objProductData;

            //Instantiate objects
            objProductData = new ProductData();

            //Insert product
            objProductData.InsertProduct(objProduct);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] Product objProduct)
        {
            //Declare objects
            ProductData objProductData;

            //Instantiate objects
            objProductData = new ProductData();

            //Update product
            objProductData.UpdateProduct(objProduct, id);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            //Declare objects
            ProductData objProductData;

            //Instantiate objects
            objProductData = new ProductData();

            //Delete product by ID
            objProductData.DeleteProduct(id);
        }

        /*Employee[] employees = new Employee[]{
         new Employee { ID = 1, Name = "Mark", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 30 },
         new Employee { ID = 2, Name = "Allan", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 35 },
         new Employee { ID = 3, Name = "Johny", JoiningDate =
            DateTime.Parse(DateTime.Today.ToString()), Age = 21 }
      };

        public IEnumerable<Employee> GetAllEmployees()
        {
            return employees;
        }

        public IHttpActionResult GetEmployee(int id)
        {
            var employee = employees.FirstOrDefault((p) => p.ID == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }*/
    }
}