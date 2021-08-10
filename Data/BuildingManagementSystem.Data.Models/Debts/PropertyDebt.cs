namespace BuildingManagementSystem.Data.Models.Debts
{
    using System.ComponentModel.DataAnnotations;

    using BuildingManagementSystem.Data.Common.Models;
    using BuildingManagementSystem.Data.Models.BuildingData;

    using static BuildingManagementSystem.Common.GlobalConstants;

    public class PropertyDebt : BaseDeletableModel<int>
    {
        // one-to-many with Property - one property can have many monthly debts
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

        // one-to-many with Fee - one fee ammount can be used by many Properties (PropertyDebts)
        public int FeeId { get; set; }

        public virtual Fee Fee { get; set; }

        [MaxLength(PropertyDebtDescriptionMaxLength)]
        public string Descrtiption { get; set; }
    }
}
