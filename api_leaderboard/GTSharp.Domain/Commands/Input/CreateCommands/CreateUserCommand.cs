using System;
using Flunt.Notifications;
using Flunt.Validations;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Commands.Input.CreateCommand
{
    public class CreateUserCommand : Notifiable, ICommand
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string NickName { get; set; }
        public string Avatar { get; set; }
        public string Country { get; set; }

        public CreateUserCommand(string email, string name, string picture, string nickName,
         string avatar, string country)
        {
            Email = email;
            Name = name;
            Picture = picture;
            NickName = nickName;
            Avatar = avatar;
            Country = country;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .IsEmail(Email, "Email", Messages.V_IsNotEmail.ToFormat("Email"))

            .IsBetween(Name.Length0IfNullOrEmpty(), 3, 100, "Name", Messages.V_IsBetween.ToFormat("Name", "3", "100"))
            .IsBetween(NickName.Length0IfNullOrEmpty(), 3, 256, "NickName", Messages.V_IsBetween.ToFormat("NickName", "3", "256"))

            .HasLen(Country, 2, "Country", Messages.V_HasLen.ToFormat("Country", "2"))

            .IsNotNullOrEmpty(Avatar, "Avatar", Messages.V_IsNotNullOrEmpty.ToFormat("Avatar"))
            .IsNotNullOrEmpty(Picture, "Picture", Messages.V_IsNotNullOrEmpty.ToFormat("Picture"))
            );
        }
    }
}