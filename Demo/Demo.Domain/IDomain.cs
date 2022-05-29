// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDomain.cs" company="The Virtual Forge">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <summary>
// 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Demo.Domain
{
    public interface IDomain<T> where T : struct
    {
        public T Id { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}