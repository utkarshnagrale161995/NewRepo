using System;
using System.Collections.Generic;
using OnlineFoodOrderDALCrossPlatform;
using OnlineFoodOrderDALCrossPlatform.Models;

namespace OnlineFoodOrderTestApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AdminRepository adminRepository = new AdminRepository();
            /*
            //1. Method AddItem
            bool status = adminRepository.AddItem("NIG", "Panner Grill", 1, 500);
            Console.WriteLine(status);
            if(status)
            {
                Console.WriteLine("New item Added Sucessfully");
            }
            else
            {
                Console.WriteLine("Something went wrong. Please Try again");
            }
            */
            

            /*
            //2. GetOrderDetails using table valued function
            int categoryId = 2;
            var list = adminRepository.GetAllCategoryOrderDetails(categoryId);
            if(list.Count == 0)
            {
                Console.WriteLine("No items available in the given category");
            }
            else
            {
                foreach(var item in list)
                {
                    Console.WriteLine("{0, -12}{1,-10}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}{8,-20}", item.OrderId, item.CustomerId, item.CustomerName, item.ItemId, item.ItemName, item.TotalPrice, item.DeliveryAddress,item.OrderDate,item.DeliveryStatus);
                }
            }
            */


            /*
            //3. UpdatePrice 
            string itemid = "CBR";
            decimal price = 60;
            bool status = adminRepository.UpdatePrice(itemid, price);
            if (status)
            {
                Console.WriteLine("Price updated Sucessfully");
            }
            else
            {
                Console.WriteLine("Something went wrong. Please Try again");
            }
            */


            //CommonRepository

            CommonRepository commonRepository = new CommonRepository();
            /*
            //1. Check delivery status
            int orderid = 1;
            int status = commonRepository.CheckDeliveryStatus(orderid);
            if (status==0)
            {
                Console.WriteLine("Order is Delivered");
            }
            else if(status==1)
            {
                Console.WriteLine("Order is not delivered");
            }
            else
            {
                Console.WriteLine("Order does not exists");
            }
           */
            /*
             //2. Delete details fron Order Table
             int orderid = 2;
             bool status = commonRepository.DeleteOrderDetails(orderid);
             if (status)
             {
                 Console.WriteLine("Order details canceld succesfully");
             }
             else
             {
                 Console.WriteLine("Something went wrong. Please Try again");
             }
            */
            /*
            //3.Get details for food ordered for a given orderId
            int orderid = 2;
            List<OrderDetails> orderDetailsList = commonRepository.GetAllOrderDetails(orderid);
            if (orderDetailsList.Count == 0)
            {
                Console.WriteLine("Order id does not exists");
            }
            else
            {
                foreach (var item in orderDetailsList)
                {
                    Console.WriteLine("{0, -12}{1,-10}{2,-20}{3,-20}{4,-20}{5,-20}{6,-20}{7,-20}", item.OrderId, item.CustomerId, item.CustomerName, item.ItemName, item.TotalPrice, item.DeliveryAddress, item.OrderDate, item.DeliveryStatus);
                }
            }
            */



            //Customer Repository
            CustomerRepository customerRepository = new CustomerRepository();
            /*
            //1.Get food item details
            List<Items> itemList = customerRepository.GetAllItems();
            if (itemList.Count == 0)
            {
                Console.WriteLine("Items does not exists");
            }
            else
            {
                foreach (var item in itemList)
                {
                    Console.WriteLine("{0, -12}{1,-10}{2,-20}{3,-20}", item.ItemId, item.ItemName, item.CategoryId, item.Price);
                }
            }
            */
            /*
            //2.Get items details with a specific category name
            string categoryname = "Pizza";
            var details = customerRepository.GetAllItemDetails(categoryname);
            if (details.Count == 0)
            {
                Console.WriteLine("details does not exists");
            }
            else
            {
                foreach (var item in details)
                {
                    Console.WriteLine("{0, -12}{1,-10}{2,-20}", item.ItemId, item.ItemName, item.Price);
                }
            }
            */

            /*
            //3.Fetch the price of the item 
            string itemid = "CBR";
            int price = customerRepository.GetItemPrice(itemid);
            if (price<0)
            {
                Console.WriteLine("Item does not exit");
            }
            else
            {
                Console.WriteLine("Price = ",price);
            }
            */
            
            //4. Add or placed order
            int customerid = 1005;
            string itemid = "ABC";
            int quantity = 100;
            string deliveryAddress = "Mysore";
            DateTime orderDate = DateTime.Today;
            int totalprice = 0;
            int orderid = 0;
            int returnResult= customerRepository.PlaceOrder(customerid,itemid,quantity,deliveryAddress,orderDate,out totalprice,out orderid);
            if (returnResult > 0)
            {
                Console.WriteLine("Item added succesfully");
            }
            else
            {
                Console.WriteLine("Something went wrong, Try Again!");
            }

        }
    }
}
