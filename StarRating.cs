using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LupiRoland_FiveStarRating
{
    class StarRating
    {
        //properties for each column in database table we need to access
        string Id
        {
            get; set;
        }
        string RestaurantId
        {
            get; set;
        }
        string ReviewScore
        {
            get; set;
        }
        string PossibleReviewScore
        {
            get; set;
        }
        string ReviewText
        {
            get; set;
        }
        string ReviewColor
        {
            get; set;
        }

        //constructor
        public StarRating(string _id, string _restaurantId, string _reviewScore, string _possibleReviewScore, string _reviewText, string _reviewColor)
        {
            Id = _id;
            RestaurantId = _restaurantId;
            ReviewScore = _reviewScore;
            PossibleReviewScore = _possibleReviewScore;
            ReviewText = _reviewText;
            ReviewColor = _reviewColor;
        }
    }
}
