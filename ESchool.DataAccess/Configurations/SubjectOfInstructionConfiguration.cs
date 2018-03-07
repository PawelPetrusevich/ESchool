using ESchool.Common.Model.SubjectOfInstuctions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ESchool.DataAccess.Configurations
{
    public class SubjectOfInstructionConfiguration : IEntityTypeConfiguration<SubjectOfInstructionsDbModel>
    {
        public void Configure(EntityTypeBuilder<SubjectOfInstructionsDbModel> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}