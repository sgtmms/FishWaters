using FishWaters.Models;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishWaters.Data.TextSeeds
{

    public class WisconsinTextLoader : TextReader
    {
        Dictionary<Waterbody, List<Fishtype>> WaterbodiesMappedToFishes;

        List<Waterbody> waters = new List<Waterbody>();

        List<Fishtype> fishtypes = new List<Fishtype>();
        StreamReader reader = new StreamReader("lakes.csv");
       

        public WisconsinTextLoader()
        {
            ReadFile();
        }

        public override void ReadFile()
        {

            string line;
            int count = 0;

            while ((line = reader.ReadLine()) != null)
            {
                count += 1;


                string[] words = line.Split(';');

                string[] quotes = line.Split('"');
                if (count > 2)
                {


                    Waterbody water = new Waterbody();
                    List<Fishtype> fishes = new List<Fishtype>();


                    water.LakeName = words[0].Trim('"');

                    water.Acres = Convert.ToDouble(words[1].Trim('"'));

                    water.Latitude = Convert.ToDouble(words[2].Trim('"'));

                    water.Longitude = Convert.ToDouble(words[3].Trim('"'));

                    water.County = words[5].Trim('"');

                    water.State = words[6].Trim('"');

                    waters.Add(water);


                    //Console.Write(water.LakeName);
                    List<Fishtype> fishlist = this.ListFishes(words[4].Trim('"'));


                }



            }

        }

    public override Dictionary<Waterbody, List<Fishtype>> GetLakeData()
        {

            return this.WaterbodiesMappedToFishes;
        }


    }
    }
}
