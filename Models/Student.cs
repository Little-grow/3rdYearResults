using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ThirdYear.Models
{
    public class Student
    {
        [Key]
        public int seating_no { get; set; }

        [Required]
        [MaxLength]
        public string arabic_name { get; set; } = "";
        
        public double total_degree { get; set; }

        public int student_case { get; set; }

        [Required]
        [MaxLength(250)]
        public string student_case_desc { get; set; } = "";

        [Required]
        public int cflag { get; set; }
    }
}
