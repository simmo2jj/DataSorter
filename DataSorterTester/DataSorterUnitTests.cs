using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using DataSorter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataSorterTester
{
    [TestClass]
    public class DataSorterUnitTests
    {

        [TestMethod]
        public void SpaceDelimitedPeoplePopulated()
        {
            string file = "InputFiles\\Space.txt";

            List<Person> people = new List<Person>();
            Program.AddPeople(' ', file, ref people);

            Assert.IsTrue(people.Count > 0);
        }

        [TestMethod]
        public void CommaDelimitedPeoplePopulated()
        {
            string file = "InputFiles\\Comma.txt";

            List<Person> people = new List<Person>();
            Program.AddPeople(',', file, ref people);

            Assert.IsTrue(people.Count > 0);
        }

        [TestMethod]
        public void PipeDelimitedPeoplePopulated()
        {
            string file = "InputFiles\\Pipe.txt";

            List<Person> people = new List<Person>();
            Program.AddPeople('|', file, ref people);

            Assert.IsTrue(people.Count > 0);
        }


        [TestMethod]
        public void TestGenderSort()
        {
            List<Person> lPeople = new List<Person>();

            lPeople.Add(new Person("Price", "Phillip", "Male", "Green", "01/01/2000"));
            lPeople.Add(new Person("Alderson", "Darlene", "Female", "Brown", "12/25/2004"));
            lPeople.Add(new Person("Alderson", "Elliot", "Male", "Black", "10/31/1999"));


            List<Person> lSortedPeople = Program.sortByGender(lPeople);

            lPeople = lPeople.OrderBy(p => p.PersonGender).ThenBy(x => x.LastName).ToList();


            Assert.IsTrue(lPeople.SequenceEqual(lSortedPeople));

        }
        [TestMethod]
        public void TestBirthDateSort()
        {
            List<Person> lPeople = new List<Person>();

            lPeople.Add(new Person("Price", "Phillip", "Male", "Green", "01/01/2000"));
            lPeople.Add(new Person("Alderson", "Darlene", "Female", "Brown", "12/25/2004"));
            lPeople.Add(new Person("Alderson", "Elliot", "Male", "Black", "10/31/1999"));


            List<Person> lSortedPeople = Program.sortByBirthDate(lPeople);

            lPeople = lPeople.OrderBy(p => p.DateOfBirth).ToList();


            Assert.IsTrue(lPeople.SequenceEqual(lSortedPeople));
        }
        [TestMethod]
        public void TestNameSort()
        {
            List<Person> lPeople = new List<Person>();

            lPeople.Add(new Person("Price", "Phillip", "Male", "Green", "01/01/2000"));
            lPeople.Add(new Person("Alderson", "Darlene", "Female", "Brown", "12/25/2004"));
            lPeople.Add(new Person("Alderson", "Elliot", "Male", "Black", "10/31/1999"));


            List<Person> lSortedPeople = Program.sortByName(lPeople);

            lPeople = lPeople.OrderByDescending(p => p.LastName).ThenBy(x => x.FirstName).ToList();


            Assert.IsTrue(lPeople.SequenceEqual(lSortedPeople));
        }
    }
}
