using System.ComponentModel.DataAnnotations;

namespace CompetencyAssessmentBotTest.Models
{
    public class Suggestions
    {
        [Key]
        public int SNo { get; set; }

        [Required]
        public string VAM_ID { get; set; }

        //[Required]
        //public string EmployeeName { get; set; }

        [Required]
        public string Suggestion { get; set; }

        [Required]
        public string Requested_On { get; set; }

        public string status { get; set; }
    }
}
