using FishWaters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishWaters.Data
{
    public abstract class TextReader
    {
        public abstract void ReadFile();

        public abstract Dictionary<Waterbody, List<Fishtype>> GetLakeData(); 

        public List<Fishtype> ListFishes(string inString)
        {

            string processing = inString;

            string[] listed = processing.Split(",");

            List<Fishtype> fishList = new List<Fishtype>();


            foreach (string fishName in listed)
            {

                Fishtype fish = new Fishtype();
                fish.FishtypeName = fishName;
                fishList.Add(fish);


            }

            return fishList;

        }
    }

   
    }
