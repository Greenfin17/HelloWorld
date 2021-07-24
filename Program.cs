using System;

namespace HelloWorld
{
    class Program
    {
        // SyllableCount from https://codereview.stackexchange.com/questions/9972/syllable-counting-function
        private static int SyllableCount(string word)
            {
            word = word.ToLower().Trim();
            bool lastWasVowel = false;
            var vowelArr = new []{'a','e','i','o','u','y'};
            string vowels = new string(vowelArr);
            int count = 0;

            //a string is an IEnumerable<char>; convenient.
            foreach(var c in word)
            {
               if(vowels.Contains(c))
               {
                  if(!lastWasVowel)
                     count++;
                  lastWasVowel = true;
               }
               else
                  lastWasVowel = false;                     
            }

            if ((word.EndsWith("e") || (word.EndsWith("es") || word.EndsWith("ed"))) 
                  && !word.EndsWith("le"))
                count--;

            return count;
        }
        static void Main(string[] args)
        {
            var greeting = new string[] { "Howdy Y'all!", "Hello Mate!", "How are things?" };
            Console.WriteLine("Select a Greeting:");
            Console.WriteLine("Enter 1: Southern");
            Console.WriteLine("Enter 2: British");
            Console.WriteLine("Enter 3: US");
            var ch = Console.Read();
            Console.ReadLine(); // User has to press enter to capture ch:w

            switch (ch)
            {
                case '2':
                    Console.WriteLine(args[1]);
                    break;
                case '3':
                    Console.WriteLine(args[2]);
                    break;
                case '1':
                default:
                    Console.WriteLine(args[0]);
                    break;
            }

            Console.WriteLine("Enter your name please: ");
            string name = Console.ReadLine();
            Console.WriteLine("Welcome " + name);
                       
            Console.WriteLine("\nSome animals:");
            var animals = new string[] { "Triceratops", "Gorilla", "Corgi", "Toucan", "Cat" };
            foreach (var animal in animals)
            {
                if (SyllableCount(animal) >= 2)
                {
                    Console.WriteLine(animal);
                }
            }
            Console.Write('\n');
            Console.WriteLine("What is your favorite color?");
            string color= Console.ReadLine();
            Console.WriteLine("Would you like a random animal that is " + color + '?');
            Console.WriteLine("Enter 'y' for yes, 'n' for no");
            var answer = Console.ReadKey();
            Console.Write('\n');
            if (answer.Key.ToString() == "Y") {
                var rand = new Random();
                int animalIndex = rand.Next(animals.Length);
                Console.WriteLine("Would you like to have a " + color + ' ' + animals[animalIndex] + '?');
                Console.WriteLine("Enter 'y' for yes, 'n' for no");
                answer = Console.ReadKey();
                Console.Write('\n');
                if (answer.Key.ToString() == "Y")
                {
                    Console.WriteLine("Well than you may have a " + color + ' ' + animals[animalIndex] + '.');
                }
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
