using System;
using HomelessHackers.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HomelessHackers.Web.Tests.Controllers
{
    [TestClass]
    public class VolunteerTests
    {
        [TestMethod]
        public void Get()
        {
            VolunteersController controller = new VolunteersController();
            var volunteers = controller.Get();
            Assert.IsNotNull(volunteers);
        }
    }
}
