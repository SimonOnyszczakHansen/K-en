using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

namespace Køen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool close = false;
            //GUI objeect
            GUI gui = new GUI();
            //The queue where we store the people
            Queue<Guest> queue = new Queue<Guest>(10);

            //here we add people to the queue
            queue.Enqueue(new Guest("Torben", 35));
            queue.Enqueue(new Guest("Arne", 27));
            queue.Enqueue(new Guest("test", 53));
            queue.Enqueue(new Guest("Testt", 23));
            queue.Enqueue(new Guest("Testtt", 83));

            //Write the list of the queue in console
            Console.WriteLine("\r\nPersoner i køen\r\n");
            foreach (Guest g in queue)
            {
                Console.WriteLine("Navn: " + g.Name + ", Alder: " + g.Age);
            }

            Console.Write("\r\nSkriv et nummer: ");//Tells the user to write a number
            char option = char.Parse(Console.ReadLine());//Collects the data

            do
            {
                if (option == '1')
                {
                    Console.Clear();//Clears console
                    Console.WriteLine("Indtast navnet på personen du vil tilføje");//Tells the user to write a name
                    string name = Console.ReadLine();//Collects the data

                    Console.WriteLine("Indtast alderen på personen du vil tilføje");//Tells the user to write an age
                    byte age = byte.Parse(Console.ReadLine());//Collects the data
                                                              
                    queue.Enqueue(new Guest(name, age));//Adds the guest to the queue that the user just wrote
                    Console.Clear();//Clears console
                }
                else if (option == '2')
                {
                    Console.Clear();//Clears console
                    queue.Dequeue();//Removes a person from the queue
                }
                else if (option == '3')
                {
                    Console.Clear();//Clears console
                    Console.WriteLine("Der er " + queue.Count + " personer i køen");//Displays the number of how many people are in the queue
                }
                else if (Console.ReadKey().Key == ConsoleKey.D4)
                {
                    close = true;//If the user presses 4 it sets "close" to true and does not run the program again
                }

                
            } while (close != true);
            
            //Shows the updated list of the queue
            Console.WriteLine("Opdateret kø\r\n");
            foreach (Guest g in queue)
            {
                Console.WriteLine("Navn: " + g.Name + ", Alder: " + g.Age);
            }

        }
        class Guest
        {
            //Instance variables
            private string name;
            private byte age;

            //Encapsulation
            public string Name { get { return name; } }
            public byte Age { get { return age; } }

            //Constructor
            public Guest(string name, byte age)
            {
                this.name = name;
                this.age = age;
            }
        }
        internal class GUI
        {
            //User interface
            public GUI()
            {
                Console.WriteLine("========================================================================================================================\r\n");
                Console.WriteLine("                                                     H1 kø operations menu");
                Console.WriteLine("\r\n========================================================================================================================");
                Console.WriteLine("1. Tilføj en gæst");
                Console.WriteLine("2. Fjern en gæst");
                Console.WriteLine("3. Vis antallet af gæster");
                Console.WriteLine("4. Luk");
            }
        }
    }
}