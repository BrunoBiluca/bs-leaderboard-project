using System.ComponentModel.DataAnnotations;

namespace GTSharp.Domain.Entities
{
    public class User : Entity
    {
        [MaxLength(256)]
        public string Email { get; private set; }

        [MaxLength(256)]
        public string Name { get; private set; }

        public string Picture { get; private set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string NickName { get; private set; }

        public string Avatar { get; private set; }

        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        public string Country { get; private set; }

        public User(string email, string name, string picture, string nickName, string avatar, string country)
        {
            Email = email;
            Name = name;
            Picture = picture;
            NickName = nickName;
            Avatar = avatar;
            Country = country;
        }
    }
}