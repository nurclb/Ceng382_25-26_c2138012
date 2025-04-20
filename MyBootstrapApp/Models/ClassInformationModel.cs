using System.ComponentModel.DataAnnotations;

namespace MyBootstrapApp.Models
{
    public class ClassInformationModel
    {
        public int Id { get; set; }

        [Required]
        public string ClassName { get; set; }

        [Range(1, 1000)]
        public int StudentCount { get; set; }

        public string Description { get; set; }
    }
}
