using ESchool.Common.Interface.Repository;
using ESchool.Common.Model.Users;
using Microsoft.EntityFrameworkCore;

namespace ESchool.DataAccess.Repositories
{
    using System;
    using System.Linq;

    public class UserRepository : Repository<AccauntDbModel>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public AccauntDbModel GetByEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException();
            }

            var result = this.DbSet.SingleOrDefault(x => x.Email == email);
            return result;
        }
    }
}