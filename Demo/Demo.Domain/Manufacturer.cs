// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Manufacturer.cs" company="The Virtual Forge">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <summary>
// 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Demo.Domain
{
    public class Manufacturer : Domain<int>
    {
        public string Name { get; set; }

        public ICollection<Model> Models { get; set; }
    }
}