using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataSorter
{
    public class Person
    {
        public Person()
        {

        }
        public Person(string pLastName, string pFirstName, string pGender, string pFavoriteColor, string pDateOfBirth)
        {
            LastName = pLastName;
            FirstName = pFirstName;
            FavoriteColor = pFavoriteColor;
            DateOfBirth = Convert.ToDateTime(pDateOfBirth);


            switch (pGender)
            {
                case "Male": PersonGender = Gender.Male; break;
                case "Female": PersonGender = Gender.Female; break;
                default: PersonGender = Gender.Unknown; break;
            }

        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Gender PersonGender { get; set; }
        public string FavoriteColor { get; set; }
        public DateTime DateOfBirth { get; set; } 


    }
    public enum Gender
    {
        Female,
        Male,
        Unknown
    }

}
