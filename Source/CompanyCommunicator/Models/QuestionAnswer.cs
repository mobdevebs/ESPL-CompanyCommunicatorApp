
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
    public class QuestionAnswer
    {
        public string FromId { get; set; }

        public string Name { get; set; }

        public string AadId { get; set; }
        public string NotificationId { get; set; }
        public string Questions { get; set; }

        public string Title { get; set; }
        public string Author { get; set; }
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public string answer0 { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public string answer1 { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public string answer2 { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public string answer3 { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public string answer4 { get; set; }

        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public string answer5 { get; set; }
    }

    /// <summary>
    /// Gets or sets QuestionAnswerAdaptiveCardEntity.
    /// </summary>
    public class QuestionAnswerAdaptiveCardEntity : TableEntity
    {
        public QuestionAnswerAdaptiveCardEntity() { }

        public QuestionAnswerAdaptiveCardEntity(string NotificationId, string Notification)
        {
            PartitionKey = NotificationId;
            RowKey = Notification;
        }
        public string Title { get; set; }
        public string Author { get; set; }
        public string NotificationId { get; set; }
        public string Questions { get; set; }

        public string FromId { get; set; }

        public string Name { get; set; }

        public string AadId { get; set; }

        public string Question0 { get; set; }
        public string Question1 { get; set; }
        public string Question2 { get; set; }
        public string Question3 { get; set; }
        public string Question4 { get; set; }
        public string Question5 { get; set; }
        public string Answer0 { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Answer5 { get; set; }

    }

    public class QuestionAnswerExport
    {
        public string Name { get; set; }
        public string QuestionTitle { get; set; }
        public string Author { get; set; }
        public string Question1 { get; set; }
        public string Answer1 { get; set; }
        public string Question2 { get; set; }
        public string Answer2 { get; set; }
        public string Question3 { get; set; }
        public string Answer3 { get; set; }
        public string Question4 { get; set; }
        public string Answer4 { get; set; }
        public string Question5 { get; set; }
        public string Answer5 { get; set; }
        public string Question6 { get; set; }
        public string Answer6 { get; set; }
    }
}
