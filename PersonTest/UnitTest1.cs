using Microsoft.VisualStudio.TestTools.UnitTesting;
using Slektstre;
using System;

namespace PersonTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAllFields() //Tester returverdi når alle feltene er fyllt ut, Person Class
        {
            var p = new Person
            {
                Id = 17,
                FirstName = "Ola",
                LastName = "Nordmann",
                BirthYear = 2000,
                DeathYear = 3000,
                Father = new Person() { Id = 23, FirstName = "Per" },
                Mother = new Person() { Id = 29, FirstName = "Lise" },
            };
            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=17) Født: 2000 Død: 3000 Far: Per (Id=23) Mor: Lise (Id=29)";

            Assert.AreEqual(expectedDescription, actualDescription);
            //Assert.AreNotEqual();
        }
        [TestMethod]
        public void TestNoFields() //Tester når ingen felter er fyllt ut, Person Class
        {
            var e = new Person
            {
                Id = 1,
            };
            var actualDescription = e.GetDescription();
            var expectedDescription = "(Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
        [TestMethod]
        public void TestSomeFields() //Tester når bare noen felter er fyllt ut, Person Class
        {
            var p = new Person
            {
                Id = 1,
                FirstName = "Ola",
                LastName = "Nordmann",
            };

            var actualDescription = p.GetDescription();
            var expectedDescription = "Ola Nordmann (Id=1)";

            Assert.AreEqual(expectedDescription, actualDescription);
        }
    }
}
