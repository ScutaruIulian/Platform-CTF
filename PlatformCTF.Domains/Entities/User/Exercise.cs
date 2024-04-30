using System.ComponentModel.DataAnnotations;

namespace PlatformCTF.Domains.Entities.User
{
    public class Exercise
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Link")]
        public string Link { get; set; }
        [Required]
        [Display(Name = "Level")]
        public int Level { get; set; }
        [Required]
        [Display(Name = "Category")]
        public string Category { get; set; }
        [Required]
        [Display(Name = "Flag")]
        public string Flag { get; set; }
    }
}