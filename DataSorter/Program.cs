using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSorter
{
    public class Program
    {

        static void Main(string[] args)
        {

            string filePipe = "InputFiles\\Pipe.txt";
            string fileComma = "InputFiles\\Comma.txt";
            string fileSpace = "InputFiles\\Space.txt";

            DataSorter(filePipe, fileComma, fileSpace);

            Console.Read();

        }

        public static void DataSorter(string pFilePipe, string pFileComma, string pFileSpace)
        {
            List<Person> lPeople = new List<Person>();

            AddPeople('|', pFilePipe, ref lPeople);
            AddPeople(',', pFileComma, ref lPeople);
            AddPeople(' ', pFileSpace, ref lPeople);

            if (lPeople.Count > 0)
            {
                outputByGender(lPeople);
                outputByBirthDate(lPeople);
                outputByLastName(lPeople);
            }
        }

        public static void AddPeople(char pDelimeter, string pFilePath, ref List<Person> pPeople)
        {

            //try
            //{
                var data = File.ReadLines(pFilePath);

                Person lPerson = new Person();

                foreach (var row in data)
                {
                    var rowArray = row.Split(pDelimeter);
                    pPeople.Add(new Person(rowArray[0], rowArray[1], rowArray[2], rowArray[3], rowArray[4]));
                }
            //
            //catch (IndexOutOfRangeException e)
            //catch (IndexOutOfRangeException e)
            //{
            //    Console.WriteLine("Incomplete data row exists in " + pFilePath);
            //}
            //catch(FormatException e)
            //{
            //    Console.WriteLine("Data row with incorrect format exists in " + pFilePath);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Error reading and parsing file: " + e.Message);
            //}


        }

        public static void outputByGender(List<Person> pPeople)
        {
            pPeople = pPeople.OrderBy(p => p.PersonGender).ThenBy(x => x.LastName).ToList();

            Console.WriteLine("Sorted by Gender");
            foreach (Person person in pPeople)
            {
                Console.WriteLine(person.PersonGender.ToString() + " " + person.LastName + " " + person.FirstName + " " + person.FavoriteColor + " " + person.DateOfBirth.ToString("MM/dd/yyyy"));
            }
        }

        public static void outputByBirthDate(List<Person> pPeople)
        {
            pPeople = pPeople.OrderBy(p => p.DateOfBirth).ToList();

            Console.WriteLine("");
            Console.WriteLine("Sorted by Birth Date");
            foreach (Person person in pPeople)
            {
                Console.WriteLine(person.DateOfBirth.ToString("MM/dd/yyyy") + " " + person.LastName + " " + person.FirstName + " " + person.PersonGender.ToString() + " " + person.FavoriteColor);
            }
        }

        public static void outputByLastName(List<Person> pPeople)
        {
            pPeople = pPeople.OrderByDescending(p => p.LastName).ThenBy(x => x.FirstName).ToList();

            Console.WriteLine("");
            Console.WriteLine("Sorted by Name");
            foreach (Person person in pPeople)
            {
                Console.WriteLine(person.LastName + " " + person.FirstName + " " + person.PersonGender.ToString() + " " +  person.FavoriteColor + " " + person.DateOfBirth.ToString("MM/dd/yyyy"));
            }
        }

    }


}
