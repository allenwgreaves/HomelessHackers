using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HomelessHackers.Data.Tests
{
    [TestClass]
    public class DataContextTest
    {
        [TestInitialize]
        public void init()
        {
            DatabaseInitialize.Execute();
        }

        [TestMethod]
        public void WhenGetOrganizationThenNonNullResult()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetOrganizations();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WhenGetOrganizationThenResultHasManyItems()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetOrganizations();
            Assert.AreNotEqual<int>(0, result.Count());
        }

        [TestMethod]
        public void WhenGetOrganizationFirstResultHasNameEqualToUGM()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetOrganizations();

            Assert.AreEqual<string>("UGM", result.First().Name);
        }

        [TestMethod]
        public void WhenGetOrganizationWithUGMThenResultNotNull()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetOrganizations("UGM");
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WhenGetOrganizationWithUGMThenResultHasSingleItem()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetOrganizations("UGM");
            Assert.AreEqual<int>(1, result.Count());
        }

        [TestMethod]
        public void WhenGetOrganizationWithUGMFirstResultHasNameEqualToUGM()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetOrganizations("UGM");

            Assert.AreEqual<string>("UGM", result.First().Name);
        }

        [TestMethod]
        public void WhenGetDonationsThenNotNull()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetDonations();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WhenGetDonationsThenResultHasMultipleItems()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetDonations();

            Assert.AreNotEqual<int>(0, result.Count()); 
        }

        [TestMethod]
        public void WhenGetDonationsThenFirstResultHasNameEqualToCannedBeans()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetDonations();

            Assert.AreEqual<string>("Canned Beans", result.First().Name);
        }

        [TestMethod]
        public void WhenGetDonationsWithCannedBeansThenResultNotNull()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetDonations("Canned Beans");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WhenGetDonationsWithCannedBeansThenResultHasSingleItem()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetDonations("Canned Beans");

            Assert.AreEqual<int>(1, result.Count());
        }

        [TestMethod]
        public void WhenGetDonationsWithCannedBeansThenFirstResultHasNameEqualToCannedBeans()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetDonations("Canned Beans");

            Assert.AreEqual<string>("Canned Beans", result.First().Name);
        }

        [TestMethod]
        public void WhenGetDonationsForOrganizationUGMThenNotNull()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetDonationsForOrganization("UGM");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WhenGetDonationsForOrganizationUGMThenResultHasManyItems()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetDonationsForOrganization("UGM");

            Assert.AreNotEqual<int>(0, result.Count());
        }

        [TestMethod]
        public void WhenGetDonationsForOrganizationUGMThenFirstResultHasNameEqualCannedBeans()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetDonationsForOrganization("UGM");

            Assert.AreEqual<string>("Canned Beans", result.First().Name);
        }

        [TestMethod]
        public void WhenGetVolunteersThenNotNull()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetVolunteers();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WhenGetVolunteersThenResultHasMultipleItems()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetVolunteers();

            Assert.AreNotEqual<int>(0, result.Count());
        }

        [TestMethod]
        public void WhenGetVolunteersThenFirstResultHasNameEqualToHairDresser()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetVolunteers();

            Assert.AreEqual<string>("Hair Dresser", result.First().Name);
        }

        [TestMethod]
        public void WhenGetVolunteersWithHairDresserThenResultNotNull()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetVolunteers("Hair Dresser");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WhenGetVolunteersWithHairDresserThenResultHasSingleItem()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetVolunteers("Hair Dresser");

            Assert.AreEqual<int>(1, result.Count());
        }

        [TestMethod]
        public void WhenGetDonationsWithHairDresserThenFirstResultHasNameEqualToHairDresser()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetVolunteers("Hair Dresser");

            Assert.AreEqual<string>("Hair Dresser", result.First().Name);
        }

        [TestMethod]
        public void WhenGetVolunteersForOrganizationUGMThenNotNull()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetVolunteersForOrganization("UGM");

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void WhenGetVolunteersForOrganizationUGMThenResultHasManyItems()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetVolunteersForOrganization("UGM");

            Assert.AreNotEqual<int>(0, result.Count());
        }

        [TestMethod]
        public void WhenGetVolunteersForOrganizationUGMThenFirstResultHasNameEqualHairDresser()
        {
            var dataContext = new DataContext();
            var result = dataContext.GetVolunteersForOrganization("UGM");

            Assert.AreEqual<string>("Hair Dresser", result.First().Name);
        }
    }
}
