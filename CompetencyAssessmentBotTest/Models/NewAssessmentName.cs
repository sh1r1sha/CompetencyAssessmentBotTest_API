using System.ComponentModel.DataAnnotations;

namespace CompetencyAssessmentBotTest.Models
{
    public class NewAssessmentName
    {
        [Key]
        public int SNo { get; set; }

        [Required]
        public string VAM_ID { get; set; }

        [Required]
        public string EmployeeName { get; set; }

        [Required]
        public string AssessmentName { get; set; }
        
        [Required]
        public string PrimarySkill { get; set; }

        [Required]
        public string CurrentSkill { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public string Requested_On { get; set; }

        public string status { get; set; }
    }
}
