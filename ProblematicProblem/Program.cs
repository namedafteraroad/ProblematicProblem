using System; //DONE
using System.Collections.Generic; //DONE
using System.Threading;
using System.Linq;

namespace ProblematicProblem //DONE
{
    class Program //DONE
    {

        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
        static void Main(string[] args)
        {

            Random rng = new Random();

            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: "); //DONE
            bool cont = Console.ReadLine() == "yes" ? true : false;  //fixed in class turnery

            if (cont == false)//added in class
            {
                return;
            }

            Console.WriteLine();


            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();


            Console.WriteLine();


            Console.Write("What is your age? ");
            var userAge = int.Parse(Console.ReadLine());


            Console.WriteLine();

            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            //bool seeList = new bool();
            //string seeList1 = Console.ReadLine();
            bool seeList = Console.ReadLine().ToLower() == "sure" || Console.ReadLine() == "yes" ? true : false; //added in class


            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }
                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                bool addToList = Console.ReadLine() == "yes" ? true : false;
                Console.WriteLine();
                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();
                    activities.Add(userAddition);
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    addToList = Console.ReadLine() == "yes" ? true : false;
                    //string addToList = Console.ReadLine();
                }
            }

            while (cont)
            {
                Console.Write("Connecting to the database");
                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                Console.Write("Choosing your random activity");
                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }
                Console.WriteLine();
                int randomNumber = rng.Next(activities.Count);
                string randomActivity = activities[randomNumber];
                if (userAge < 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");
                    activities.Remove(randomActivity);
                    randomNumber = rng.Next(activities.Count);
                    randomActivity = activities[randomNumber];
                    //string randomNumber = rng.Next(activities.Count);
                    //string randomActivity = activities[randomNumber];
                }
                Console.Write($"Ah got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();//DONE
                cont = Console.ReadLine() == "redo" ? true : false;

            }
        }
    }
}

