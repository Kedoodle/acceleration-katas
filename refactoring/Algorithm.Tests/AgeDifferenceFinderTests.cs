using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Test
{    
    public class AgeDifferenceFinderTests
    {
        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Person>();
            var finder = new AgeDifferenceFinder(list);

            var result = finder.Find(AgeDifferenceType.Closest);

            Assert.Null(result.OlderPerson);
            Assert.Null(result.YoungerPerson);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Person>() { sue };
            var finder = new AgeDifferenceFinder(list);

            var result = finder.Find(AgeDifferenceType.Closest);

            Assert.Null(result.OlderPerson);
            Assert.Null(result.YoungerPerson);
        }

        [Fact]
        public void Returns_Closest_Two_For_Two_People()
        {
            var list = new List<Person>() { sue, greg };
            var finder = new AgeDifferenceFinder(list);

            var result = finder.Find(AgeDifferenceType.Closest);

            Assert.Same(sue, result.OlderPerson);
            Assert.Same(greg, result.YoungerPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Two_People()
        {
            var list = new List<Person>() { greg, mike };
            var finder = new AgeDifferenceFinder(list);

            var result = finder.Find(AgeDifferenceType.Furthest);

            Assert.Same(greg, result.OlderPerson);
            Assert.Same(mike, result.YoungerPerson);
        }

        [Fact]
        public void Returns_Furthest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new AgeDifferenceFinder(list);

            var result = finder.Find(AgeDifferenceType.Furthest);

            Assert.Same(sue, result.OlderPerson);
            Assert.Same(sarah, result.YoungerPerson);
        }

        [Fact]
        public void Returns_Closest_Two_For_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finder = new AgeDifferenceFinder(list);

            var result = finder.Find(AgeDifferenceType.Closest);

            Assert.Same(sue, result.OlderPerson);
            Assert.Same(greg, result.YoungerPerson);
        }

        Person sue = new Person() {Name = "Sue", BirthDate = new DateTime(1950, 1, 1)};
        Person greg = new Person() {Name = "Greg", BirthDate = new DateTime(1952, 6, 1)};
        Person sarah = new Person() { Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };
        Person mike = new Person() { Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
    }
}