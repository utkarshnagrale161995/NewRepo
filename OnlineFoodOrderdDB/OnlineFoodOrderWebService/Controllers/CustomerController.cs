using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderDALCrossPlatform;
using OnlineFoodOrderDALCrossPlatform.Models;
using System;
using System.Collections.Generic;

namespace OnlineFoodOrderWebService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomerController : Controller
    {
        CustomerRepository customerRepository;

        public CustomerController()
        {
            customerRepository = new CustomerRepository();
        }

        //1.Get food item details 
        [HttpGet]
        public JsonResult GetAllItems()
        {
            List<Items> itemslist = new List<Items>();
            try
            {
                itemslist = customerRepository.GetAllItems();
            }
            catch(Exception ex)
            {
                itemslist = null;
            }
            return Json(itemslist);
        }

        //2. Get all food item details under a given category name
        [HttpGet]
        public JsonResult GetAllItemsByCategoryName()
        {
            string categoryname = null;
            List<ItemDetails> itemdetailslist = new List<ItemDetails>();
            try
            {
                itemdetailslist = customerRepository.GetAllItemDetails(categoryname);
            }
            catch(Exception ex)
            {
                itemdetailslist = null;
            }
            return Json(itemdetailslist);
        }

        //3.Fetch the price of the item 
        [HttpGet]
        public JsonResult GetItemPrice()
        {
            string itemid = null;
            int price = 0;
            try
            {
                price = customerRepository.GetItemPrice(itemid);
            }
            catch(Exception ex)
            {
                price = 0;
            }
            return Json(price);
        }
        
        //4. Place order
        [HttpPost]
        public JsonResult PlaceOrder(Models.Orders order)
        {
            int returnresult = 0;
            string message = null;
            try
            {
            
                    returnresult = customerRepository.PlaceOrder(order.CustomerId,order.ItemId,order.Quantity,order.DeliveryAddress,order.OrderDate,out int OrderId, out int TotalPrice);
                    
              if(returnresult==1)
                {
                    message = "Order Placed Succesfully";
                }
              else if(returnresult== -1)
                {
                    message = "CustomerId does not exist";
                }
                else if (returnresult == -2)
                {
                    message = "ItemId does not exist";
                }
                else if (returnresult == -3)
                {
                    message = "Quantity is less than zero";
                }
                else if (returnresult == -4)
                {
                    message = "Delivery address is null";
                }
                else if (returnresult == -5)
                {
                    message = "Order date is not valid";
                }

            }
            catch (Exception ex)
            {
                message = "Something went wrong plz try again!";
            }
            return Json(message);
        }


    }
}
