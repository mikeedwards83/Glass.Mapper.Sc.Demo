using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Glass.Mapper.Sc.Demo.Controllers;
using Glass.Mapper.Sc.Demo.Core.Models.sitecore.templates.Sugnl.Concrete;
using NSubstitute;
using NUnit.Framework;

namespace Glass.Mapper.Sc.Demo.Tests.Controllers
{
    [TestFixture]
    public class RateBaconControllerFixture
    {

        [Test]
        public void Rate_RatedImage1FirstRating_SetsRating()
        {
            //Arrange
            var context = Substitute.For<ISitecoreContext>();
            var service = Substitute.For<ISitecoreService>();
            var controller = new RateBaconController(context, service);
            var itemId = Guid.NewGuid();
            var ratingNumber = 1;
            var rating = 4;
            var item = new RateBacon();

            context.GetItem<RateBacon>(itemId).Returns(item);
            service.Save(item);
            //Act
            var result = controller.Rate(itemId, ratingNumber, rating);

            //Assert
            Assert.AreEqual(rating, item.RateBaconRate1);
            Assert.AreEqual(1, item.RateBaconCount1);
        }
    }
}
