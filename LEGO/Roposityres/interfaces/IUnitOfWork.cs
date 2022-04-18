﻿using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roposityres.interfaces
{
    public interface IUnitOfWork
    {
        Task Save();

        IModelRepository<Category> GetCategryRepo();
        IModelRepository<Order> GetOrderRepo();
        IModelRepository<Product> GetProductRepo();
        IModelRepository<Filter> GetFilterRepo();
        IModelRepository<FilterOption> GetFilterOptionRepo();
    }
}