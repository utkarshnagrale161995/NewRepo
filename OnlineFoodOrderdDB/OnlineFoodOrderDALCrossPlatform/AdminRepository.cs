
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderDALCrossPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineFoodOrderDALCrossPlatform
{
    public class AdminRepository
    {
        OnlineFoodOrderDBBContext context;

        //Constructer
        public AdminRepository()
        {
            context = new OnlineFoodOrderDBBContext();
        }

        //1. Method AddItem
        public bool AddItem(string itemid, string itemName, int categoryId, decimal price)
        {
            bool status = false;
            Items item = new Items();
            item.ItemId = itemid;
            item.ItemName = itemName;
            item.CategoryId = categoryId;
            item.Price = price;
            try
            {
                context.Add<Items>(item);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        //1.1 AddItem method for web API by passing models
        public bool AddItem(Items item)
        {
            bool status = false;
            try
            {
                context.Add<Items>(item);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }


        //2. GetOrderDetails using table valued function
        
        public List<CategoryItemDetails> GetAllCategoryOrderDetails(int categoryId)
        {
            List<CategoryItemDetails> list = null;
            try
            {
                SqlParameter prmCategoryId = new SqlParameter("@categoryId", categoryId);
                list = context.CategoryItemDetails.FromSqlRaw
                    ("SELECT * FROM ufn_GetAllOrderDetails(@categoryId)", prmCategoryId).ToList();
            }
            catch (Exception ex)
            {
                list = null;
            }
            return list;
        }

        //3. UpdatePrice 
        public bool UpdatePrice(String itemId, decimal price)
        {
            bool status = false;
            Items item = context.Items.Find(itemId);
            try
            {
                if (item != null)
                {
                    item.Price = price;
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

    }
}
