namespace ESchool.Common.Model.Users
{
    public class AccauntDbModel : Entity
    {
        public string Loggin { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public AccauntSettingsDbModel AccauntSettings { get; set; }
    }
}
