using ESchool.Common.Model.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.DataAccess.Configurations
{
    public class AccauntSettingsDbModelConfiguration : IEntityTypeConfiguration<AccauntSettingsDbModel>
    {
        public void Configure(EntityTypeBuilder<AccauntSettingsDbModel> builder)
        {
            builder.HasKey(x => x.AccauntId);
        }
    }
}