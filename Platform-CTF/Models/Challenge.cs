using System.ComponentModel.DataAnnotations;

namespace Platform_CTF.Models
{
    public class Challenge
    {
        [Key]
        public object Id { get; set; }
        [Required]
        [Display(Name = "Challenge Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Challenge Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Link to download if need challenge")]
        public string DownloadLink { get; set; }
        
        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Submit Flag")]
        public string Flag { get; set; }
        
        [Required]
        [Display(Name = "Level")]
        public int Level { get; set; }
        
        [Required]
        [Display(Name = "Points")]
        public int Points { get; set; }
    }
}