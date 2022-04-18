using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Roposityres.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOrdersController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IModelRepository <Order> OrderRepo;
        public UserOrdersController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            OrderRepo = unitOfWork.GetOrderRepo();
        }
 
        #region Add Order To DataBase
        [HttpPost]
        [Route("Order/add")]
        public async Task<Order> AddOrder(Order order)
        {
            var result = await OrderRepo.Add(order);
            await unitOfWork.Save();
            return result;
        } 
        #endregion

        #region Delete Order
        [HttpDelete]
        [Route("Order/delete")]
        public async Task<Order> DeleteOrder(Order order)
        {
            var result = await OrderRepo.Remove(order);
            await unitOfWork.Save();
            return result;
        }

        #endregion

        #region Get Order By User ID
        [HttpGet]
        [Route("Order/{userId}")]
        public async Task<IQueryable<Order>> GetOrder(int userId)
        {
            var result = await OrderRepo.FindByCondition(i => i.CusId == userId);

            return result;
        }
        #endregion

        //[HttpGet]
        //[Route("Order/Items/{orderId}")]
        //public async Task<ResultViewModel> GetOrderItems(int orderId)
        //{
        //    Result.Data = await OrderItemRepo.FindByCondition(i => i.OrderId == orderId);
        //    Result.IsSucess = true;
        //    return Result;
        //}
    }
}
