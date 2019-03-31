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

            List<Fishtype> fishlist = null;

            

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

                    fishlist = this.ListFishes(words[4].Trim('"'));
                    //If Lake is in 2 counties split county string and add both counties for that lake

                    int numberOfCounties = water.County.Split().Length;

                    if (numberOfCounties > 1) {

                        water.County = water.County.Split()[0];
                        Waterbody water2 = new Waterbody();

                        water2.LakeName = water.LakeName;

                        water2.Acres = water.Acres;

                        water2.Latitude = water.Latitude;

                        water2.Longitude = water.Longitude;

                        water2.County = water.County;

                        water2.State = water.State;

                        this.WaterbodiesMappedToFishes.Add(water2, fishlist);


                    }


                    this.WaterbodiesMappedToFishes.Add(water, fishlist);


                }



            }

        }

    public override Dictionary<Waterbody, List<Fishtype>> GetLakeData()
    {

       return this.WaterbodiesMappedToFishes;
    }


    }
}

