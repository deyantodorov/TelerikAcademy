namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Friendship
    {
        private ICollection<Message> messages;

        public Friendship()
        {
            this.messages = new HashSet<Message>();
        }

        [Key]
        public int Id { get; set; }

        public int FirstUserId { get; set; }

        public User FirstUser { get; set; }

        public int SecondUserId { get; set; }

        public User SecondUser { get; set; }

        public bool Approved { get; set; }

        public DateTime? ApproveDate { get; set; }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }
    }
}
