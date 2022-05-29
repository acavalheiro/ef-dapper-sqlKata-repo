// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Model.cs" company="The Virtual Forge">
// Copyright (c) 2022 All Rights Reserved
// </copyright>
// <summary>
// 
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Demo.Domain
{
    public class Model : Domain<int>
    {
        public string Name { get; set; }

        public int ManufacturerId { get; set; }

        public Manufacturer Manufacturer { get; set; }
    }
}