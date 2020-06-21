using Flunt.Notifications;
using Flunt.Validations;

namespace GTSharp.Domain.Commands.Input
{
    public class CreatePlayerCommand : Notifiable, ICommand
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
        public string Country { get; set; }

        public CreatePlayerCommand(string email, string name, string nickName, string avatar, string country)
        {
            Email = email;
            Name = name;
            NickName = nickName;
            Avatar = avatar;
            Country = country;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .HasMinLen(NickName, 3, "NickName", "NickName deve ter mais de 3 caracteres")
            .HasMinLen(Country, 6, "Country", "Country deve ter mais de 6 caracteres")
            );
        }
    }
}