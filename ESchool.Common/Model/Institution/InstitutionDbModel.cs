namespace ESchool.Common.Model.Institution
{
    public class InstitutionDbModel : Entity
    {
        public int  CityId { get; set; }
        public CityDbModel City { get; set; }
        public string SchoolAdress { get; set; }
        public int SchoolNumber { get; set; }

    }
}