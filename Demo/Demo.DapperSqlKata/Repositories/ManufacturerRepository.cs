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

namespace Demo.DapperSqlKata.Repositories
{
    public interface IManufacturerRepository : IRepository<Manufacturer, int>
    {

    }
    public class ManufacturerRepository : Repository<Manufacturer, int>, IManufacturerRepository
    {
        public ManufacturerRepository(ApplicationConnection applicationConnection) : base(applicationConnection)
        {
        }
    }

    public interface IModelRepository : IRepository<Model, int>
    {

    }

    public class ModelRepository : Repository<Model, int>, IModelRepository
    {
        public ModelRepository(ApplicationConnection applicationConnection) : base(applicationConnection)
        {
        }
    }
}