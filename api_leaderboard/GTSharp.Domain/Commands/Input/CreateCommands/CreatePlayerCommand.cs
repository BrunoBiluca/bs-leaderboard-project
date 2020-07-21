using System;
using Flunt.Notifications;
using Flunt.Validations;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Commands.Input.CreateCommand
{
    public class CreatePlayerCommand : Notifiable, ICommand
    {
        public string NickName { get; set; }
        public string Avatar { get; set; }
        public string Country { get; set; }
        public int? IdUser { get; set; }
        public int? IdGame { get; set; }

        public CreatePlayerCommand(string nickName, string avatar,
         string country, int? idUser, int? idGame)
        {
            NickName = nickName;
            Avatar = avatar;
            Country = country;
            IdUser = idUser;
            IdGame = idGame;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()
            .IsBetween(NickName.Length0IfNullOrEmpty(), 3, 256, "NickName", Messages.V_IsBetween.ToFormat("NickName", "3", "256"))

            .HasLen(Country, 2, "Country", Messages.V_HasLen.ToFormat("Country", "2"))

            .IsNotNullOrEmpty(Avatar, "Avatar", Messages.V_IsNotNullOrEmpty.ToFormat("Avatar"))
            .IsNotNull(IdUser, "IdUser", Messages.V_IsNotNullOrEmpty.ToFormat("IdUser"))
            .IsNotNull(IdGame, "IdGame", Messages.V_IsNotNullOrEmpty.ToFormat("IdGame"))
            );
        }
    }
}