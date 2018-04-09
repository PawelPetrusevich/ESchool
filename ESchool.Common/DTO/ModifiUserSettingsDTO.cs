namespace ESchool.Common.DTO
{
    using System;

    public class ModifiUserSettingsDTO
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public DateTime? DateOfBirth { get; set; }
    }
}