using System.ComponentModel.DataAnnotations;

namespace T05.WebCounterWithSql.Models
{
    public class Counter
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public long Visits { get; set; }
    }
}