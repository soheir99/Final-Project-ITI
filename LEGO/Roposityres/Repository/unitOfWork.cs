using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.Models;
using Roposityres.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USER_API.Authontaction;

namespace Roposityres.Repository
{
    public class unitOfWork : IUnitOfWork
    {
        private IModelRepository<Category> repo;
        private IModelRepository<Product> prodRepo;
        private readonly IModelRepository<Order> orderRepo;
        IModelRepository<Filter> filterRepo;
        IModelRepository<FilterOption> filterOptionRepo;
        private ApplicationDbContext context;


        public unitOfWork(IModelRepository<Category> _repo,
            ApplicationDbContext _Context,
            IModelRepository<FilterOption> _FilterOptionRepo,
            IModelRepository<Filter> _FilterRepo,
            IModelRepository<Product> _ProdRepo,
            IModelRepository<Order> _OrderRepo)
        {
            repo = _repo;
            context = _Context;
            prodRepo = _ProdRepo;
            orderRepo = _OrderRepo;
            filterOptionRepo = _FilterOptionRepo;
            filterRepo = _FilterRepo;
        }

        public async Task Save()
        {
             await context.SaveChangesAsync();
        }

        public IModelRepository<Category> GetCategryRepo()
        {
            return repo;
        }

        public IModelRepository<Product> GetProductRepo()
        {
            return prodRepo;
        }

        public IModelRepository<Order> GetOrderRepo()
        {
            return orderRepo;
        }

        public IModelRepository<Filter> GetFilterRepo()
        {
            return filterRepo;
        }
        public IModelRepository<FilterOption> GetFilterOptionRepo()
        {
            return filterOptionRepo;
        }
    }
}