using ESchool.Common.Model.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.DataAccess.Configurations
{
    public class LearnerDbModelConfiguration : IEntityTypeConfiguration<LearnerDbModel>
    {
        public void Configure(EntityTypeBuilder<LearnerDbModel> builder)
        {
        }
    }
}