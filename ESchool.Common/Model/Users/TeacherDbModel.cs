using ESchool.Common.Enums;

namespace ESchool.Common.Model.Users
{
    public class TeacherDbModel : AccauntDbModel
    {
        public int ClassId { get; set; }

        public TeacherStatus TeacherStatus { get; set; }

        
    }
}