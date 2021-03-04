using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp53
{
    class Program
    {
        static void Main(string[] args)
        {
            //    var ppl = GeneratePeople(50000);

            //    var ids = new List<int>();
            //    for (int i = 10000; i <= 20000; i++)
            //    {
            //        ids.Add(i);
            //    }

            //    ids = ids.OrderBy(_ => Guid.NewGuid()).ToList(); //sort list randomly...
            //    ppl = ppl.OrderBy(_ => Guid.NewGuid()).ToList(); //sort list randomly...

            //    Console.WriteLine("Starting to look....");
            //    var watch = Stopwatch.StartNew();
            //    foreach (var id in ids)
            //    {
            //        Person p = FindById(ppl, id);
            //        p.Age += 5;
            //    }

            //    watch.Stop();
            //    Console.WriteLine("Done...");
            //    Console.WriteLine(watch.ElapsedMilliseconds);

            //Dictionary<string, Person> dict = new Dictionary<string, Person>();

            //dict.Add("foo", new Person { FirstName = "Avrumi" });
            //dict.Add("bar", new Person { FirstName = "John" });
            //Person me = dict["foo"];
            var ppl = GeneratePeople(500000);
            var ids = new List<int>();
            for (int i = 10000; i <= 100000; i++)
            {
                ids.Add(i);
            }
            ids = ids.OrderBy(_ => Guid.NewGuid()).ToList(); //sort list randomly...
            ppl = ppl.OrderBy(_ => Guid.NewGuid()).ToList(); //sort list randomly...

            var pplDictionary = new Dictionary<int, Person>();
            foreach (Person person in ppl)
            {
                //pplDictionary.Add(person.Id, person);
                pplDictionary[person.Id] = person;
            }
            
            Console.WriteLine("Starting to look....");
            var watch = Stopwatch.StartNew();
            foreach (var id in ids)
            {
                Person p = pplDictionary[id];
                p.Age += 5;
            }

            watch.Stop();
            Console.WriteLine("Done...");
            Console.WriteLine(watch.ElapsedMilliseconds);


            //to check if a dictionary has a given key...
            if (pplDictionary.ContainsKey(100))
            {

            }
            
            //to loop through a dictionary
            foreach (KeyValuePair<int, Person> kvp in pplDictionary)
            {
                Console.WriteLine(kvp.Key + " " + kvp.Value);
            }
            
            
            Console.ReadKey(true);


        }

        static Person FindById(List<Person> ppl, int id)
        {
            foreach (var person in ppl)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }

            return null;
        }


        static List<Person> GeneratePeople(int amount)
        {
            var list = new List<Person>();
            for (int i = 1; i <= amount; i++)
            {
                list.Add(new Person
                {
                    Id = i + 1000,
                    //FirstName = Faker.Name.First(),
                    //LastName = Faker.Name.Last(),
                    Age = Faker.RandomNumber.Next(20, 80)
                });
            }

            return list;
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    
    //Create a web application that has a textbox and a button. When the user hits submit,
    //they should get taken to a page that displays the count of each letter found within the text entered
    //For example if they type "aabbbc" the output should be:
    
    //There are 2 A's
    //There are 3 B's
    //There are 1 C's
    //There are 0 D's
    //There are 0 E's
    //and so on......
    
    //It should be case insensitive, so A and a should count towards an A. 
    
    //The idea here is to create a Dictionary<char, int> where the key is the letter, and the value is
    //the amount of times that given character was found within the text
}
