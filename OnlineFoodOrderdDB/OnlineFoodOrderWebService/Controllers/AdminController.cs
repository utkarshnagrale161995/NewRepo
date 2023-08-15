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
    public class AdminController : Controller
    {
        AdminRepository adminRepository;

        public AdminController()
        {
            adminRepository = new AdminRepository();
        }


        //1.Add item using AddItem from AdminRepository
        [HttpPost]
        public JsonResult AddItemsByModels(Models.Items item)
        {
            bool status = false;
            string message;
            try
            {
                if (ModelState.IsValid)
                {
                    Items itemobj = new Items();
                    itemobj.ItemId = item.ItemId;
                    itemobj.ItemName = item.ItemName;
                    itemobj.CategoryId = item.CategoryId;
                    itemobj.Price = item.Price;
                    status = adminRepository.AddItem(itemobj);
                    message = "sucessfull addition operation, ItemId= " + item.ItemId;
                }
                else
                {
                    message = "unsuccesfull addition operation";
                }
            }
            catch(Exception ex)
            {
                message = "Some error occur, Please try after sometime!";
            }
            return Json(message);   
        }

        //2.Get all Category details
        [HttpGet]
        public JsonResult GetAllProducts()
        {
            int categoryid = 0;
            List<CategoryItemDetails> list = new List<CategoryItemDetails>();
            try
            {
                list = adminRepository.GetAllCategoryOrderDetails(categoryid);
            }
            catch(Exception ex)
            {
                list = null;
            }
            return Json(list);
        }

        //3. updateprice of an item
        [HttpPut]
        public JsonResult UpdatePrice()
        {
            bool status = false;
            string itemid = null;
            decimal price = 0;
            string message = null;
            try
            {
                status = adminRepository.UpdatePrice(itemid, price);
                if(status)
                {
                    message = "The price is updated sucessfull";
                }
                else
                {
                    message = "Item id does not exists";
                }
            }
            catch(Exception ex)
            {
                message = "Something went wrong please try after some time";
            }
            return Json(message);
        }
    }
}
