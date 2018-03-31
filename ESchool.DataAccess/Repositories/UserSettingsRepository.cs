namespace ESchool.DataAccess.Repositories
{
    using ESchool.Common.Interface.Repository;
    using ESchool.Common.Model.Users;

    using Microsoft.EntityFrameworkCore;

    public class UserSettingsRepository : Repository<AccauntSettingsDbModel>, IUserSettingsRepository
    {
        public UserSettingsRepository(DbContext context)
            : base(context)
        {
        }
    }
}