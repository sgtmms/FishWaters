using System.Collections.Generic;
using FishWaters.Models;


namespace FishWaters.Data
{
    public interface IFishWatersRepository
    {
        void AddFishtype(Fishtype fishtype);
        void AddWaterbody(Waterbody waterbody);
        void AddFishWater(FishWater fishwater);
        void AddFishToWaterbody(int fishID, int waterbodyId);
        bool AnyFishtypesExist();
        bool AnyWaterbodiesExist();
        bool AnyFishWatersExist();
        int GetFishtypeID(string fishtypeName);
        List<Fishtype> GetFishtypes();
        List<Waterbody> GetWaterbodies();
        List<Waterbody> GetWaterbodiesWithFishtypes();
        int GetWaterbodyID(double latitude, double longitude);
        int GetWaterbodyID(string lakeName, string county, string state);
    }
}