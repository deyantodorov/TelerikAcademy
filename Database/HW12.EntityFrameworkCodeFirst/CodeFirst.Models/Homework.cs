namespace CodeFirst.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Homework
    {
        [Key]
        public int Id { get; set; }

        public int CourseID { get; set; }

        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        public int StudentID { get; set; }

        [ForeignKey("StudentID")]
        public Student Student { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime? TimeSent { get; set; }
    }
}
