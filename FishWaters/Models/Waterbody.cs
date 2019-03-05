using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FishWaters.Models
{
    public class Waterbody
    {
        [Key]
        public int WaterbodyID { get; set; }

        [Required]
        public string LakeName { get; set; }
        public double Acres { get; set; }

        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longitude { get; set; }
        [Required]
        public string County { get; set; }
        [Required]
        public string State { get; set; }
        public List<FishWater> FishWaters { get; set; }










    }
}