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
            Console.Write("Enter filepath of pipe-delimited list: ");
            string filePipe = Console.ReadLine();

            Console.Write("Enter filepath of comma-delimited list: ");
            string fileComma = Console.ReadLine();

            Console.Write("Enter filepath of space-delimited list: ");
            string fileSpace = Console.ReadLine();


            Console.WriteLine("");
            SortAndOutput(BuildPersonList(filePipe, fileComma, fileSpace));

            Console.Read();

        }

        public static List<Person> BuildPersonList(string pFilePipe, string pFileComma, string pFileSpace)
        {
            List<Person> lPeople = new List<Person>();

            AddPeople('|', pFilePipe, ref lPeople);
            AddPeople(',', pFileComma, ref lPeople);
            AddPeople(' ', pFileSpace, ref lPeople);

            return lPeople;
        }

        public static void SortAndOutput(List<Person> pPeople)
        {
            if (pPeople.Count > 0)
            {
                sortByGender(pPeople);
                sortByBirthDate(pPeople);
                sortByName(pPeople);
            }
        }

        public static void AddPeople(char pDelimeter, string pFilePath, ref List<Person> pPeople)
        {
            try
            {
                var data = File.ReadLines(pFilePath);

                foreach (var row in data)
                {
                    var rowArray = row.Split(pDelimeter);
                    pPeople.Add(new Person(rowArray[0], rowArray[1], rowArray[2], rowArray[3], rowArray[4]));
                }
            }
            catch (Exception e) { Console.WriteLine("Error reading and parsing file: " + e.Message); }
           
        }

        public static List<Person> sortByGender(List<Person> pPeople)
        {
            pPeople = pPeople.OrderBy(p => p.PersonGender).ThenBy(x => x.LastName).ToList();

            Console.WriteLine("Sorted by Gender");
            foreach (Person person in pPeople)
            {
                Console.WriteLine(person.PersonGender.ToString() + " " + person.LastName + " " + person.FirstName + " " + person.FavoriteColor + " " + person.DateOfBirth.ToString("MM/dd/yyyy"));
            }

            return pPeople;
        }

        public static List<Person> sortByBirthDate(List<Person> pPeople)
        {
            pPeople = pPeople.OrderBy(p => p.DateOfBirth).ToList();

            Console.WriteLine("");
            Console.WriteLine("Sorted by Birth Date");
            foreach (Person person in pPeople)
            {
                Console.WriteLine(person.DateOfBirth.ToString("MM/dd/yyyy") + " " + person.LastName + " " + person.FirstName + " " + person.PersonGender.ToString() + " " + person.FavoriteColor);
            }

            return pPeople;
        }

        public static List<Person> sortByName(List<Person> pPeople)
        {
            pPeople = pPeople.OrderByDescending(p => p.LastName).ThenByDescending(x => x.FirstName).ToList();

            Console.WriteLine("");
            Console.WriteLine("Sorted by Name");
            foreach (Person person in pPeople)
            {
                Console.WriteLine(person.LastName + " " + person.FirstName + " " + person.PersonGender.ToString() + " " +  person.FavoriteColor + " " + person.DateOfBirth.ToString("MM/dd/yyyy"));
            }

            return pPeople;
        }

    }


}
