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
    public class CommonController : Controller
    {
        CommonRepository commonRepository;

        public CommonController()
        {
            commonRepository = new CommonRepository();
        }

        //1.Check delivery status
        [HttpGet]
        public JsonResult CheckDeliveryStatus()
        {
            int orderid = 0;
            int returnvalue = -1;
            string message = null;
            try
            {
                returnvalue = commonRepository.CheckDeliveryStatus(orderid);
                if(returnvalue==0)
                {
                    message = "Order is delivered";
                }
                else
                {
                    message = "Order is not delivered";
                }
            }
            catch(Exception ex)
            {
                message = "Something went wrong please try again";
            }
            return Json(message);

        }

        //2. Delete details fron Order Table
        [HttpDelete]
        public JsonResult DeleteOrderDetails()
        {
            int orderid = 0;
            bool status = false;
            string message = null;
            try
            {
                status=commonRepository.DeleteOrderDetails(orderid);
                if(status)
                {
                    message = "Details deleted succesfully";
                }
                else
                {
                    message = "orderid does not exist";
                }
            }
            catch(Exception ex)
            {
                message = "Something went wrong please try again!";
            }
            return Json(message);
        }

        //3. Get all order details
        [HttpGet]
        public JsonResult GetAllOrderDetails()
        {
            List<OrderDetails> list = new List<OrderDetails>();
            int orderid=0;
            try
            {
                list=commonRepository.GetAllOrderDetails(orderid);
            }
            catch(Exception ex)
            {
                list = null;
            }
            return Json(list);
        }
    }
}
