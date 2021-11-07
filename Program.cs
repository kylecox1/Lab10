using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Movie> movieList = new List<Movie>();
            movieList.Add(new Movie(title: "Spirited Away", category: (int)Category.animated));
            movieList.Add(new Movie(title: "Redline", category: (int)Category.animated));
            movieList.Add(new Movie(title: "Akira", category: (int)Category.animated));
            movieList.Add(new Movie(title: "Hereditary", category: (int)Category.horror));
            movieList.Add(new Movie(title: "It Follows", category: (int)Category.horror));
            movieList.Add(new Movie(title: "There Will Be Blood", category: (int)Category.drama));
            movieList.Add(new Movie(title: "No Country for Old Men", category: (int)Category.drama));
            movieList.Add(new Movie(title: "Bladerunner 2049", category: (int)Category.scifi));
            movieList.Add(new Movie(title: "Interstellar", category: (int)Category.scifi));
            movieList.Add(new Movie(title: "Ex Machina", category: (int)Category.scifi));

            bool playAgain = true;
            do
            {
                Console.WriteLine("Welcome to the Movie List Application!");
                Console.WriteLine("");
                Console.WriteLine("There are 10 movies in this list.");
                Console.WriteLine("What category are you interested in?");
                Console.WriteLine("");
                Console.WriteLine("1: Animated");
                Console.WriteLine("2: Drama");
                Console.WriteLine("3: Horror");
                Console.WriteLine("4: Sci-Fi");
                Console.WriteLine("");
                
                bool isValidChoice = false;
                int categoryChoice = -1;
                while (isValidChoice == false)
                {
                    Console.Write("Please enter the number of the category: ");
                    string input = Console.ReadLine();
                    if (input == null)
                    {
                        Console.WriteLine("Please enter something.");
                    }
                    else if (input == "")
                    {
                        Console.WriteLine("Please enter something.");
                    }
                    else if (!int.TryParse(input, out categoryChoice))
                    {
                        Console.WriteLine($"Sorry, no decimals or non-number characters please.");
                    }
                    else if (categoryChoice < 1 || categoryChoice > 4)
                    {
                        Console.WriteLine($"Sorry, that number was out of range.");
                    }
                    else
                    {
                        isValidChoice = true;
                    }
                }

                Console.WriteLine($"Your choice was { (Category) categoryChoice }. Movies in this category are:");
                Console.WriteLine("");

                List<Movie> categoryList = new List<Movie>();
                foreach (Movie movie in movieList)
                {
                    if ((int)movie.Category == categoryChoice)
                    {
                        categoryList.Add(movie);
                    }
                }

                var sortedCategoryList = from movie in categoryList orderby movie.Title ascending select movie;

                foreach (Movie movie in sortedCategoryList)
                {
                    Console.WriteLine(movie.Title);
                }

                Console.WriteLine("");
                Console.Write("Continue? (y/n): ");
                playAgain = PlayAgain();
                Console.Clear();

            } while (playAgain == true);

            Console.WriteLine("Thanks for playing. Press any key to exit.");
            Console.ReadKey();
        }


        public static bool PlayAgain()
        {
            bool isValidYesNo = false;
            do
            {
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "n")
                {
                    return false;
                }
                else if (input.Trim().ToLower() == "y")
                {
                    return true;
                }
                else
                {
                    Console.WriteLine("Please just enter a 'y' or an 'n'.");
                }
            } while (isValidYesNo == false);
            return false;
        }
    }
}
