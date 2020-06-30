using System;
using Flunt.Notifications;
using Flunt.Validations;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Commands.Input.CreateCommand
{
    public class CreateGameCommand : Notifiable, ICommand
    {
        public string Title { get; set; }
        public string Genre { get; set; }

        public CreateGameCommand(string title, string genre)
        {
            Title = title;
            Genre = genre;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()

            .IsBetween(Title.Length0IfNullOrEmpty(), 3, 100, "Title", Messages.V_IsBetween.ToFormat("Title", "3", "100"))
            .IsBetween(Genre.Length0IfNullOrEmpty(), 3, 256, "Genre", Messages.V_IsBetween.ToFormat("Genre", "3", "256"))
            );
        }
    }
}