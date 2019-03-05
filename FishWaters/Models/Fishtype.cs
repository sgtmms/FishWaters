using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishWaters.Models
{
    public class Fishtype
    {
        [Key]
        public int FishtypeID { get; set; }
       
        [Required]
        public string FishtypeName { get; set; }

        public List<FishWater> FishWaters { get; set; }

    }
}
