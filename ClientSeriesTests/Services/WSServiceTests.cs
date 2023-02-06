using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClientSeries.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientSeries.Models;

namespace ClientSeries.Services.Tests
{
    [TestClass()]
    public class WSServiceTests
    {
        [TestMethod()]
        public void WSServiceTest()
        {
            WSService service = new WSService("https://apiseriesevlacy.azurewebsites.net");
            Assert.IsNotNull(service);
        }

        [TestMethod()]
        public void GetSeriesAsyncTest()
        {
            // arrange
            WSService service = new WSService("https://apiseriesevlacy.azurewebsites.net");
            Serie one = new Serie(
                    1,
                    "Scrubs",
                    "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !",
                    9,
                    184,
                    2001,
                    "ABC (US)");

            //act
            var result = service.GetSeriesAsync().Result;

            //assert
            Assert.IsNotNull(result, "Non nul attendu");
            var serie = result[0];
            Assert.AreEqual(one, serie, "Type Serie attendu");
        }

        [TestMethod()]
        public void GetSerieAsync()
        {
            WSService service = new WSService("https://apiseriesevlacy.azurewebsites.net");
            var result = service.GetSerieAsync(1).Result;

            Assert.IsNotNull(result, "Non nul attendu");
            Assert.IsInstanceOfType(result, typeof(Serie), "Type Serie attendu");

            Serie one = new Serie(
                    1,
                    "Scrubs",
                    "J.D. est un jeune médecin qui débute sa carrière dans l'hôpital du Sacré-Coeur. Il vit avec son meilleur ami Turk, qui lui est chirurgien dans le même hôpital. Très vite, Turk tombe amoureux d'une infirmière Carla. Elliot entre dans la bande. C'est une étudiante en médecine quelque peu surprenante. Le service de médecine est dirigé par l'excentrique Docteur Cox alors que l'hôpital est géré par le diabolique Docteur Kelso. A cela viennent s'ajouter plein de personnages hors du commun : Todd le chirurgien obsédé, Ted l'avocat dépressif, le concierge qui trouve toujours un moyen d'embêter JD... Une belle galerie de personnage !",
                    9,
                    184,
                    2001,
                    "ABC (US)");

            Assert.AreEqual(one, result, "Identique attendu");
        }

        [TestMethod()]
        public void DeleteSerieAsync()
        {

        }

        [TestMethod()]
        public void PostSerieAsyncTest()
        {

        }

        [TestMethod()]
        public void PutSerieAsyncTest()
        {

        }
    }
}