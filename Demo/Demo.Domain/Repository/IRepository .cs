// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository .cs" company="The Virtual Forge">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <summary>
// 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq.Expressions;

namespace Demo.Domain.Repository
{
    public  interface IRepository<T, in Key> where T : Domain<Key> where Key : struct
    {
        T GetById(Key id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}