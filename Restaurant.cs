using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RolandLupi_ConvertedData
{
   public class Restaurant
    {
        //properties for each column in my database
        public string Id
        {
            get; set;
        }
        public string Name
        {
            get; set;
        }
        public string Address
        {
            get; set;
        }
        public string Phone
        {
            get; set;
        }
        public string Hours
        {
            get; set;
        }
        public string Price
        {
            get; set;
        }
        public string City
        {
            get; set;
        }
        public string FoodType
        {
            get; set;
        }
        public string FoodRating
        {
            get; set;
        }
        public string ServiceRating
        {
            get; set;
        }
        public string AmbianceRating
        {
            get; set;
        }
        public string ValueRating
        {
            get; set;
        }
        public string OverallRating
        {
            get; set;
        }
        public string BestPossibleRating
        {
            get; set;
        }

        //constructor
        public Restaurant(string id, string name, string address, string phone, string hours, string price, string city, string foodType, string foodRating, string serviceRating, string ambianceRating, string valueRating, string overallRating, string bestRating )
        {
            Id = id;
            Name = name;
            Address = address;
            Phone = phone;
            Hours = hours;
            Price = price;
            City = city;
            FoodType = foodType;
            FoodRating = foodRating;
            ServiceRating = serviceRating;
            AmbianceRating = ambianceRating;
            ValueRating = valueRating;
            OverallRating = overallRating;
            BestPossibleRating = bestRating;
        }

        public override string ToString() //override tostring method to make each piece of data from database that i stored within a restaurant object out as a string
        {
            const string quote = "\"";
            return
                "{" + "\n" + quote + "Id" + quote + ":" + quote + Id + quote + "," + "\n" +
                 quote + "RestaurantName" + quote + ":" + quote + Name + quote + "," + "\n" +
                 quote + "Address" + quote + ":" + quote + Address + quote + "," + "\n" +
                 quote + "Phone" + quote + ":" + quote + Phone + quote + "," + "\n" +
                 quote + "HoursOfOperation" + quote + ":" + quote + Hours + quote + "," + "\n" +
                 quote + "Price" + quote + ":" + quote + Price + quote + "," + "\n" +
                 quote + "USACityLocation" + quote + ":" + quote + City + quote + "," + "\n" +
                 quote + "Cuisine" + quote + ":" + quote + FoodType + quote + "," + "\n" +
                 quote + "FoodRating" + quote + ":" + quote + FoodRating + quote + "," + "\n" +
                 quote + "ServiceRating" + quote + ":" + quote + ServiceRating + quote + "," + "\n" +
                 quote + "AmbienceRating" + quote + ":" + quote + AmbianceRating + quote + "," + "\n" +
                 quote + "ValueRating" + quote + ":" + quote + ValueRating + quote + "," + "\n" +
                 quote + "OverallRating" + quote + ":" + quote + OverallRating + quote + "," + "\n" +
                 quote + "OverallPossibleRating" + quote + ":" + quote + BestPossibleRating + quote + "\n" + "}";

        }

    }
}
