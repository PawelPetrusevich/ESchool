using ESchool.Common.Model.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.DataAccess.Configurations
{
    public class AccauntDbModelConfigurtion : IEntityTypeConfiguration<AccauntDbModel>
    {
        public void Configure(EntityTypeBuilder<AccauntDbModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder
                .HasOne(x => x.AccauntSettings)
                .WithOne(x => x.Accaunt)
                .IsRequired();
        }
    }
}