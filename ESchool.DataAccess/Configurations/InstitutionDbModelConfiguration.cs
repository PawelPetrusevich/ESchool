using ESchool.Common.Model.Institution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.DataAccess.Configurations
{
    public class InstitutionDbModelConfiguration : IEntityTypeConfiguration<InstitutionDbModel>
    {
        public void Configure(EntityTypeBuilder<InstitutionDbModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.City).WithMany(x => x.InstitutionsCollection).HasForeignKey(x => x.Id);
        }
    }
}