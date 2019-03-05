using FishWaters.Data;
using FishWaters.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestFishWaters
{
    class FishContext : IFishWatersRepository
    {

        private readonly List<Fishtype> _fishtypes;
        private readonly List<Waterbody> _waterbodies;
        public FishContext()
        {
            _fishtypes = new List<Fishtype>()
            {
                new Fishtype() { FishtypeID = 200,
                    FishtypeName = "Guppy" },
                new Fishtype() { FishtypeID = 400,
                    FishtypeName = "Gold Fish" },
                new Fishtype() { FishtypeID = 600,
                    FishtypeName = "Beta" }
            };


            _waterbodies = new List<Waterbody>()
            {
                new Waterbody() { WaterbodyID = 100,
                    LakeName = "Blue Lake" },
                new Waterbody() { WaterbodyID = 300,
                    LakeName = "Green Lake" },
                new Waterbody() { WaterbodyID = 500,
                    LakeName = "Brown Lake" }
            };


        }

        public List<Fishtype> GetFishtypes()
        {
            return _fishtypes;
        }

        public void AddFishtype(Fishtype fishtype)
        {
            fishtype.FishtypeID = 5;
            _fishtypes.Add(fishtype);
            
        }

        public List<Waterbody> GetWaterbodies()
        {
            return _waterbodies;
        }

        public void AddWaterbody(Waterbody waterbody)
        {
            waterbody.WaterbodyID = 5;
            _waterbodies.Add(waterbody);
           
        }


        public void AddFishWater(FishWater fishwater)
        {
            throw new NotImplementedException();
        }

        public void AddFishToWaterbody(int fishID, int waterbodyId)
        {
            throw new NotImplementedException();
        }

        public bool AnyFishtypesExist()
        {
            throw new NotImplementedException();
        }

        public bool AnyWaterbodiesExist()
        {
            throw new NotImplementedException();
        }

        public bool AnyFishWatersExist()
        {
            throw new NotImplementedException();
        }

        public int GetFishtypeID(string fishtypeName)
        {
            throw new NotImplementedException();
        }

       
        public List<Waterbody> GetWaterbodiesWithFishtypes()
        {
            throw new NotImplementedException();
        }

        public int GetWaterbodyID(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }

        public int GetWaterbodyID(string lakeName, string county, string state)
        {
            throw new NotImplementedException();
        }
    }
}


