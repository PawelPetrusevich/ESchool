// --------------------------------------------------------------------------------------------------------------------
// <copyright company="ESchool" file=" UserServiceTest.cs">
//  Creator name: 
//  Solution: ESchool
//  Project: BusinessLogicTests    
// </copyright>
// <summary>
//  Filename: UserServiceTest.cs
//  Created day: 24.04.2018    16:27
//  </summary> 
//  --------------------------------------------------------------------------------------------------------------------

using NUnit.Framework;

namespace BusinessLogicTests
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;

    using ESchool.BusinessLogic.Service;
    using ESchool.Common;
    using ESchool.Common.DTO;
    using ESchool.Common.Interface.Repository;
    using ESchool.Common.Model.Users;

    using Moq;

    [TestFixture]
    public class UserServiceTest
    {
        private readonly Mock<IUserRepository> _userRepository = new Mock<IUserRepository>();

        private readonly Mock<IUserSettingsRepository> _userSettingRepository = new Mock<IUserSettingsRepository>();

        private IMapper _mapper;

        private UserService _userService;

        [SetUp]
        public void InitializeTest()
        {
            var mapperConfig = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfiler>());

            this._mapper = mapperConfig.CreateMapper();

            this._userRepository.Setup(x => x.GetByEmail(It.IsNotNull<string>())).Returns(new AccauntDbModel());
            this._userRepository.Setup(x => x.AddAsync(It.IsNotNull<AccauntDbModel>()))
                .Returns(Task.FromResult<AccauntDbModel>(new AccauntDbModel()));

            this._userService = new UserService(this._userRepository.Object, this._mapper, this._userSettingRepository.Object);
        }

        [Test]
        public void CreateUserTest()
        {
            var userDto = new CreatedUserDto() { Email = "test@test.ru", Loggin = "test", Password = "test" };
            var result = this._userService.CreateUser(userDto);
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateUserNullExeptionTest()
        {
            Assert.ThrowsAsync<ArgumentNullException>(() => this._userService.CreateUser(null));
        }
    }
}