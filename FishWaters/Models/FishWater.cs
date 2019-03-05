namespace FishWaters.Models
{
    public class FishWater
    {

        public int FishWaterID { get; set;}
        public int WaterbodyID { get; set; }
        public int FishtypeID { get; set; }

        public Waterbody Waterbody { get; set; }
        public Fishtype Fishtype { get; set; }

    }
}