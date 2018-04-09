namespace ESchool.Common.Interface.Repository
{
    using ESchool.Common.Model.Users;

    public interface IUserRepository : IRepository<AccauntDbModel>
    {
        AccauntDbModel GetByEmail(string email);
    }
}