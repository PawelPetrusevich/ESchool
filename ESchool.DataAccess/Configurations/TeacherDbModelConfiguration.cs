using ESchool.Common.Model.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.DataAccess.Configurations
{
    public class TeacherDbModelConfiguration : IEntityTypeConfiguration<TeacherDbModel>
    {
        public void Configure(EntityTypeBuilder<TeacherDbModel> builder)
        {
        }
    }
}