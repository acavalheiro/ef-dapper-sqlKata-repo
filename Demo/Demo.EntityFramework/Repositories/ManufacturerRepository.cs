// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ManufacturerRepository.cs" company="The Virtual Forge">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <summary>
// 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Demo.Domain;
using Demo.Domain.Repository;

namespace Demo.EntityFramework.Repositories
{
    public interface IManufacturerRepository : IRepository<Manufacturer, int>
    {

    }
    public class ManufacturerRepository : Repository<Manufacturer, int> , IManufacturerRepository
    {
        public ManufacturerRepository(ApplicationDbContext context) : base(context)
        {
        }
    }

    public interface IModelRepository : IRepository<Model, int>
    {

    }

    public class ModelRepository : Repository<Model, int>, IModelRepository
    {
        public ModelRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}