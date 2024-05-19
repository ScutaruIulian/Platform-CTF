using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlatformCTF.Domains.Entities.User
{
    public class Exercise
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Exercise Name")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Exercise name must be between 4 and 50 characters.")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Exercise Description")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Exercise description must be between 10 and 500 characters.")]
        public string Description { get; set; }
        
        [Display(Name = "Link to download")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Link to download must be between 10 and 500 characters.")]
        public string DownloadLink { get; set; }

        [Required]
        [Display(Name = "Category")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Category must be between 4 and 50 characters.")]
        public string Category { get; set; }

        [Required]
        [Display(Name = "Flag")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Flag must be between 4 and 100 characters.")]
        public string Flag { get; set; }

        [Required]
        [Display(Name = "Level")]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "Level must be between 4 and 50 characters.")]
        public string Level { get; set; }
        
        [Required]
        [Display(Name = "Points")]
        [Range(50, 300, ErrorMessage = "Points must be between 50 and 300.")]
        public int Points { get; set; }
    }
}