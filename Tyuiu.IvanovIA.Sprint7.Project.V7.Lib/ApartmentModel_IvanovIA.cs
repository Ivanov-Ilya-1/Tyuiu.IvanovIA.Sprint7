using System;

namespace Tyuiu.IvanovIA.Sprint7.Project.V7.Lib
{
    public class ApartmentModel_IvanovIA
    {
        public int EntranceNumber { get; set; }
        public int ApartmentNumber { get; set; }
        public decimal TotalArea { get; set; }
        public decimal LivingArea { get; set; }
        public int RoomsCount { get; set; }
        public string TenantLastName { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int FamilyMembers { get; set; }
        public int ChildrenCount { get; set; }
        public bool HasDebt { get; set; }
        public string Notes { get; set; }
    }
}