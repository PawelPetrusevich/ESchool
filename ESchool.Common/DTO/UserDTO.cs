using System;

namespace ESchool.Common.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public DateTime CreatersDate { get; set; }

        public string Loggin { get; set; }

        public string Password { get; set; }


    }
}