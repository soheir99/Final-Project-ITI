using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Roposityres.interfaces;
using Roposityres.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USER_API.Authontaction;

namespace API_User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IModelRepository<Product> productrepo;

        private readonly IModelRepository<Category> categoryRepo;
        public UserController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
            productrepo = unitOfWork.GetProductRepo();
            categoryRepo = unitOfWork.GetCategryRepo();
        }
        #region Get All Product
        [HttpGet]
        [Route("Product")]
        public async Task<IQueryable<Product>> GetAllProduct()
        {
            var result = await productrepo.GetAll();
            return result;
        }
        #endregion

        #region Get Product By ID
        [HttpGet]
        [Route("Product/{PrdId}")]
        public async Task<Product> GetProductByID(int id)
        {

            var result = await productrepo.GetById(id);

            return result;
        }

        #endregion

        #region Return all Product in Specific Cateogray
        [HttpGet]
        [Route("ProductByCatID/{CatID}")]
        public async Task<IQueryable<Product>> GetPrdByCatID(int CatID)
        {
            var result = await productrepo.FindByCondition(i => i.CatId == CatID);
            return result;
        }
        #endregion

        #region Search for Product By Name

        [HttpGet]
        [Route("Search/{search}")]
        public async Task<Product> Search(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                var Search = await productrepo.FindByCondition(i => i.ProdName.Contains(search)
                || i.ProdDescreption.Contains(search));
                var result = Search.FirstOrDefault();
                if (Search.Any())
                {

                    return (Product)result;
                }
            }
            return (Product)await productrepo.GetAll();
        }
        #endregion

        #region Get All Category
        [HttpGet]
        [Route("Category")]
        public async Task<IQueryable<Category>> GetAllCategory()
        {
            var allcat = await categoryRepo.GetAll();
            return allcat;
        }
        #endregion


    }
}