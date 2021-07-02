﻿namespace BuildingManagementSystem.Data.Models
{
    using BuildingManagementSystem.Data.Common.Models;

    public class Setting : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
