
namespace Microsoft.Teams.Apps.CompanyCommunicator.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.Azure.Cosmos.Table;

    /// <summary>
    /// Base QuestionAnswer model class.
    /// </summary>
    public class UserReaction
    {
        public string FromId { get; set; }

        public string Name { get; set; }

        public string AadId { get; set; }
        public string ActivityId { get; set; }
        public string ReactionType { get; set; }
    }

    public class UserReactionEntity : TableEntity
    {
        public UserReactionEntity() { }

        public UserReactionEntity(string ActivityId, string FromId)
        {
            PartitionKey = ActivityId;
            RowKey = FromId;
        }
        public string FromId { get; set; }

        public string Name { get; set; }

        public string AadId { get; set; }
        public string ActivityId { get; set; }
        public string ReactionType { get; set; }
    }

    public class UserReactionExport
    {
        public int LikeCount { get; set; }
        public int HeartCount { get; set; }
        public int LaughCount { get; set; }
        public int SurprisedCount { get; set; }
        public int SadCount { get; set; }
        public int AngryCount { get; set; }
    }
}
