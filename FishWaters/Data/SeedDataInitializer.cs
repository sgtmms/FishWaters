using FishWaters.Data;
using FishWaters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FishWaters.Data
{
    public class SeedDataInitializer
    {
        private FishWaterDbContext _context;

        public SeedDataInitializer(FishWaterDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // This how you seed in sample data to your database

            if (!_context.AnyWaterbodiesExist())
            {
                AddWaterbodies();
            }

            if (!_context.AnyFishtypesExist())
            {
                AddFishtypes();
            }

            if (!_context.AnyFishWatersExist())
            {
                AddFishWaters();
            }

        }

        private void AddFishtypes()
        {
            Fishtype walleye = new Fishtype();
            walleye.FishtypeName = "Walleye";
             _context.AddFishtype(walleye);

            Fishtype trout = new Fishtype();
            trout.FishtypeName = "Trout";          
            _context.AddFishtype(trout);

            Fishtype rainbowTrout = new Fishtype();
            rainbowTrout.FishtypeName= "Rainbow Trout";
            _context.AddFishtype(rainbowTrout);

            Fishtype musky = new Fishtype();
            musky.FishtypeName = "Muskellunge";
            _context.AddFishtype(musky);

            Fishtype pike = new Fishtype();
            pike.FishtypeName = "Northern Pike";
            _context.AddFishtype(pike);

            Fishtype largeMouth = new Fishtype();
            largeMouth.FishtypeName = "Largemouth Bass";
            _context.AddFishtype(largeMouth);

            Fishtype smallMouth = new Fishtype();
            smallMouth.FishtypeName = "Smallmouth Bass";
            _context.AddFishtype(smallMouth);

            Fishtype rock = new Fishtype();
            rock.FishtypeName = "Rock Bass";
            _context.AddFishtype(rock);

            Fishtype panFish = new Fishtype();
            panFish.FishtypeName = "PanFish";
            _context.AddFishtype(panFish);

            Fishtype yellowPerch = new Fishtype();
            yellowPerch.FishtypeName = "Yellow Perch";
            _context.AddFishtype(yellowPerch);

            Fishtype blackCrappie = new Fishtype();
            blackCrappie.FishtypeName = "Black Crappie";
            _context.AddFishtype(blackCrappie);

          



        }



        private void AddWaterbodies()
        {
            Waterbody american = new Waterbody() {

                LakeName = "American Lake",
                Acres = 1091.3,
                Latitude = 47.13287,
                Longitude = -122.5644747,
                County = "Pierce",
                State = "WA"


            };
      
            _context.AddWaterbody(american);

            Waterbody spanaway = new Waterbody() {
                LakeName = "Spanaway Lake",
                Acres = 250.9,
                Latitude = 47.110228,
                Longitude = -122.4502327,
                County = "Pierce",
                State = "WA"

            };
 

            _context.AddWaterbody(spanaway);


            Waterbody steilacoom = new Waterbody()
            {
                LakeName = "Steilacoom Lake",
                Acres = 306.2,
                Latitude = 47.161412,
                Longitude = -122.5336617,
                County = "Pierce",
                State = "WA"

            };


            _context.AddWaterbody(steilacoom);

        }

        private void AddFishWaters()
        {
            FishWater FishWater = new FishWater();

            FishWater.WaterbodyID = _context.GetWaterbodyID("American Lake", "Pierce", "WA");
            FishWater.FishtypeID = _context.GetFishtypeID("Rainbow Trout");
            _context.AddFishWater(FishWater);

            FishWater.FishtypeID = _context.GetFishtypeID("Largemouth Bass");
            _context.AddFishWater(FishWater);

            FishWater.FishtypeID = _context.GetFishtypeID("Smallmouth Bass");
            _context.AddFishWater(FishWater);

            FishWater.FishtypeID = _context.GetFishtypeID("Yellow Perch");
            _context.AddFishWater(FishWater);

            FishWater.FishtypeID = _context.GetFishtypeID("Rock Bass");
            _context.AddFishWater(FishWater);


            
            FishWater FishWater2 = new FishWater();

            FishWater2.WaterbodyID = _context.GetWaterbodyID("Spanaway Lake","Pierce", "WA");
            FishWater2.FishtypeID = _context.GetFishtypeID("Rainbow Trout");
            _context.AddFishWater(FishWater2);

            FishWater2.FishtypeID = _context.GetFishtypeID("Largemouth Bass");
            _context.AddFishWater(FishWater2);

            FishWater2.FishtypeID = _context.GetFishtypeID("Smallmouth Bass");
            _context.AddFishWater(FishWater2);

            FishWater2.FishtypeID = _context.GetFishtypeID("Yellow Perch");
            _context.AddFishWater(FishWater2);

            FishWater2.FishtypeID = _context.GetFishtypeID("Black Crappie");
            _context.AddFishWater(FishWater2);

            FishWater FishWater3 = new FishWater();
            FishWater3.WaterbodyID = _context.GetWaterbodyID("Steilacoom Lake", "Pierce", "WA");


            FishWater3.FishtypeID = _context.GetFishtypeID("Rainbow Trout");

            _context.AddFishWater(FishWater3);



        }
    }
}
