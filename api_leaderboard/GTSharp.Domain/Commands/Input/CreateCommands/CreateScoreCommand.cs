using System;
using Flunt.Notifications;
using Flunt.Validations;
using GTSharp.Domain.Resources;
using GTSharp.Domain.Utils;

namespace GTSharp.Domain.Commands.Input.CreateCommand
{
    public class CreateScoreCommand : Notifiable, ICommand
    {

        public string Title { get; set; }
        public int? Stage { get; set; }
        public int? Value { get; set; }
        public DateTime? Time { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? PlayerId { get; set; }
        public int? GameId { get; set; }

        public CreateScoreCommand(string title, int? stage, int? value, DateTime? time, int? playerId, int? gameId)
        {
            Title = title;
            Stage = stage;
            Value = value;
            Time = time;
            CreateDate = DateTime.Now;
            PlayerId = playerId;
            GameId = gameId;
        }

        public void Validate()
        {
            AddNotifications(new Contract()
            .Requires()

            .IsBetween(Title.Length0IfNullOrEmpty(), 3, 64, "Title", Messages.V_IsBetween.ToFormat("Title", "3", "64"))
            .IsNotNull(PlayerId, "PlayerId", Messages.V_IsNotNullOrEmpty.ToFormat("PlayerId"))
            .IsNotNull(GameId, "GameId", Messages.V_IsNotNullOrEmpty.ToFormat("GameId"))
            );
        }
    }
}