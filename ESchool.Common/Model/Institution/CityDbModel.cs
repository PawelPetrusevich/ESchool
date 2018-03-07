using System.Collections.Generic;

namespace ESchool.Common.Model.Institution
{
    public class CityDbModel : Entity
    {
        public string CityName { get; set; }

        public ICollection<InstitutionDbModel> InstitutionsCollection { get; set; }
        
    }
}