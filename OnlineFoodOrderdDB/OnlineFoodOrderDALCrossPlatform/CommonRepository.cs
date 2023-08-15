using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderDALCrossPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineFoodOrderDALCrossPlatform
{
    public class CommonRepository
    {
        OnlineFoodOrderDBBContext context;

        public CommonRepository()
        {
            context = new OnlineFoodOrderDBBContext();
        }

        //1. Check delivery status
        public int CheckDeliveryStatus(int orderId)
        {
            int returnValue = -1;
            try
            {
                returnValue = (from p in context.Orders select OnlineFoodOrderDBBContext.ufn_CheckDeliveryStatus(orderId)).FirstOrDefault();
            }
            catch(Exception ex)
            {
                returnValue = -99;
            }
            return returnValue;
        }

        //2. Delete details fron Order Table
        public bool DeleteOrderDetails(int orderId)
        {
            Orders order = null;
            bool status = false;
            try
            {
                order = context.Orders.Find(orderId);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        //3.Get details for food ordered for a given orderId
        public List<OrderDetails> GetAllOrderDetails(int orderId)
        {
            List<OrderDetails> list = null;
            try
            {
                SqlParameter prmOrderId = new SqlParameter("@orderId", orderId);
                list = context.OrderDetails.FromSqlRaw
                    ("SELECT * FROM ufn_GetOrderDetails(@orderId)", prmOrderId).ToList();
            }
            catch (Exception ex)
            {
                list = null;
            }
            return list;
        }




    }
}
