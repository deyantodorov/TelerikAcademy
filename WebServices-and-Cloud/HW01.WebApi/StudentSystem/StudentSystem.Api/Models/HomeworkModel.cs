namespace StudentSystem.Api.Models
{
    using System;

    public class HomeworkModel
    {
        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }

        public int StudentId { get; set; }

        public Guid CourseId { get; set; }
    }
}