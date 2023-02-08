using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientSeries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientSeries.ViewModels.Tests
{
    [TestClass()]
    public class UpdateSerieViewModelTests
    {
        [TestMethod()]
        public void UpdateSerieViewModelTest()
        {
            UpdateSerieViewModel updateSerieViewModel = new UpdateSerieViewModel();
            Assert.IsNotNull(updateSerieViewModel);
        }

        [TestMethod()]
        public void GetDataOnLoadAsyncTest_OK()
        {
            //Arrange
            UpdateSerieViewModel updateSerieViewModel = new UpdateSerieViewModel();
            //Act
            updateSerieViewModel.GetDataOnLoadAsync();
            Thread.Sleep(1000);
            //Assert
            Assert.IsNotNull(updateSerieViewModel.Series);
        }
    }
}