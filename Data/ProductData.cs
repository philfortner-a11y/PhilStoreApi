using PhilStoreApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace PhilStoreApi.Data
{
    public class ProductData
    {
        //Class declarations
        SqlTools mySqlTools;


        //Setup constructor
        public ProductData()
        {
            mySqlTools = new SqlTools();

        }

        public DataSet SQL_spProductGetByID(Int32 ProductID)
        {
            //Local declarations
            DataSet dstProductList;
            SqlConnection conSqlServer;
            SqlCommand cmdSpProductGetByID;
            SqlDataAdapter daSpProductGetByID;

            //Instantiate objects
            dstProductList = new DataSet();
            conSqlServer = new SqlConnection();
            conSqlServer = mySqlTools.OpenSQLConnection();
            cmdSpProductGetByID = new SqlCommand("spProductGetByID", conSqlServer);
            daSpProductGetByID = new SqlDataAdapter();

            //Add parameter
            cmdSpProductGetByID.Parameters.Add("ID", SqlDbType.Int).Value = ProductID;
            cmdSpProductGetByID.CommandType = CommandType.StoredProcedure;

            try
            {
                //Set data adapter
                daSpProductGetByID.SelectCommand = cmdSpProductGetByID;

                //Execute stored procedure and load dataset
                daSpProductGetByID.Fill(dstProductList);
            }
            catch (SqlException sqlEx)
            {
                Console.Write("There was a SQL problem: " + sqlEx.Message);
                Console.Write("Stack trace: " + sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                Console.Write("There was a general problem: " + ex.Message);
                Console.Write("Stack trace: " + ex.StackTrace);
            }
            finally
            {
                conSqlServer.Close();
            }

            //Return dataset to caller
            return dstProductList;
        }


        public DataSet SQL_spProductGetWholeList()
        {
            //Local declarations
            DataSet dstProductList;
            SqlConnection conSqlServer;
            SqlCommand cmdSpProductGetByID;
            SqlDataAdapter daSpProductGetWholeList;

            //Instantiate objects
            dstProductList = new DataSet();
            conSqlServer = new SqlConnection();
            conSqlServer = mySqlTools.OpenSQLConnection();
            cmdSpProductGetByID = new SqlCommand("spProductGetWholeList", conSqlServer);
            daSpProductGetWholeList = new SqlDataAdapter();

            //Set command            
            cmdSpProductGetByID.CommandType = CommandType.StoredProcedure;

            //Set data adapter
            try
            {
                daSpProductGetWholeList.SelectCommand = cmdSpProductGetByID;

                //Execute stored procedure and load dataset
                daSpProductGetWholeList.Fill(dstProductList);
            }
            catch (SqlException sqlEx)
            {
                Console.Write("There was a SQL problem: " + sqlEx.Message);
                Console.Write("Stack trace: " + sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                Console.Write("There was a general problem: " + ex.Message);
                Console.Write("Stack trace: " + ex.StackTrace);
            }
            finally
            {
                conSqlServer.Close();
            }

            //Return dataset to caller
            return dstProductList;
        }


        public Int32 InsertProduct(Product objProduct)
        {
            //Local declarations
            SqlConnection conSqlServer;
            SqlCommand cmdSpProductInsert;
            Int32 intLatestID;
            
            //Instantiate objects
            conSqlServer = new SqlConnection();
            conSqlServer = mySqlTools.OpenSQLConnection();
            cmdSpProductInsert = new SqlCommand("spProductInsert", conSqlServer);
            intLatestID = 0;

            //Insert new product
            try
            {                
                cmdSpProductInsert.CommandType = CommandType.StoredProcedure;
                cmdSpProductInsert.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = objProduct.Brand;
                cmdSpProductInsert.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = objProduct.Name;
                cmdSpProductInsert.Parameters.Add("@Description", SqlDbType.NVarChar, 1000).Value = objProduct.Description;
                cmdSpProductInsert.Parameters.Add("@CategoryID", SqlDbType.Int).Value = objProduct.CategoryID;
                cmdSpProductInsert.Parameters.Add("@IsActive", SqlDbType.Bit).Value = objProduct.IsActive;
                cmdSpProductInsert.Parameters.Add("@RetailPrice", SqlDbType.Decimal).Value = objProduct.RetailPrice;
                cmdSpProductInsert.Parameters.Add("@RegularPrice", SqlDbType.Decimal).Value = objProduct.RegularPrice;
                cmdSpProductInsert.Parameters.Add("@SalePrice", SqlDbType.Decimal).Value = objProduct.SalePrice;
                cmdSpProductInsert.Parameters.Add("@LatestID", SqlDbType.Int).Direction = ParameterDirection.Output;

                //Perform SQL insert
                cmdSpProductInsert.ExecuteNonQuery();
                
                //Get latest producID
                intLatestID = Convert.ToInt32(cmdSpProductInsert.Parameters["@LatestID"].Value);
            }
            catch (SqlException sqlEx)
            {
                Console.Write("There was a SQL problem: " + sqlEx.Message);
                Console.Write("Stack trace: " + sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                Console.Write("There was a general problem: " + ex.Message);
                Console.Write("Stack trace: " + ex.StackTrace);
            }
            finally
            {
                conSqlServer.Close();
            }

            //Return function success
            return intLatestID;
        }


        public Boolean UpdateProduct(Product objProduct, Int32 intProductID)
        {
            //Local declarations
            SqlConnection conSqlServer;
            SqlCommand cmdSpProductUpdate;
            Boolean boolInsertResult;

            //Instantiate objects
            conSqlServer = new SqlConnection();
            conSqlServer = mySqlTools.OpenSQLConnection();
            cmdSpProductUpdate = new SqlCommand("spProductUpdate", conSqlServer);
            boolInsertResult = false;

            //Insert new product
            try
            {
                cmdSpProductUpdate.CommandType = CommandType.StoredProcedure;
                cmdSpProductUpdate.Parameters.Add("@ID", SqlDbType.Int).Value = intProductID;
                cmdSpProductUpdate.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = objProduct.Brand;
                cmdSpProductUpdate.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = objProduct.Name;
                cmdSpProductUpdate.Parameters.Add("@Description", SqlDbType.NVarChar, 1000).Value = objProduct.Description;
                cmdSpProductUpdate.Parameters.Add("@CategoryID", SqlDbType.Int).Value = objProduct.CategoryID;
                cmdSpProductUpdate.Parameters.Add("@IsActive", SqlDbType.Bit).Value = objProduct.IsActive;
                cmdSpProductUpdate.Parameters.Add("@RetailPrice", SqlDbType.Decimal).Value = objProduct.RetailPrice;
                cmdSpProductUpdate.Parameters.Add("@RegularPrice", SqlDbType.Decimal).Value = objProduct.RegularPrice;
                cmdSpProductUpdate.Parameters.Add("@SalePrice", SqlDbType.Decimal).Value = objProduct.SalePrice;

                //Perform SQL insert
                cmdSpProductUpdate.ExecuteNonQuery();
                boolInsertResult = true;
            }
            catch (SqlException sqlEx)
            {
                Console.Write("There was a SQL problem: " + sqlEx.Message);
                Console.Write("Stack trace: " + sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                Console.Write("There was a general problem: " + ex.Message);
                Console.Write("Stack trace: " + ex.StackTrace);
            }
            finally
            {
                conSqlServer.Close();
            }

            //Return function success
            return boolInsertResult;
        }


        public Boolean DeleteProduct(Int32 intProductID)
        {
            //Local declarations
            SqlConnection conSqlServer;
            SqlCommand cmdSpProductUpdate;
            Boolean boolInsertResult;

            //Instantiate objects
            conSqlServer = new SqlConnection();
            conSqlServer = mySqlTools.OpenSQLConnection();
            cmdSpProductUpdate = new SqlCommand("spProductDelete", conSqlServer);
            boolInsertResult = false;

            //Insert new product
            try
            {
                cmdSpProductUpdate.CommandType = CommandType.StoredProcedure;
                cmdSpProductUpdate.Parameters.Add("@ID", SqlDbType.Int).Value = intProductID;

                //Perform SQL insert
                cmdSpProductUpdate.ExecuteNonQuery();
                boolInsertResult = true;
            }
            catch (SqlException sqlEx)
            {
                Console.Write("There was a SQL problem: " + sqlEx.Message);
                Console.Write("Stack trace: " + sqlEx.StackTrace);
            }
            catch (Exception ex)
            {
                Console.Write("There was a general problem: " + ex.Message);
                Console.Write("Stack trace: " + ex.StackTrace);
            }
            finally
            {
                conSqlServer.Close();
            }

            //Return function success
            return boolInsertResult;
        }
    }
}