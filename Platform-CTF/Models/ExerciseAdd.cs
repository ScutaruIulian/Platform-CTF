using System.ComponentModel.DataAnnotations;

namespace Platform_CTF.Models
{
    public class ExerciseAdd
    {
        [Required]
        [Display(Name = "Exercise Name")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Exercise Description")]
        public string Description { get; set; }
        
        [DataType(DataType.Url)]
        [Display(Name = "Link to download if need exercise")]
        public string DownloadLink { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required] 
        [DataType(DataType.Text)]
        [Display(Name = "Flag")] 
        public string Flag { get; set; }

        [Required] 
        [DataType(DataType.Text)]
        [Display(Name = "Level")] 
        public string Level { get; set; }
    }
}