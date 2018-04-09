namespace ESchool.DataAccess.Context
{
    using ESchool.Common.Model.Institution;
    using ESchool.Common.Model.SubjectOfInstuctions;
    using ESchool.Common.Model.Users;
    using ESchool.DataAccess.Configurations;

    using Microsoft.EntityFrameworkCore;

    public class ESchoolContext : DbContext
    {
        public ESchoolContext(DbContextOptions<ESchoolContext> options) : base(options)
        {
        }

        public DbSet<AccauntDbModel> AccauntDbModels { get; set; }

        public DbSet<AccauntSettingsDbModel> AccauntSettingsDbModels { get; set; }

        public DbSet<SubjectOfInstructionsDbModel> SubjectOfInstructionsDbModels { get; set; }

        public DbSet<InstitutionDbModel> InstutionDbModels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AccauntDbModelConfigurtion());
            modelBuilder.ApplyConfiguration(new AccauntSettingsDbModelConfiguration());
            modelBuilder.ApplyConfiguration(new CityDbModelConfiguration());
            modelBuilder.ApplyConfiguration(new InstitutionDbModelConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectOfInstructionConfiguration());
        }
    }
}