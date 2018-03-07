using System;
using System.Collections.Generic;
using System.Text;

namespace ESchool.Common.Model.Users
{
    public class AccauntSettingsDbModel
    {
        public int AccauntId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public int? Age { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public int SchoolId { get; set; }

        public AccauntDbModel Accaunt { get; set; }
    }
}
