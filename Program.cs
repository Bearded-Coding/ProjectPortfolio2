using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace LupiRoland_FiveStarRating
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database Location
            //string cs = @"server= 127.0.0.1;userid=root;password=root;database=SampleRestaurantDatabase;port=8889";
            //Output Location
            //string _directory = @"../../output/";﻿﻿


            
            bool running = true; //holder for loop
            while (running)
            {
                Console.Write( //menu set up
                    "\n\t\t\t\t\tHello User, How Would You Like To Sort The Data?" +
                    "\n\n\n" +
                    "\t\t\t\t[1] List Restaurants Alphabetically (Show Rating Next To Name)" +
                    "\n\n" +
                    "\t\t\t\t[2] List Restaurants in Reverse Alphabetical (Show Rating Next To Name)" +
                    "\n\n" +
                    "\t\t\t\t[3] Sort Restaurants From Best to Worst (Show Rating Next To Name)" +
                    "\n\n" +
                    "\t\t\t\t[4] Sort Restaurants From Worst to Best (Show Rating Next To Name)" +
                    "\n\n" +
                    "\t\t\t\t[5] Show Only X and Up" +
                    "\n\n" +
                    "\t\t\t\t[6] Exit" +
                    "\n\n\n" +
                    "\t\t\t\tChoice: "
                    );
                int userInput = Validation.GetInt(1, 6); //restrict range of choices

                switch (userInput) //cycle through choices
                {
                    case 1:
                        {
                            ConnectToSQL("SELECT RestaurantName, OverallRating FROM RestaurantProfiles ORDER BY RestaurantName ASC;"); //query
                        }
                        break;
                    case 2:
                        {
                            ConnectToSQL("SELECT RestaurantName, OverallRating FROM RestaurantProfiles ORDER BY RestaurantName DESC;"); //query
                        }
                        break;
                    case 3:
                        {
                            ConnectToSQL("SELECT RestaurantName, OverallRating FROM RestaurantProfiles ORDER BY OverallRating DESC;"); //query
                        }
                        break;
                    case 4:
                        {
                            ConnectToSQL("SELECT RestaurantName, OverallRating FROM RestaurantProfiles ORDER BY OverallRating ASC;"); //query
                        }
                        break;
                    case 5:
                        {
                            Console.Write( //sub menu
                            "\n\t\t\t\t\tHello User, How Would You Like To Sort The Data?" +
                            "\n\n\n" +
                            "\t\t\t\t[1] Show The Best" +
                            "\n\n" +
                            "\t\t\t\t[2] Show 4 Stars And Up" +
                            "\n\n" +
                            "\t\t\t\t[3] Show 3 Stars And Up" +
                            "\n\n" +
                            "\t\t\t\t[4] Show The Worst" +
                            "\n\n" +
                            "\t\t\t\t[5] Show Unrated" +
                            "\n\n" +
                            "\t\t\t\t[6] Back" +
                            "\n\n\n" +
                            "\t\t\t\tChoice: "
                            );

                            int userChoice = Validation.GetInt(1, 6); //validation with range limit

                            switch (userChoice) //switch case for user input
                            {
                                case 1:
                                    {
                                        ConnectToSQL("SELECT RestaurantName, OverallRating FROM RestaurantProfiles WHERE OverallRating >= '4.50';");
                                    }
                                    break;
                                case 2:
                                    {
                                        ConnectToSQL("SELECT RestaurantName, OverallRating FROM RestaurantProfiles WHERE OverallRating >= '3.50';");

                                    }
                                    break;
                                case 3:
                                    {
                                        ConnectToSQL("SELECT RestaurantName, OverallRating FROM RestaurantProfiles WHERE OverallRating >= '2.50';");

                                    }
                                    break;
                                case 4:
                                    {
                                        ConnectToSQL("SELECT RestaurantName, OverallRating FROM RestaurantProfiles WHERE OverallRating >= '.50';");

                                    }
                                    break;
                                case 5:
                                    {
                                        ConnectToSQL("SELECT RestaurantName, OverallRating FROM RestaurantProfiles WHERE OverallRating <= '0.49' OR OverallRating IS NULL;");

                                    }
                                    break;
                                default:
                                    {
                                        
                                    }
                                    break;
                                    
                            }
                        }
                        break;
                    case 6:
                        {
                            running = false;
                        }
                        break;
                }
                Console.Clear();
            }
        }

        public static void ConnectToSQL(string query)
        {
            // MySQL Database Connection String
            string cs = @"server=10.0.0.126;userid=root;password=root;database=SampleRestaurant;port=8889";

            // Declare a MySQL Connection
            MySqlConnection conn = null;

            try
            {

                // Open a connection to MySQL 
                conn = new MySqlConnection(cs);
                conn.Open();

                // Form SQL Statement
                string stm = query;


                // Prepare SQL Statement
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                // Execute SQL Statement and Convert Results to a String
                string response = Convert.ToString(cmd);

                // Output Results
                MySqlDataReader reader = cmd.ExecuteReader();

                List<StarRating> ratings = new List<StarRating> { }; //create list of starRating objects to store data

                int overallRating = 0;
                string starCharacter = " ";

                while (reader.Read()) //while the reader is reading ... do this
                {
                    if (reader["OverallRating"].ToString() == "") //if any ratings are null convert them to ints of 0
                    {
                        overallRating = 0;
                    }
                    else
                    {
                        overallRating = Convert.ToInt32(Convert.ToDecimal(reader["OverallRating"].ToString())); //convert the string object, to string, to decimal then to int 

                    }

                    if (overallRating == 0) { starCharacter = "Not Rated"; }
                    if (overallRating == 1) { starCharacter = "*"; }
                    if (overallRating == 2) { starCharacter = "**"; }
                    if (overallRating == 3) { starCharacter = "***"; }
                    if (overallRating == 4) { starCharacter = "****"; }
                    if (overallRating == 5) { starCharacter = "*****"; }


                    if (overallRating <= 2)
                    {
                        
                        Console.Write($"Restaurant: {reader["RestaurantName"].ToString().PadRight(50)}"); //reader only reads what the query tells it to read since layout is similar on all queries one writeline will suffice
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"OverallRating: {starCharacter}\n"); //reader only reads what the query tells it to read since layout is similar on all queries one writeline will suffice
                        Console.ForegroundColor = ConsoleColor.White;

                    }
                    if (overallRating == 3)
                    {
                        Console.Write($"Restaurant: {reader["RestaurantName"].ToString().PadRight(50)}"); //reader only reads what the query tells it to read since layout is similar on all queries one writeline will suffice
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($"OverallRating: {starCharacter}\n"); //reader only reads what the query tells it to read since layout is similar on all queries one writeline will suffice
                        Console.ForegroundColor = ConsoleColor.White;


                    }
                    if (overallRating >= 4)
                    {
                        Console.Write($"Restaurant: {reader["RestaurantName"].ToString().PadRight(50)}"); //reader only reads what the query tells it to read since layout is similar on all queries one writeline will suffice
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($"OverallRating: {starCharacter}\n"); //reader only reads what the query tells it to read since layout is similar on all queries one writeline will suffice
                        Console.ForegroundColor = ConsoleColor.White;


                    }




                }
                Console.Write("\n\n\nPress Enter To Go Back: ");
                Console.ReadLine();
                
            }
            catch (MySqlException ex) //if error occurs, print error
            {
                Console.WriteLine("Error: {0}", ex.ToString());
                Console.ReadLine();
            }
            finally //close connection after action is complete
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }
    }

  
}
