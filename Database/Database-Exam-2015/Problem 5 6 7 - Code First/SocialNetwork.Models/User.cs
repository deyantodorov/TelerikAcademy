namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        private ICollection<Image> images;
        private ICollection<Post> posts;
        private ICollection<Message> messages;

        public User()
        {
            this.images = new HashSet<Image>();
            this.posts = new HashSet<Post>();
            this.messages = new HashSet<Message>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Invalid length")]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Invalid length")]
        public string FirstName { get; set; }

        [StringLength(50, MinimumLength = 2, ErrorMessage = "Invalid length")]
        public string LastName { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<Image> Images
        {
            get { return this.images; }
            set { this.images = value; }
        }  
        
        public virtual ICollection<Post> Posts
        {
            get { return this.posts; }
            set { this.posts = value; }
        }
        
        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }
            set { this.messages = value; }
        }
    }
}
