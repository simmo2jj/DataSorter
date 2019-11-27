using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Web;

namespace DataSorterAPI.Models
{
    [Serializable]
    public class PersonViewModel
    {
        public PersonViewModel()
        {

        }
        public PersonViewModel(string pLastName, string pFirstName, string pGender, string pFavoriteColor, DateTime pDateOfBirth)
        {
            LastName = pLastName;
            FirstName = pFirstName;
            FavoriteColor = pFavoriteColor;
            PersonGender = pGender;
            DateOfBirth = pDateOfBirth;


        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PersonGender { get; set; }
        public string FavoriteColor { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}")]
        [JsonConverter(typeof(DateTimeFormatter), "MM/dd/yyyy")]
        public DateTime DateOfBirth { get; set; }


    }

    public class DateTimeFormatter : IsoDateTimeConverter
    {
        public DateTimeFormatter(string format)
        {
            DateTimeFormat = format;
        }

    }
}