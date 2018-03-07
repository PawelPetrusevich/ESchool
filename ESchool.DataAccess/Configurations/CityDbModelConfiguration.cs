using ESchool.Common.Model.Institution;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.DataAccess.Configurations
{
    public class CityDbModelConfiguration : IEntityTypeConfiguration<CityDbModel>
    {
        public void Configure(EntityTypeBuilder<CityDbModel> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}