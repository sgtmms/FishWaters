using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishWaters.Data;
using FishWaters.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FishWaters.Controllers
{
    public class FishWaterController : Controller
    {
        private readonly IFishWatersRepository _repository;

       


        
        public FishWaterController(IFishWatersRepository repository)
        {
            _repository = repository;
        }




        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Fishtypes()
        {
            List<Fishtype> fishtypes = _repository.GetFishtypes();

            return View(fishtypes);

        }

        public IActionResult Waterbodies()
        {
            List<Waterbody> waterbodies = _repository.GetWaterbodies();

            return View(waterbodies);

        }

        public IActionResult WaterbodiesWithFishtypes()
        {
            List<Waterbody> waterbodiesWithFishtypes = _repository.GetWaterbodiesWithFishtypes();

            return View(waterbodiesWithFishtypes);

        }


        [HttpPost]
        public IActionResult CreateFishtype(Fishtype fishtype)
        {
            if (ModelState.IsValid == true)
            {
                _repository.AddFishtype(fishtype);

                return RedirectToAction("Fishtypes");
            }
            return View(fishtype);
        }

        [HttpGet]
        public IActionResult CreateFishtype()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateWaterbody(Waterbody waterbody)
        {
            if (ModelState.IsValid == true)
            {
                _repository.AddWaterbody(waterbody);

                return RedirectToAction("Waterbodies");
            }
            return View(waterbody);
        }

        [HttpGet]
        public IActionResult CreateWaterbody()
        {

            ViewBag.AvailableLakes = _repository.GetWaterbodies();
            ViewBag.AvailableFishes = _repository.GetFishtypes();

            return View();
        }

        [HttpPost]
        public IActionResult CreateFishWater(int waterbodyID, int fishtypeID)
        {
            if (ModelState.IsValid == true)
            {
                FishWater fishWater = new FishWater();
                fishWater.FishtypeID = fishtypeID;
                fishWater.WaterbodyID = waterbodyID;

                _repository.AddFishWater(fishWater);

                //Waterbody waterbody = fishWater.Waterbody;

                return RedirectToAction("Waterbodies");
            }
            return View(waterbodyID);
        }

        [HttpGet]
        public IActionResult CreateFishWater()
        {

            return View();
        }






    }
}
