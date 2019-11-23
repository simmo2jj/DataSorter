using System;
using System.IO;
using System.Collections.Generic;
using DataSorter;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataSorterTester
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSuccessfulOutput()
        {
            string filePipe = "InputFiles\\Pipe.txt";
            string fileComma = "InputFiles\\Comma.txt";
            string fileSpace = "InputFiles\\Space.txt";

            Program.DataSorter(filePipe, fileComma, fileSpace);
        }

        [TestMethod]
        public void PeoplePopulated()
        {
            string file = "InputFiles\\Pipe.txt";

            List<Person> people = new List<Person>();
            Program.AddPeople('|', file, ref people);

            Assert.AreEqual(people.Count, 3);
        }

        [TestMethod]
        public void TestFilePathNotFound()
        {
            string file = "InputFiles\\FileDoesNotExist.txt";

            List<Person> people = new List<Person>();
            Assert.ThrowsException<FileNotFoundException>( () => Program.AddPeople('|', file, ref people)) ;
        }

        [TestMethod]
        public void TestIncorrectFormat()
        {
            string file = "InputFiles\\IncorrectFormat.txt";

            List<Person> people = new List<Person>();
            Assert.ThrowsException<FormatException>(() => Program.AddPeople(',', file, ref people));
        }

        [TestMethod]
        public void TestIncompleteDataRow()
        {
            string file = "InputFiles\\IncompleteDataRow.txt";

            List<Person> people = new List<Person>();
            Assert.ThrowsException<IndexOutOfRangeException>(() => Program.AddPeople('|', file, ref people));
        }

        [TestMethod]
        public void TestGenderSort()
        {
          
        }
        [TestMethod]
        public void TestBirthDateSort()
        {

        }
        [TestMethod]
        public void TestNameSort()
        {

        }
    }
}
