using System.ComponentModel.DataAnnotations;

namespace Platform_CTF.Models
{
    public class ExerciseAdd
    {
        [Required]
        [Display(Name = "Exercise Name")]
        public string Name { get; set; }
        
        [Required]
        [Display(Name = "Exercise Description")]
        public string Description { get; set; }
        
        [Required]
        [Display(Name = "Link to download if need exercise")]
        public string DownloadLink { get; set; }
        
        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }
        
        [Required]
        [Display(Name = "Flag")]
        public string Flag { get; set; }
        
        [Required]
        [Display(Name = "Level")]
        public int Level { get; set; }
    }
}