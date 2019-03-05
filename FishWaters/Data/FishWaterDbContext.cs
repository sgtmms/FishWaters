using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishWaters.Models;
using FishWaters.Data;


namespace FishWaters.Data
{

    public class FishWaterDbContext : DbContext, IFishWatersRepository
    {
        public FishWaterDbContext(DbContextOptions<FishWaterDbContext> options) : base(options)
        {


        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FishWater>()
                 .HasKey(fishWater => new { fishWater.WaterbodyID, fishWater.FishtypeID });

            modelBuilder.Entity<FishWater>()
                .HasOne(fishWater => fishWater.Waterbody)
                .WithMany(waterbody => waterbody.FishWaters)
                .HasForeignKey(fishWater => fishWater.WaterbodyID);

            modelBuilder.Entity<FishWater>()
                .HasOne(fishWater => fishWater.Fishtype)
                .WithMany(fishtype=> fishtype.FishWaters)
                .HasForeignKey(fishWater => fishWater.FishtypeID);
        }



        DbSet<Waterbody> Waterbodies { get; set; }
        DbSet<FishWater> FishWaters { get; set; }
        DbSet<Fishtype> Fishtypes { get; set; }



        public List<Waterbody> GetWaterbodies()
            {

            List<Waterbody> waterbodies;
            waterbodies = Waterbodies.OrderBy(a => a.State)
                .ThenBy(a => a.County)
                .ThenBy(a => a.LakeName)
                .ToList();

            return waterbodies;
            }

        public List<Fishtype> GetFishtypes()
            {
            List<Fishtype> fishtypes;
            fishtypes = Fishtypes.OrderBy(a => a.FishtypeName).ToList();

                return fishtypes;
            }

       

        public List<Waterbody> GetWaterbodiesWithFishtypes()
            {

            List<Waterbody> waterbodies;

            waterbodies = Waterbodies.Include(waterbody => waterbody.FishWaters)
                .ThenInclude(fishwater => fishwater.Fishtype)
                .OrderBy(a => a.State)
                .ThenBy(a => a.County)
                .ThenBy(a => a.LakeName)
                .ToList();

            Console.Write(waterbodies.ToString());
            return waterbodies;

            }

        public void AddWaterbody(Waterbody waterbody)
            {
                Waterbodies.Add(waterbody);
                SaveChanges();
            }
        public void AddFishtype(Fishtype fishtype)
            {
                Fishtypes.Add(fishtype);
                SaveChanges();

            }

        public void AddFishWater(FishWater fishWater)
            {
                FishWaters.Add(fishWater);
                SaveChanges();

            }

            public bool AnyWaterbodiesExist()
            {
                return Waterbodies.Any();
            }

            public bool AnyFishtypesExist()
            {
                return Fishtypes.Any();
            }

            public bool AnyFishWatersExist()
            {
                return FishWaters.Any();
            }



        public int GetWaterbodyID(string lakeName, string county, string state)
            {
                var foundWaterbody = Waterbodies.Where(w => w.LakeName == lakeName && w.County == county
                        && w.State == state)
                    .FirstOrDefault();

                if (foundWaterbody == null)
                {
                    return 0;
                }

                return foundWaterbody.WaterbodyID;
            }

        public int GetWaterbodyID(double latitude, double longitude)
        {
            var foundWaterbody = Waterbodies.Where(w => w.Latitude == latitude && w.Longitude == longitude)
                .FirstOrDefault();

            if (foundWaterbody == null)
            {
                return 0;
            }

            return foundWaterbody.WaterbodyID;
        }


        public int GetFishtypeID(string fishtypeName)
            {
                var foundFishType = Fishtypes.FirstOrDefault(f => f.FishtypeName == fishtypeName);

                if (foundFishType == null)
                {
                    return 0;

                }

                return foundFishType.FishtypeID;
            }

        public void AddFishToWaterbody(int fishID, int waterbodyId)
        {
            FishWater FishWater = new FishWater();

            FishWater.WaterbodyID = waterbodyId;
            FishWater.FishtypeID = fishID;

            FishWaters.Add(FishWater);
        }


        

    }







}
