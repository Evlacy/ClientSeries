using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientSeries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSeries.Services;
using ClientSeries.Models;

namespace ClientSeries.ViewModels.Tests
{
    [TestClass()]
    public class AddSerieViewModelTests
    {
        [TestMethod()]
        public void AddSerieViewModelTest()
        {
            AddSerieViewModel addSerieViewModel = new AddSerieViewModel();
            Assert.IsNotNull(addSerieViewModel);
        }

        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            //Arrange
            AddSerieViewModel addSerieViewModel = new AddSerieViewModel();
            //Act
            addSerieViewModel.GetDataOnLoadAsync();
            Thread.Sleep(1000);
            //Assert
            Assert.IsNotNull(addSerieViewModel.Series);
        }

        /// <summary>
        /// Test conversion OK
        /// </summary>
        [TestMethod()]
        public void ActionPostSerieTests()
        {
            // Arrange
            // Création d'un objet de type ConvertisseurEuroViewModel
            AddSerieViewModel addSerieViewModel = new AddSerieViewModel();
            WSService service = new WSService("https://apiseriesevlacy.azurewebsites.net");
            /*
            // 
            addSerieViewModel.MontantDevise = 100;

            // 
            Serie serie = new Serie();

            // 
            addSerieViewModel.DeviseSelected = serie;

            // Act
            // Appel de la méthode ActionPostSerie
            addSerieViewModel.ActionPostSerie();

            // Assert
            // Assertion : 
            Assert.AreEqual(addSerieViewModel.MontantEuros, 200, "Doit etre egale à 150");*/
        }
    }
}