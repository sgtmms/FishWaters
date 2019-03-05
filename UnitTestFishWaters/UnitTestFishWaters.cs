using Microsoft.VisualStudio.TestTools.UnitTesting;
using FishWaters.Controllers;
using FishWaters.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UnitTestFishWaters
{
    [TestClass]
    public class FishWaterControllerTest
    {

        private IFishWatersRepository _repository;


     

        public FishWaterControllerTest()
        {
            _repository = new FishContext();
        }
       
        [TestMethod]
        public void FishWaterControllerIndexType()
        {
            // Arrange
           
            FishWaterController fishWaterController = new FishWaterController(_repository);

            // Act
            IActionResult result = fishWaterController.Index();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }



        [TestMethod]
        public void FishWaterControllerWaterbodies()
        {
            // Arrange

            FishWaterController fishWaterController = new FishWaterController(_repository);

            // Act
            IActionResult result = fishWaterController.Waterbodies();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));

          



        }

        [TestMethod]
        public void FishWaterControllerFishtypes()
        {
            // Arrange

            FishWaterController fishWaterController = new FishWaterController(_repository);

            // Act
            IActionResult result = fishWaterController.Fishtypes();

            // Assert
            Assert.IsInstanceOfType(result, typeof(ViewResult));





        }
    }
}
