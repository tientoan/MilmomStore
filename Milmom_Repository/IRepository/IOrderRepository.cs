﻿using MilmomStore_BusinessObject.Model;
using Milmom_Repository.IBaseRepository;
namespace Milmom_Repository.IRepository;

public interface IOrderRepository:IBaseRepository<Order>
{
    public Task AddOrderAsync(Order order);
}