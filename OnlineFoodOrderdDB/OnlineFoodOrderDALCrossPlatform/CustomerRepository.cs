using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderDALCrossPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineFoodOrderDALCrossPlatform
{
    public class CustomerRepository
    {
        OnlineFoodOrderDBBContext context;

        public CustomerRepository()
        {
            context = new OnlineFoodOrderDBBContext();
        }

        //1.Get food item details
        public List<Items> GetAllItems()
        {
            var itemslist = (from items in context.Items select items).ToList();
            return itemslist;
        }

        //2.Get items details with a specific category name
        public List<ItemDetails> GetAllItemDetails(string categoryName)
        {
            List<ItemDetails> list = null;
            try
            {
                SqlParameter prmCategoryName = new SqlParameter("@categoryName", categoryName);
                list = context.ItemDetails.FromSqlRaw
                    ("SELECT * FROM ufn_FetchItemDetails(@categoryName)", prmCategoryName).ToList();
            }
            catch (Exception ex)
            {
                list = null;
            }
            return list;
        }

        //3.Fetch the price of the item 
        public int GetItemPrice(string itemId)
        {
            int returnValue = -1;
            try
            {
                returnValue = (from p in context.Items select OnlineFoodOrderDBBContext.ufn_FetchItemPrice(itemId)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                returnValue = -99;
            }
            return returnValue;
        }

        //4. Add or placed order
        public int PlaceOrder(int customerId,string itemId,int quantity,string deliveryAddress, 
             DateTime orderDate, out int totalPrice, out int orderId)
        {
            totalPrice = 0;
            orderId = 0;
            int noOfRowsAffected = 0;
            int returnResult = 0;

            //for input parameters
            SqlParameter param_customerId = new SqlParameter("@CustomerId",customerId);
            SqlParameter param_itemId = new SqlParameter("@ItemId", itemId);
            SqlParameter param_quantity = new SqlParameter("@Quantity", quantity);
            SqlParameter param_deliveryAddress = new SqlParameter("@DeliveryAddres", deliveryAddress);
            SqlParameter param_orderDate = new SqlParameter("@OrderDate", orderDate);

            //for output parameter 1
            SqlParameter param_totalPrice = new SqlParameter("@TotalPrice", System.Data.SqlDbType.BigInt);
            param_totalPrice.Direction = System.Data.ParameterDirection.Output;

            //for output parameter 
            SqlParameter param_orderId = new SqlParameter("@OrderId", System.Data.SqlDbType.TinyInt);
            param_orderId.Direction = System.Data.ParameterDirection.Output;

            //for return value from storedprocedure
            SqlParameter param_returnResult = new SqlParameter("@ReturnResult", System.Data.SqlDbType.TinyInt);
            param_returnResult.Direction = System.Data.ParameterDirection.Output;

            try
            {
                noOfRowsAffected = context.Database.ExecuteSqlRaw("EXEC @ReturnResult = usp_AddOrderDetails @CategoryId,@ItemId, @Quantity,@DeliveryAddres, @OrderDate, @TotalPrice out,  @OrderId out", param_returnResult, param_customerId, param_itemId, param_quantity, param_deliveryAddress, param_orderDate, param_totalPrice, param_orderId);
                returnResult = Convert.ToInt32(param_returnResult.Value);
                orderId = Convert.ToInt32(param_orderId.Value);
                totalPrice = Convert.ToInt32(param_totalPrice.Value);
            }
            catch(Exception ex)
            {
                totalPrice = 0;
                orderId = 0;
                noOfRowsAffected =-1;
                returnResult = -99;

            }
            return returnResult; 

        }

    }
}
