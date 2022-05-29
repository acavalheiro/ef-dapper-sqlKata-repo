// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Domain.cs" company="The Virtual Forge">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <summary>
// 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Demo.Domain
{
    public abstract class Domain<T> : IDomain<T> where T : struct
    {
        protected Domain()
        {
            this.CreatedDate = DateTime.Now;
            
        }

        [Key]
        public T Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }

}