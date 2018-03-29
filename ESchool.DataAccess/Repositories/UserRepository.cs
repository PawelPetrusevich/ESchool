using ESchool.Common.Interface.Repository;
using ESchool.Common.Model.Users;
using Microsoft.EntityFrameworkCore;

namespace ESchool.DataAccess.Repositories
{
    public class UserRepository : Repository<AccauntDbModel>,IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}